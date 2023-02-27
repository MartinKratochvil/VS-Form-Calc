using System.Collections.Generic;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;

namespace WinFormCalc.Calculators.BasicCalculator
{
    public class BasicNumber
    {

        private double value;

        public BasicPrimeOper PrimeOper { get; }

        private List<MathFunction> functions;


        public double Value
        {
            get {
                Calculate();
                return value;
            }
        }


        public BasicNumber(double value, BasicPrimeOper primeOper, List<MathFunction> functions)
        {
            this.value = value;
            PrimeOper = primeOper;
            this.functions = functions;
        }


        private void Calculate()
        {
            functions.ForEach(function => {
                value = MathFunctionHandler.Handle(value, function);
            });
        }
    }
}
