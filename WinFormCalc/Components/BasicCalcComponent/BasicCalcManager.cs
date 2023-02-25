using System;
using System.Collections.Generic;
using System.Linq;
using WinFormCalc.Calculators.BasicCalculator;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;

namespace WinFormCalc.Components.BasicCalcComponent
{
    public class BasicCalcManager
    {

        private List<BasicNumber> numbers;

        private string example;

        private List<string> history;

        private string number;

        private BasicPrimeOper primeOper;

        private List<MathFunction> functions;

        public delegate void ExampleLabelUpdate(string message);
        
        public event ExampleLabelUpdate OnExampleLabelUpdate;

        public delegate void NumberLabelUpdate(string message);

        public event NumberLabelUpdate OnNumberLabelUpdate;
        
        
        public BasicCalcManager()
        {
            numbers = new List<BasicNumber>();
            example = string.Empty;
            history = new List<string>();
            number = "0";
            primeOper = BasicPrimeOper.None;
            functions = new List<MathFunction>();

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


        private void NumpadButtonClick(string placeholder)
        {
            if (number == "0") {
                number = placeholder;
            }
            else {
                number += placeholder;
            }
            
            OnNumberLabelUpdate?.Invoke(number);
        }


        private void PlusButtonClick(string placeholder)
        {
            AddNumber(BasicPrimeOper.None);
        }


        private void MinusButtonClick(string placeholder)
        {
            AddNumber(BasicPrimeOper.None);
        }


        private void MultiplyButtonClick(string placeholder)
        {
            AddNumber(BasicPrimeOper.Multiply);
        }


        private void DivideButtonClick(string placeholder)
        {
            AddNumber(BasicPrimeOper.Divide);
        }

        
        private void ModuloButtonClick(string placeholder)
        {
            AddNumber(BasicPrimeOper.Modulo);
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
            AddMathFunction(MathFunction.Pow);
        }


        private void SqrtButtonClick(string placeholder)
        {
            AddMathFunction(MathFunction.Sqrt);
        }


        private void CommaButtonClick(string placeholder)
        {
            number += '.';
            OnNumberLabelUpdate?.Invoke(number);
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
            
        }


        private void EqualsButtonClick(string placeholder)
        {
            //swag
        }


        private void AddMathFunction(MathFunction mathFunction) {
            functions.Add(mathFunction);
            example += mathFunction.ToString().ToLower() + "(";
            OnExampleLabelUpdate?.Invoke(example);
        }


        private void AddNumber(BasicPrimeOper nextPrimeOper) {
            if ( ! double.TryParse(number, out double value)) {
                ClearNumber();
                return;
            }
            
            numbers.Add(new BasicNumber(value, nextPrimeOper, functions));

            example += number + Enumerable.Repeat(')', functions.Count);
            OnExampleLabelUpdate?.Invoke(example + " " + nextPrimeOper);

            functions = new List<MathFunction>();
            primeOper = nextPrimeOper;
            ClearNumber();
            
            OnNumberLabelUpdate?.Invoke(number);
        }


        private bool IsNumberNegative()
        {
            return number[0] == '-';
        }


        private void SetNumberPositive()
        {
            if (IsNumberNegative()) {
                number = number.Remove(0, 1);
                OnNumberLabelUpdate?.Invoke(number);
            }
        }


        private void SetNumberNegative()
        {
            if ( ! IsNumberNegative()) {
                number = '-' + number;
                OnNumberLabelUpdate?.Invoke(number);
            }
        }


        private void ClearNumber()
        {
            number = "0";
        }


        private void ClearExample()
        {
            numbers = new List<BasicNumber>();
            example = string.Empty;
            history = new List<string>();
            primeOper = BasicPrimeOper.None;
            functions = new List<MathFunction>();
            
            ClearNumber();
            
            OnExampleLabelUpdate?.Invoke(example);
            OnNumberLabelUpdate?.Invoke(number);
        }
    }
}