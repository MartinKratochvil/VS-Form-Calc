using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormCalc
{
	public class AdvanceCalculation
	{

        private bool isList;

        private AdvanceNumber number;

        private List<AdvanceCalculation> numbers;


        public AdvanceCalculation(AdvanceNumber number)
        {
            this.isList = false;
            this.number = number;
        }


        public AdvanceCalculation(List<List<List<AdvanceNumber>>> numbers, AdvanceNumber number)
        {
            this.isList = true;
            this.number = number;
            this.numbers = new List<AdvanceCalculation>();

            numbers = new List<List<List<AdvanceNumber>>>(numbers);

            List<AdvanceNumber> values = new List<AdvanceNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (AdvanceNumber value in values)
            {
                if (!value.isList)
                {
                    this.numbers.Add(new AdvanceCalculation(value));

                    continue;
                }

                this.numbers.Add(new AdvanceCalculation(numbers, value));
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
            foreach (AdvanceCalculation calc in this.numbers)
            {
                number = calc.Calculate();

                if (number.primeOper != PrimeOper.None)
                {
                    MathOper.Activate(numbers, number, number.primeOper);

                    continue;
                }

                numbers.Add(number);
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
