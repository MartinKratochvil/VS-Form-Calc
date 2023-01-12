using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
