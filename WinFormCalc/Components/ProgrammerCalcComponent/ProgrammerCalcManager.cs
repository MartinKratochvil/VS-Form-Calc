using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Calculators.ProgrammerCalculator;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.ProgrammerPrimeOper;

namespace WinFormCalc.Components.ProgrammerCalcComponent
{
    public class ProgrammerCalcManager
    {

        private List<List<List<ProgrammerNumber>>> numbers;

        private int depth;

        private int bracket;

        private VarType numberType;
        
        private string example;

        private string number;

        private ProgrammerPrimeOper primeOper;

        private bool isCalculated;

        private bool isBracketClose;

        private List<int> numberTypeNames;

        public delegate void ExampleLabelUpdate(string message);

        public event ExampleLabelUpdate OnExampleLabelUpdate;

        public delegate void NumberLabelUpdate(string message);

        public event NumberLabelUpdate OnNumberLabelUpdate;

        public delegate void NumberTypeButtonUpdate(string message);

        public event NumberTypeButtonUpdate OnNumberTypeButtonUpdate;


        public ProgrammerCalcManager()
        {
            Init();
            
            ClearExample();
            ClearNumber();

            numberType = VarType.Dec;
            ChangeNumberType();

            isCalculated = false;
            isBracketClose = false;

            numberTypeNames = new List<int>((int[])Enum.GetValues(typeof(VarType)));
        }


        private void Init()
        {
            ProgrammerCalcKeyboardEvents.OnNumpadButtonClick += NumpadButtonClick;
            ProgrammerCalcKeyboardEvents.OnPlusButtonClick += PlusButtonClick;
            ProgrammerCalcKeyboardEvents.OnMinusButtonClick += MinusButtonClick;
            ProgrammerCalcKeyboardEvents.OnMultiplyButtonClick += MultiplyButtonClick;
            ProgrammerCalcKeyboardEvents.OnDivideButtonClick += DivideButtonClick;
            ProgrammerCalcKeyboardEvents.OnModuloButtonClick += ModuloButtonClick;
            ProgrammerCalcKeyboardEvents.OnLeftShiftButtonClick += LeftShiftButtonClick;
            ProgrammerCalcKeyboardEvents.OnRightShiftButtonClick += RightShiftButtonClick;
            ProgrammerCalcKeyboardEvents.OnOpenBracketButtonClick += OpenBracketButtonClick;
            ProgrammerCalcKeyboardEvents.OnCloseBracketButtonClick += CloseBracketButtonClick;
            ProgrammerCalcKeyboardEvents.OnCommaButtonClick += CommaButtonClick;
            ProgrammerCalcKeyboardEvents.OnClearButtonClick += ClearButtonClick;
            ProgrammerCalcKeyboardEvents.OnClearEntryButtonClick += ClearEntryButtonClick;
            ProgrammerCalcKeyboardEvents.OnBackButtonClick += BackButtonClick;
            ProgrammerCalcKeyboardEvents.OnEqualsButtonClick += EqualsButtonClick;

            ProgrammerCalcFunctionPanelEvents.OnLogicalFunctionButtonClick += LogicalFunctionButtonClick;
            ProgrammerCalcFunctionPanelEvents.OnNumberTypeButtonClick += NumberTypeButtonClick;
        }


        private static List<string> operators = new List<string> {
            "+",
            "-",
            "*",
            "/",
            "%",
            "<<",
            ">>",
            "AND",
            "OR",
            "NAND",
            "NOR",
            "XOR",
            "XNOR"
        };


        public void UpdateNumberLabel()
        {
            OnNumberLabelUpdate?.Invoke(number);
        }


        public void UpdateExampleLabel()
        {
            OnExampleLabelUpdate?.Invoke(example);
        }


        private void NumpadButtonClick(string placeholder)
        {
            if (isCalculated) {
                UpdateExampleLabel();
                isCalculated = false;
            }

            if (number == "0") {
                number = placeholder;
            }
            else {
                number += placeholder;
            }

            UpdateNumberLabel();
        }


        private void PlusButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.Plus);
        }


        private void MinusButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.Minus);
        }


        private void MultiplyButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.Multiply);
        }


        private void DivideButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.Divide);
        }

        
        private void ModuloButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.Modulo);
        }


        private void LeftShiftButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.LeftShift);
        }


        private void RightShiftButtonClick(string placeholder)
        {
            AddNextNumber(ProgrammerPrimeOper.RightShift);
        }


        private void OpenBracketButtonClick(string placeholder)
        {
            numbers[depth][bracket].Add(new ProgrammerNumber(primeOper));
            AddDepth();

            example += "(";
            UpdateExampleLabel();

            primeOper = ProgrammerPrimeOper.Plus;
        }


        private void CloseBracketButtonClick(string placeholder)
        {
            if ( ! AddNumber() || depth - 1 < 0) {
                return;
            }

            depth--;
            bracket = numbers[depth].Count - 1;
            isBracketClose = true;

            example += ")";
            UpdateExampleLabel();

            ClearNumber();

            primeOper = ProgrammerPrimeOper.Plus;
        }


        private void CommaButtonClick(string placeholder)
        {
            number += ',';
            UpdateNumberLabel();
        }


        private void ClearButtonClick(string placeholder)
        {
            ClearExample();
            ClearNumber();
        }


        private void ClearEntryButtonClick(string placeholder)
        {
            ClearNumber();
        }


        private void BackButtonClick(string placeholder)
        {
            if (number.Length == 1) {
                number = "0";
                UpdateNumberLabel();
                
                return;
            }
            
            number = number.Remove(number.Length - 1);
            UpdateNumberLabel();
        }


        private void EqualsButtonClick(string placeholder)
        {
            if ( ! AddNumber()) {
                return;
            }

            ShowData();

            ProgrammerCalculator calculator = new ProgrammerCalculator(numbers, new ProgrammerNumber(VarType.Bin));

            example += " = ";
            UpdateExampleLabel();
            example = string.Empty;

            number = calculator.GetResult();
            UpdateNumberLabel();
            number = "0";

            numbers = new List<List<List<ProgrammerNumber>>> {
                new List<List<ProgrammerNumber>> {
                    new List<ProgrammerNumber>()
                }
            };

            primeOper = ProgrammerPrimeOper.Plus;
            isCalculated = true;
        }


        private void LogicalFunctionButtonClick(string placeholder)
        {
            
        }


        private void NumberTypeButtonClick(string placeholder)
        {
            ChangeNumberType();
            ClearExample();

            long value = Convert.ToInt64(number, (int)numberType);
            NextNumberType();
            number = Convert.ToString(value, (int)numberType);

            UpdateNumberLabel();
            OnNumberTypeButtonUpdate?.Invoke(numberType.ToString());
        }


        private void ClearNumber()
        {
            number = "0";
            UpdateNumberLabel();
        }


        private void ClearExample()
        {
            numbers = new List<List<List<ProgrammerNumber>>> {
                new List<List<ProgrammerNumber>> {
                    new List<ProgrammerNumber>()
                }
            };

            example = string.Empty;
            UpdateExampleLabel();
            
            primeOper = ProgrammerPrimeOper.Plus;
            depth = 0;
            bracket = 0;
        }


        private void AddNextNumber(ProgrammerPrimeOper nextPrimeOper)
        {
            if ( ! AddNumber()) {
                return;
            }

            primeOper = nextPrimeOper;

            example += " " + operators[(int)nextPrimeOper] + " ";
            UpdateExampleLabel();

            ClearNumber();
        }


        private bool AddNumber()
        {
            if (isBracketClose) {
                isBracketClose = false;
                return true;
            }
            
            if ( ! long.TryParse(number, out long value)) {
                ClearNumber();
                return false;
            }

            numbers[depth][bracket].Add(
                new ProgrammerNumber(value, primeOper)
            );
            example += number;

            return true;
        }


        private void AddDepth()
        {
            depth++;
            if (depth == numbers.Count) {
                numbers.Add(new List<List<ProgrammerNumber>>());
            }

            bracket = numbers[depth].Count;
            numbers[depth].Add(new List<ProgrammerNumber>());
        }


        private string GetCloseBrackets(int count)
        {
            if (count == 0) {
                return string.Empty;
            }
            
            return Enumerable.Repeat(')', count).Aggregate(
                string.Empty,
                (total, next) => total + next
            );
        }


        private void ChangeNumberType()
        {

        }


        private void NextNumberType()
        {
            int index = numberTypeNames.IndexOf((int)numberType);

            if (index == numberTypeNames.Count - 1) {
                numberType = (VarType)numberTypeNames[0];
                return;
            }
            
            numberType = (VarType)numberTypeNames[index + 1];
        }


        private void ShowData()
        {
            string data = "{\n";
            numbers.ForEach(list => {
                data += "    [\n";
                list.ForEach(list2 => {
                    data += "        (\n";
                    list2.ForEach(num => {
                        if (num.IsList) {
                            data += "            " + num.PrimeOper + " list\n";
                        }
                        else {
                            data += "            " + num.PrimeOper + " " + num.Value + ",\n";
                        }
                    });
                    data += "        ),\n";
                });
                data += "    ],\n";
            });
            data += "}";

            MessageBox.Show(data);
            MessageBox.Show(((int[])Enum.GetValues(typeof(VarType))).Aggregate("", (s, num) => s += " " + num));
        }
    }
}