using System.Collections.Generic;
using WinFormCalc.Calculators.Numbers;


namespace WinFormCalc
{
    public class BasicCalculator
    {

        private List<BasicNumber> numbers;


        public BasicCalculator (List<BasicNumber> numbers)
        {
            this.numbers = numbers;
        }


        public double GetResult()
        {
            double result = 0;

            foreach (BasicNumber number in numbers)
            {
                result += number.Value;
            }

            return result;
        }
    }
}
