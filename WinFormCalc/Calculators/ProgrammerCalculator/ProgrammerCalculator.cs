using System;
using System.Collections.Generic;
using WinFormCalc.Operations.PrimeOperations.ProgrammerPrimeOper;

namespace WinFormCalc.Calculators.ProgrammerCalculator
{
    public class ProgrammerCalculator
    {

        private bool isList;

        private ProgrammerNumber number;

        private List<ProgrammerCalculator> numbers;

        public ProgrammerCalculator(ProgrammerNumber number)
        {
            this.number = number;
            isList = false;
        }


        public ProgrammerCalculator(List<List<List<ProgrammerNumber>>> numbers, ProgrammerNumber number)
        {
            this.numbers = new List<ProgrammerCalculator>();
            this.number = number;
            isList = true;

            numbers = new List<List<List<ProgrammerNumber>>>(numbers);

            List<ProgrammerNumber> values = new List<ProgrammerNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (ProgrammerNumber value in values) {
                if (!value.IsList) {
                    this.numbers.Add(new ProgrammerCalculator(value));
                    continue;
                }

                this.numbers.Add(new ProgrammerCalculator(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }


        private ProgrammerNumber Calculate()
        {
            if (!isList) {
                return number;
            }

            List<ProgrammerNumber> numbers = new List<ProgrammerNumber>();
            foreach (ProgrammerCalculator calc in this.numbers) {
                ProgrammerNumber value = calc.Calculate();

                if (ProgrammerPrimeOperHandler.Handle(numbers, value)) {
                    continue;
                }

                numbers.Add(value);
            };

            long result = 0;
            foreach (ProgrammerNumber number in numbers) {
                if (number.PrimeOper == ProgrammerPrimeOper.Minus) {
                    result -= number.Value;
                    continue;
                }

                result += number.Value;
            }

            this.number.Value = result;
            this.number.IsList = false;
            return this.number;
        }

        public string GetResult()
        {
            ProgrammerNumber answer = Calculate();
            return Convert.ToString(answer.Value, (int)answer.Type);
        }
    }
}
