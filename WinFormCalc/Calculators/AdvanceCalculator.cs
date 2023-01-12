using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormCalc
{
	public class AdvanceCalculator
	{

        private bool isList;

        private AdvanceNumber number;

        private List<AdvanceCalculator> numbers;


        public AdvanceCalculator(AdvanceNumber number)
        {
            this.isList = false;
            this.number = number;
        }


        public AdvanceCalculator(List<List<List<AdvanceNumber>>> numbers, AdvanceNumber number)
        {
            this.isList = true;
            this.number = number;
            this.numbers = new List<AdvanceCalculator>();

            numbers = new List<List<List<AdvanceNumber>>>(numbers);

            List<AdvanceNumber> values = new List<AdvanceNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (AdvanceNumber value in values)
            {
                if (!value.isList)
                {
                    this.numbers.Add(new AdvanceCalculator(value));

                    continue;
                }

                this.numbers.Add(new AdvanceCalculator(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }

        private AdvanceNumber Calculate()
        {   
            if (!isList)
            {
                return this.number;
            }

            List<AdvanceNumber> numbers = new List<AdvanceNumber>();
            foreach (AdvanceCalculator calc in this.numbers)
            {
                AdvanceNumber value = calc.Calculate();

                if (value.primeOper != PrimeOper.None)
                {
                    MathOper.Activate(numbers, value, value.primeOper);

                    continue;
                }

                numbers.Add(value);
            };

            double result = 0;
            numbers.ForEach(number =>
            {
                result += number.Value;
            });

            this.number.Value = result;
            this.number.isList = false;
            return this.number;
        }

        public double GetResult()
        {
            return Calculate().Value;
        }
    }
}
