using System;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;

namespace WinFormCalc.Calculators.ProgrammerCalculator
{
    public class ProgrammerNumber
    {
        public long value;

        public BinFunction function;

        public bool isList;


        public ProgrammerNumber(string value, VarType type, VarSize size, BinFunction function)
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


        public ProgrammerNumber(long value, VarSize size, BinFunction function)
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


        public ProgrammerNumber(BinFunction function)
        {
            this.isList = true;
            this.function = function;
        }
    }
}
