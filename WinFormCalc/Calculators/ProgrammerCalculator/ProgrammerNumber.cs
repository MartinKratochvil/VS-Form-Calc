using System;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Operations.PrimeOperations.BinPrimeOper;

namespace WinFormCalc.Calculators.ProgrammerCalculator
{
    public class ProgrammerNumber
    {
        public long value;

        public BinPrimeOper function;

        public bool isList;


        public ProgrammerNumber(string value, VarType type, VarSize size, BinPrimeOper function)
        {
            this.isList = false;
            this.function = function;

            try
            {
                this.value = Convert.ToInt64(value, (int)type);
            }
            catch
            {
                this.value = 0;
            }
        }


        public ProgrammerNumber(long value, VarSize size, BinPrimeOper function)
        {
            this.isList = false;
            this.value = value;
            this.function = function;
        }


        public ProgrammerNumber(long value)
        {
            this.isList = false;
            this.value = value;
        }                                                                                                                                                                                                   


        public ProgrammerNumber(BinPrimeOper function)
        {
            this.isList = true;
            this.function = function;
        }
    }
}
