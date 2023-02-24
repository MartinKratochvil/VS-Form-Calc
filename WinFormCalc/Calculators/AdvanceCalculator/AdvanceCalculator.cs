using System.Collections.Generic;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
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
            isList = false;
            this.number = number;
        }


        public AdvanceCalculator(List<List<List<AdvanceNumber>>> numbers, AdvanceNumber number)
        {
            isList = true;
            this.number = number;
            this.numbers = new List<AdvanceCalculator>();

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

                if (value.PrimeOper != AdvancePrimeOper.None) {
                    AdvancePrimeOperHandler.Handle(numbers, value, value.PrimeOper);
                    continue;
                }

                numbers.Add(value);
            };

            double result = 0;
            numbers.ForEach(number => {
                result += number.Value;
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
