using System.Collections.Generic;
using System.Globalization;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Calculators.AdvanceCalculator
{
	public class AdvanceCalculator
	{

        private readonly bool isList;

        private readonly AdvanceNumber number;

        private readonly List<AdvanceCalculator> numbers;


        private AdvanceCalculator(AdvanceNumber number)
        {
            this.number = number;
            isList = false;
        }


        public AdvanceCalculator(List<List<List<AdvanceNumber>>> numbers, AdvanceNumber number)
        {
            this.numbers = new List<AdvanceCalculator>();
            this.number = number;
            isList = true;

            numbers = new List<List<List<AdvanceNumber>>>(numbers);

            List<AdvanceNumber> values = new List<AdvanceNumber>(numbers[0][0]);
            numbers.Remove(numbers[0]);

            foreach (AdvanceNumber value in values) {
                if (!value.IsList) {
                    this.numbers.Add(new AdvanceCalculator(value));
                    continue;
                }

                this.numbers.Add(new AdvanceCalculator(numbers, value));
                numbers[0].Remove(numbers[0][0]);
            }
        }


        private AdvanceNumber Calculate()
        {   
            if (!isList) {
                return number;
            }

            List<AdvanceNumber> numbers = new List<AdvanceNumber>();
            foreach (AdvanceCalculator calc in this.numbers) {
                AdvanceNumber value = calc.Calculate();

                if (AdvancePrimeOperHandler.Handle(numbers, value)) {
                    continue;
                }

                numbers.Add(value);
            };

            double result = 0;
            foreach (AdvanceNumber number in numbers) {
                if (number.PrimeOper == AdvancePrimeOper.Minus) {
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
            return Calculate().Value.ToString(CultureInfo.CurrentCulture);
        }
    }
}
