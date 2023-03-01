using System;
using System.Collections.Generic;
using WinFormCalc.Operations.PrimeOperations.PrgPrimeOper;

namespace WinFormCalc.Calculators.PrgCalculator
{
    public class PrgCalculator
    {

        private bool isList;

        private PrgNumber number;

        private List<PrgCalculator> numbers;

        public PrgCalculator(PrgNumber number)
        {
            this.number = number;
            isList = false;
        }


        public PrgCalculator(List<List<List<PrgNumber>>> numbers, PrgNumber number)
        {
            this.numbers = new List<PrgCalculator>();
            this.number = number;
            isList = true;

            numbers = new List<List<List<PrgNumber>>>(numbers);

            List<PrgNumber> values = new List<PrgNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (PrgNumber value in values) {
                if (!value.IsList) {
                    this.numbers.Add(new PrgCalculator(value));
                    continue;
                }

                this.numbers.Add(new PrgCalculator(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }


        private PrgNumber Calculate()
        {
            if (!isList) {
                return number;
            }

            List<PrgNumber> numbers = new List<PrgNumber>();
            foreach (PrgCalculator calc in this.numbers) {
                PrgNumber value = calc.Calculate();

                if (ProgrammerPrimeOperHandler.Handle(numbers, value)) {
                    continue;
                }

                numbers.Add(value);
            };

            long result = 0;
            foreach (PrgNumber number in numbers) {
                if (number.PrimeOper == PrgPrimeOper.Minus) {
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
            PrgNumber answer = Calculate();
            return Convert.ToString(answer.Value, (int)answer.Type).ToUpper();
        }
    }
}
