using System;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Operations.PrimeOperations.PrgPrimeOper;

namespace WinFormCalc.Calculators.PrgCalculator
{
    public class PrgNumber
    {

        public long Value;

        public PrgPrimeOper PrimeOper { get; }

        public VarType Type { get; }

        public bool IsList;


        public PrgNumber(string value, VarType type, PrgPrimeOper primeOper)
        {
            try {
                Value = Convert.ToInt64(value, (int)type);
            }
            catch {
                Value = 0;
            }

            PrimeOper = primeOper;
            IsList = false;
        }


        public PrgNumber(long value, PrgPrimeOper primeOper)
        {
            Value = value;
            PrimeOper = primeOper;
            IsList = false;
        }


        public PrgNumber(long value)
        {
            Value = value;
            PrimeOper = PrgPrimeOper.Plus;
            IsList = false;
        }                                                                                                                                                                                                   


        public PrgNumber(PrgPrimeOper primeOper)
        {
            PrimeOper = primeOper;
            IsList = true;
        }


        public PrgNumber(VarType type)
        {
            PrimeOper = PrgPrimeOper.Plus;
            Type = type;
            IsList = true;
        }
    }
}
