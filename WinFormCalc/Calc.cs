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
            numbers.ForEach(num =>
            {
                this.numbers.Add(num);
            });
        }


        public double GetResult()
        {
            double result = 0;

            foreach(Number number in numbers)
            {
                if (number.isPriorityOperation)
                {
                    result = number.isMultiply ? result *= number.Value : result /= number.Value;

                    continue;
                }

                result = number.isNegative ? result -= number.Value : result += number.Value;
            }

            return result;
        }
    }
}
