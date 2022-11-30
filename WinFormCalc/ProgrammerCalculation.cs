using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalc
{
    public class ProgrammerCalculation
    {
        private bool isList;

        private BinNumber number;

        private List<ProgrammerCalculation> numbers;

        public ProgrammerCalculation(BinNumber number)
        {
            this.isList = false;
            this.number = number;
        }


        public ProgrammerCalculation(List<List<List<BinNumber>>> numbers, BinNumber number)
        {
            this.isList = true;
            this.number = number;
            this.numbers = new List<ProgrammerCalculation>();

            numbers = new List<List<List<BinNumber>>>(numbers);

            List<BinNumber> values = new List<BinNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (BinNumber value in values)
            {
                if (!value.isList)
                {
                    this.numbers.Add(new ProgrammerCalculation(value));

                    continue;
                }

                this.numbers.Add(new ProgrammerCalculation(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }


        private BinNumber Calculate()
        {
            if (!isList)
            {
                return this.number;
            }

            List<BinNumber> numbers = new List<BinNumber>();
            foreach (ProgrammerCalculation calc in this.numbers)
            {
                BinNumber number = calc.Calculate();

                if (number.function != BinFunction.None)
                {
                    BinOper.Activate(numbers, number, number.function);

                    continue;
                }

                numbers.Add(number);
            };

            long result = 0;
            numbers.ForEach(number =>
            {
                result += number.value;
            });

            this.number.value = result;
            this.number.isList = false;
            return this.number;
        }

        public double GetResult()
        {
            return Calculate().value;
        }
    }
}
