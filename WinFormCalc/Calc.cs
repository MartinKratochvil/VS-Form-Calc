using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormCalc
{
    public class Calc
    {

        private List<Number> numbers;


        public Calc (List<Number> numbers)
        {
            this.numbers = numbers;
        }


        public double GetResult()
        {
            double result = 0;

            foreach (Number number in numbers)
            {
                if (number.isPriorityOperation)
                {
                    result = number.isMultiply ? result * number.Value : result / number.Value;

                    continue;
                }

                result += number.Value;
            }

            return result;
        }
    }
}
