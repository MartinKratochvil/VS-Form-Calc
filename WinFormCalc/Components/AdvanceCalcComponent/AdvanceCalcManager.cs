using System.Collections.Generic;
using System.Linq;
using WinFormCalc.Calculators.BasicCalculator;
using WinFormCalc.Components.BasicCalcComponent;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;

namespace WinFormCalc.Components.AdvanceCalcComponent
{
    public class AdvanceCalcManager
    {

        private List<BasicNumber> numbers;

        private string example;

        private string number;

        private BasicPrimeOper primeOper;

        private List<MathFunction> functions;

        private bool isCalculated;

        public delegate void ExampleLabelUpdate(string message);
        
        public event ExampleLabelUpdate OnExampleLabelUpdate;

        public delegate void NumberLabelUpdate(string message);

        public event NumberLabelUpdate OnNumberLabelUpdate;

        private static List<string> operations = new List<string> {
            "*",
            "/",
            "%",
            "^",
            "√"
        };
        
        
        public AdvanceCalcManager()
        {
            ClearExample();

            isCalculated = false;

            BasicCalcKeyboardEvents.OnNumpadButtonClick += NumpadButtonClick;
            BasicCalcKeyboardEvents.OnPlusButtonClick += PlusButtonClick;
            BasicCalcKeyboardEvents.OnMinusButtonClick += MinusButtonClick;
            BasicCalcKeyboardEvents.OnMultiplyButtonClick += MultiplyButtonClick;
            BasicCalcKeyboardEvents.OnDivideButtonClick += DivideButtonClick;
            BasicCalcKeyboardEvents.OnModuloButtonClick += ModuloButtonClick;
            BasicCalcKeyboardEvents.OnFactorialButtonClick += FactorialButtonClick;
            BasicCalcKeyboardEvents.OnAbsButtonClick += AbsButtonClick;
            BasicCalcKeyboardEvents.OnPowButtonClick += PowButtonClick;
            BasicCalcKeyboardEvents.OnSqrtButtonClick += SqrtButtonClick;
            BasicCalcKeyboardEvents.OnCommaButtonClick += CommaButtonClick;
            BasicCalcKeyboardEvents.OnClearButtonClick += ClearButtonClick;
            BasicCalcKeyboardEvents.OnClearEntryButtonClick += ClearEntryButtonClick;
            BasicCalcKeyboardEvents.OnBackButtonClick += BackButtonClick;
            BasicCalcKeyboardEvents.OnEqualsButtonClick += EqualsButtonClick;
        }


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
            AddNextNumber(BasicPrimeOper.Plus);
        }


        private void MinusButtonClick(string placeholder)
        {
            AddNextNumber(BasicPrimeOper.Minus);
        }


        private void MultiplyButtonClick(string placeholder)
        {
            AddNextNumber(BasicPrimeOper.Multiply);
        }


        private void DivideButtonClick(string placeholder)
        {
            AddNextNumber(BasicPrimeOper.Divide);
        }

        
        private void ModuloButtonClick(string placeholder)
        {
            AddNextNumber(BasicPrimeOper.Modulo);
        }


        private void FactorialButtonClick(string placeholder)
        {
            AddMathFunction(MathFunction.Fact);
        }


        private void AbsButtonClick(string placeholder)
        {
            AddMathFunction(MathFunction.Abs);
        }


        private void PowButtonClick(string placeholder)
        {
            AddMathFunction(MathFunction.Sqr);
        }


        private void SqrtButtonClick(string placeholder)
        {
            AddMathFunction(MathFunction.Sqrt);
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

            BasicCalculator calculator = new BasicCalculator(numbers);

            example += " = ";
            UpdateExampleLabel();
            example = string.Empty;

            number = calculator.GetResult();
            UpdateNumberLabel();
            number = "0";

            primeOper = BasicPrimeOper.Plus;
            isCalculated = true;
        }

        private void ClearNumber()
        {
            number = "0";
            UpdateNumberLabel();
        }


        private void ClearExample()
        {
            numbers = new List<BasicNumber>();
            example = string.Empty;
            primeOper = BasicPrimeOper.Plus;
            functions = new List<MathFunction>();
            
            ClearNumber();
            UpdateExampleLabel();
        }


        private void AddMathFunction(MathFunction mathFunction)
        {
            functions.Add(mathFunction);
            example += mathFunction.ToString().ToLower() + "(";
            UpdateExampleLabel();
        }


        private void AddNextNumber(BasicPrimeOper nextPrimeOper)
        {
            if ( ! AddNumber()) {
                return;
            }

            primeOper = nextPrimeOper;
            example += " " + operations[(int)nextPrimeOper] + " ";
            UpdateExampleLabel();

            ClearNumber();
            UpdateNumberLabel();
        }


        private bool AddNumber()
        {
            if ( ! double.TryParse(number, out double value)) {
                ClearNumber();
                return false;
            }

            numbers.Add(new BasicNumber(value, primeOper, functions));

            example += number + GetCloseBrackets();
            functions = new List<MathFunction>();

            return true;
        }


        /*private bool IsNumberNegative()
        {
            return number[0] == '-';
        }*/


        /*private void SetNumberPositive()
        {
            if (IsNumberNegative()) {
                number = number.Remove(0, 1);
                UpdateNumberLabel();
            }
        }*/


        /*private void SetNumberNegative()
        {
            if ( ! IsNumberNegative()) {
                number = '-' + number;
                UpdateNumberLabel();
            }
        }*/

        private string GetCloseBrackets()
        {
            return functions.Count > 0
                ? Enumerable.Repeat(')', functions.Count).Aggregate(string.Empty, (total, next) => total + next)
                : string.Empty
            ;
        }
    }
}