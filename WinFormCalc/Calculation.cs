using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormCalc
{
    public class Calculation
    {

        private List<Number> numbers;


        public Calculation (List<Number> numbers)
        {
            this.numbers = numbers;
        }


        public double GetResult()
        {
            double result = 0;

            foreach (Number number in numbers)
            {
                result += number.Value;
            }

            return result;
        }
    }
}
