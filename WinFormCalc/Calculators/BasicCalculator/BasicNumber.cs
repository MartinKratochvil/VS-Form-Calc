using System;
using System.Collections.Generic;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Calculators.GoniometricFunctions.Functions;

namespace WinFormCalc.Calculators.BasicCalculator
{
    public class BasicNumber
    {

        protected double value;

        protected List<Enum> functions;

        protected bool isCalculated;


        public double Value
        {
            get
            {
                Calculate();

                return value;
            }
            set
            {
                this.value = value;
            }
        }


        protected BasicNumber(double value, List<Enum> functions)
        {
            this.value = value;
            this.functions = functions;
            this.isCalculated = false;
        }


        public BasicNumber(double value)
        {
            this.value = value;
            this.isCalculated = false;
        }

        public BasicNumber()
        {
            this.isCalculated = false;
        }


        protected virtual void Calculate()
        {
            if (isCalculated || functions == null) {
                return;
            }

            functions.ForEach(function => {
                if (function is Function) {
                    value = MathFunc.Activate(value, (Function)function);
                }
                
                if (function is GonFunc) {
                    value = MathGon.Calc(value, (GonFunc)function);
                }
            });

            isCalculated = true;
        }
    }
}
