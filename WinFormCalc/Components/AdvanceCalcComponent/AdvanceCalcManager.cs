using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WinFormCalc.Calculators.AdvanceCalculator;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Components.AdvanceCalcComponent
{
    public class AdvanceCalcManager
    {

        private List<List<List<AdvanceNumber>>> numbers;

        private int depth;

        private int bracket;

        private string example;

        private string number;

        private AdvancePrimeOper primeOper;

        private List<Enum> functions;

        private bool isCalculated;

        private bool isBracketClose;

        public delegate void ExampleLabelUpdate(string message);

        public event ExampleLabelUpdate OnExampleLabelUpdate;

        public delegate void NumberLabelUpdate(string message);

        public event NumberLabelUpdate OnNumberLabelUpdate;

        public AdvanceCalcManager()
        {
            Init();
            
            ClearExample();
            isCalculated = false;
            isBracketClose = false;
        }


        private void Init()
        {
            AdvanceCalcKeyboardEvents.OnNumpadButtonClick += NumpadButtonClick;
            AdvanceCalcKeyboardEvents.OnPlusButtonClick += PlusButtonClick;
            AdvanceCalcKeyboardEvents.OnMinusButtonClick += MinusButtonClick;
            AdvanceCalcKeyboardEvents.OnMultiplyButtonClick += MultiplyButtonClick;
            AdvanceCalcKeyboardEvents.OnDivideButtonClick += DivideButtonClick;
            AdvanceCalcKeyboardEvents.OnModuloButtonClick += ModuloButtonClick;
            AdvanceCalcKeyboardEvents.OnPowButtonClick += PowButtonClick;
            AdvanceCalcKeyboardEvents.OnYRootButtonClick += YRootButtonClick;
            AdvanceCalcKeyboardEvents.OnSqrButtonClick += SqrButtonClick;
            AdvanceCalcKeyboardEvents.OnSqrtButtonClick += SqrtButtonClick;
            AdvanceCalcKeyboardEvents.OnCubeButtonClick += CubeButtonClick;
            AdvanceCalcKeyboardEvents.OnCubeRootButtonClick += CubeRootButtonClick;
            AdvanceCalcKeyboardEvents.OnAbsButtonClick += AbsButtonClick;
            AdvanceCalcKeyboardEvents.OnFactButtonClick += FactButtonClick;
            AdvanceCalcKeyboardEvents.OnLogButtonClick += LogButtonClick;
            AdvanceCalcKeyboardEvents.OnLnButtonClick += LnButtonClick;
            AdvanceCalcKeyboardEvents.OnEulPowButtonClick += EulPowButtonClick;
            AdvanceCalcKeyboardEvents.OnPiButtonClick += PiButtonClick;
            AdvanceCalcKeyboardEvents.OnEulButtonClick += EulButtonClick;
            AdvanceCalcKeyboardEvents.OnOpenBracketButtonClick += OpenBracketButtonClick;
            AdvanceCalcKeyboardEvents.OnCloseBracketButtonClick += CloseBracketButtonClick;
            AdvanceCalcKeyboardEvents.OnCommaButtonClick += CommaButtonClick;
            AdvanceCalcKeyboardEvents.OnClearButtonClick += ClearButtonClick;
            AdvanceCalcKeyboardEvents.OnClearEntryButtonClick += ClearEntryButtonClick;
            AdvanceCalcKeyboardEvents.OnBackButtonClick += BackButtonClick;
            AdvanceCalcKeyboardEvents.OnEqualsButtonClick += EqualsButtonClick;
        }


        private static List<string> operations = new List<string> {
            "+",
            "-",
            "*",
            "/",
            "%",
            "^",
            "√"
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
            AddNextNumber(AdvancePrimeOper.Plus);
        }


        private void MinusButtonClick(string placeholder)
        {
            AddNextNumber(AdvancePrimeOper.Minus);
        }


        private void MultiplyButtonClick(string placeholder)
        {
            AddNextNumber(AdvancePrimeOper.Multiply);
        }


        private void DivideButtonClick(string placeholder)
        {
            AddNextNumber(AdvancePrimeOper.Divide);
        }

        
        private void ModuloButtonClick(string placeholder)
        {
            AddNextNumber(AdvancePrimeOper.Modulo);
        }


        private void PowButtonClick(string placeholder)
        {
            AddNextNumber(AdvancePrimeOper.Pow);
        }


        private void YRootButtonClick(string placeholder)
        {
            AddNextNumber(AdvancePrimeOper.YRoot);
        }


        private void SqrButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Sqr);
        }


        private void SqrtButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Sqrt);
        }


        private void CubeButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Cube);
        }


        private void CubeRootButtonClick(string placeholder)
        {
            AddFunction(MathFunction.CubeRoot);
        }


        private void AbsButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Abs);
        }


        private void FactButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Fact);
        }


        private void LogButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Log);
        }


        private void LnButtonClick(string placeholder)
        {
            AddFunction(MathFunction.Ln);
        }


        private void EulPowButtonClick(string placeholder)
        {
            AddFunction(MathFunction.EulPow);
        }


        private void PiButtonClick(string placeholder)
        {
            number = Math.PI.ToString(CultureInfo.CurrentCulture);
            UpdateNumberLabel();
        }


        private void EulButtonClick(string placeholder)
        {
            number = Math.E.ToString(CultureInfo.CurrentCulture);
            UpdateNumberLabel();
        }


        private void OpenBracketButtonClick(string placeholder)
        {
            numbers[depth][bracket].Add(new AdvanceNumber(primeOper, functions));
            AddDepth();

            example += "(";
            UpdateExampleLabel();

            primeOper = AdvancePrimeOper.Plus;
            functions = new List<Enum>();
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

            primeOper = AdvancePrimeOper.Plus;
            functions = new List<Enum>();
        }


        private void CommaButtonClick(string placeholder)
        {
            number += ',';
            UpdateNumberLabel();
        }


        private void ClearButtonClick(string placeholder)
        {
            ClearExample();
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

            showData();

            AdvanceCalculator calculator = new AdvanceCalculator(numbers, new AdvanceNumber());

            example += " = ";
            UpdateExampleLabel();
            example = string.Empty;

            number = calculator.GetResult();
            UpdateNumberLabel();
            number = "0";

            numbers = new List<List<List<AdvanceNumber>>> {
                new List<List<AdvanceNumber>> {
                    new List<AdvanceNumber>()
                }
            };

            primeOper = AdvancePrimeOper.Plus;
            isCalculated = true;
        }

        private void ClearNumber()
        {
            number = "0";
            UpdateNumberLabel();
        }


        private void ClearExample()
        {
            numbers = new List<List<List<AdvanceNumber>>> {
                new List<List<AdvanceNumber>> {
                    new List<AdvanceNumber>()
                }
            };

            example = string.Empty;
            UpdateExampleLabel();
            
            ClearNumber();

            primeOper = AdvancePrimeOper.Plus;
            functions = new List<Enum>();
            depth = 0;
            bracket = 0;
        }


        private void AddFunction(Enum function)
        {
            functions.Add(function);
            example += function.ToString().ToLower() + "(";
            UpdateExampleLabel();
        }


        private void AddNextNumber(AdvancePrimeOper nextPrimeOper)
        {
            if ( ! AddNumber()) {
                return;
            }

            primeOper = nextPrimeOper;

            example += " " + operations[(int)nextPrimeOper] + " ";
            UpdateExampleLabel();

            ClearNumber();
        }


        private bool AddNumber()
        {
            if (isBracketClose) {
                isBracketClose = false;
                return true;
            }
            
            if ( ! double.TryParse(number, out double value)) {
                ClearNumber();
                return false;
            }

            numbers[depth][bracket].Add(
                new AdvanceNumber(value, primeOper, functions)
            );

            example += number + GetCloseBrackets(functions.Count);
            functions = new List<Enum>();

            return true;
        }


        private void AddDepth()
        {
            depth++;
            if (depth == numbers.Count) {
                numbers.Add(new List<List<AdvanceNumber>>());
            }

            bracket = numbers[depth].Count;
            numbers[depth].Add(new List<AdvanceNumber>());
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

        private void showData()
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
        }
    }
}