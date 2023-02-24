using System;
using System.Collections.Generic;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Operations.Functions;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.Functions.MathGonFunction;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Calculators.BasicCalculator
{
    public class BasicNumber
    {
        private double value;

        private bool isCalculated;

        protected List<Enum> Functions;
        
        public AdvancePrimeOper PrimeOper { get; }

        
        public virtual double Value
        {
            get {
                Calculate();

                return value;
            }
            set => this.value = value;
        }


        public BasicNumber(double value, AdvancePrimeOper primeOper, List<Enum> functions)
        {
            this.value = value;
            PrimeOper = primeOper;
            Functions = functions;
            isCalculated = false;
        }


        public BasicNumber(AdvancePrimeOper primeOper, List<Enum> functions)
        {
            PrimeOper = primeOper;
            Functions = functions;
            isCalculated = false;
        }

        
        public BasicNumber(double value)
        {
            this.value = value;
            PrimeOper = AdvancePrimeOper.None;
            Functions = new List<Enum>();
            isCalculated = false;
        }


        private void Calculate()
        {
            if (isCalculated || Functions == null) {
                return;
            }

            Functions.ForEach(function => {
                if (function is Function mathFunction) {
                    value = MathFunc.Activate(value, mathFunction);
                }
                
                if (function is GonFunc gonFunc) {
                    value = MathGon.Calc(value, gonFunc);
                }
            });

            isCalculated = true;
        }
    }
}
