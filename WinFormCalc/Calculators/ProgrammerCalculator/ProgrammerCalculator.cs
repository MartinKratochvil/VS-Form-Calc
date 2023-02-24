using System.Collections.Generic;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Calculators.GoniometricFunctions.Functions;

namespace WinFormCalc.Calculators.ProgrammerCalculator
{
    public class ProgrammerCalculator
    {
        private bool isList;

        private ProgrammerNumber number;

        private List<ProgrammerCalculator> numbers;

        public ProgrammerCalculator(ProgrammerNumber number)
        {
            this.isList = false;
            this.number = number;
        }


        public ProgrammerCalculator(List<List<List<ProgrammerNumber>>> numbers, ProgrammerNumber number)
        {
            this.isList = true;
            this.number = number;
            this.numbers = new List<ProgrammerCalculator>();

            numbers = new List<List<List<ProgrammerNumber>>>(numbers);

            List<ProgrammerNumber> values = new List<ProgrammerNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (ProgrammerNumber value in values)
            {
                if (!value.isList)
                {
                    this.numbers.Add(new ProgrammerCalculator(value));

                    continue;
                }

                this.numbers.Add(new ProgrammerCalculator(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }


        private ProgrammerNumber Calculate()
        {
            if (!isList)
            {
                return this.number;
            }

            List<ProgrammerNumber> numbers = new List<ProgrammerNumber>();
            foreach (ProgrammerCalculator calc in this.numbers)
            {
                ProgrammerNumber number = calc.Calculate();

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
