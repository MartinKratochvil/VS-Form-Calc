using System.Collections.Generic;
using System.Globalization;
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


        public string GetResult()
        {
            double result = 0;

            foreach (BasicNumber number in numbers) {
                result = BasicPrimeOperHandler.Handle(result, number.Value, number.PrimeOper);
            }

            return result.ToString(CultureInfo.CurrentCulture);
        }
    }
}
