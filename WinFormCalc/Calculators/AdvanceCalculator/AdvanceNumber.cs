using System;
using System.Collections.Generic;
using WinFormCalc.Calculators.BasicCalculator;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Calculators.AdvanceCalculator
{
    public class AdvanceNumber : BasicNumber
    {

        public bool IsList;


        public AdvanceNumber(double value, AdvancePrimeOper primeOper, List<Enum> functions) : base(value, primeOper, functions)
        {
            IsList = false;
        }


        public AdvanceNumber(double value) : base(value)
        {
            IsList = false;
        }


        public AdvanceNumber(AdvancePrimeOper primeOper, List<Enum> functions) : base(primeOper, functions)
        {
            IsList = true;
        }
    }
}
