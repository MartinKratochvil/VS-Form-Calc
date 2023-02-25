using System.Collections.Generic;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;

namespace WinFormCalc.Calculators.BasicCalculator
{
    public class BasicCalculator
    {

        private readonly List<BasicNumber> numbers;


        public BasicCalculator (List<BasicNumber> numbers)
        {
            this.numbers = numbers;
        }


        public double GetResult()
        {
            double result = 0;

            foreach (BasicNumber number in numbers) {
                result = BasicPrimeOperHandler.Handle(result, number.Value, number.PrimeOper);
            }

            return result;
        }
    }
}
