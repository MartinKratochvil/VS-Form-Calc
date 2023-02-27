using System;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Operations.PrimeOperations.ProgrammerPrimeOper;

namespace WinFormCalc.Calculators.ProgrammerCalculator
{
    public class ProgrammerNumber
    {

        public long Value;

        public ProgrammerPrimeOper PrimeOper { get; }

        public VarType Type { get; }

        public bool IsList;


        public ProgrammerNumber(string value, VarType type, ProgrammerPrimeOper primeOper)
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


        public ProgrammerNumber(long value, ProgrammerPrimeOper primeOper)
        {
            Value = value;
            PrimeOper = primeOper;
            IsList = false;
        }


        public ProgrammerNumber(long value)
        {
            Value = value;
            PrimeOper = ProgrammerPrimeOper.Plus;
            IsList = false;
        }                                                                                                                                                                                                   


        public ProgrammerNumber(ProgrammerPrimeOper primeOper)
        {
            PrimeOper = primeOper;
            IsList = true;
        }


        public ProgrammerNumber(VarType type)
        {
            PrimeOper = ProgrammerPrimeOper.Plus;
            Type = type;
            IsList = true;
        }
    }
}
