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

        private bool isList;

        private Number number;

        private List<Calculation> numbers;


        public Calculation (Number number)
        {
            this.isList = false;
            this.number = number;
        }


        public Calculation (List<List<List<Number>>> numbers, Number number)
        {
            this.isList = true;
            this.number = number;
            this.numbers = new List<Calculation>();

            numbers = new List<List<List<Number>>>(numbers);

            List<Number> values = new List<Number>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (Number value in values)
            {
                if ( ! value.IsList)
                {
                    this.numbers.Add(new Calculation(value));

                    continue;
                }

                this.numbers.Add(new Calculation(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }

        private Number Calculate()
        {
            if ( ! isList)
            {
                return this.number;
            }

            List<Number> numbers = new List<Number>();
            foreach (Calculation calc in this.numbers)
            {
                Number number = calc.Calculate();

                if (number.IsPriorityOperation)
                {
                    numbers[numbers.Count() - 1].Value = 
                        number.IsMultiply ?
                        numbers[numbers.Count() - 1].Value * calc.GetResult() :
                        numbers[numbers.Count() - 1].Value / calc.GetResult()
                    ;

                    continue;
                }

                numbers.Add(number);
            };

            double result = 0;
            numbers.ForEach(number =>
            {
                result = number.IsNegative ? result -= number.Value : result += number.Value;
            });

            this.number.Value = result;
            this.number.IsList = false;

            return this.number;
        }

        public double GetResult()
        {
            return Calculate().Value;
        }
    }
}
