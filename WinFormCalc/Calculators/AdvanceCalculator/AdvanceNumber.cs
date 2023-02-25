using System;
using System.Collections.Generic;
using WinFormCalc.Operations.Functions.GonFunction;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Calculators.AdvanceCalculator
{
    public class AdvanceNumber
    {

        private double value;

        private bool isCalculated;

        protected List<Enum> Functions;
        
        public AdvancePrimeOper PrimeOper { get; }
        
        public bool IsList;


        public double Value
        {
            get {
                Calculate();
                return value;
            }
            set => this.value = value;
        }
        
        
        public AdvanceNumber(double value, AdvancePrimeOper primeOper, List<Enum> functions)
        {
            this.value = value;
            PrimeOper = primeOper;
            Functions = functions;
            isCalculated = false;
            IsList = false;
        }


        public AdvanceNumber(double value)
        {
            this.value = value;
            IsList = false;
        }


        public AdvanceNumber(AdvancePrimeOper primeOper, List<Enum> functions)
        {
            PrimeOper = primeOper;
            Functions = functions;
            isCalculated = false;
            IsList = true;
        }


        private void Calculate()
        {
            if (isCalculated || Functions == null) {
                return;
            }

            Functions.ForEach(function => {
                if (function is MathFunction mathFunction) {
                    value = MathFunctionHandler.Handle(value, mathFunction);
                }
                
                if (function is GonFunction gonFunction) {
                    value = GonFunctionHandler.Handle(value, gonFunction);
                }
            });

            isCalculated = true;
        }
    }
}
