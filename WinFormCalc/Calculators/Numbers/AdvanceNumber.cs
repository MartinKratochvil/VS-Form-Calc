using System;
using System.Collections.Generic;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;


namespace WinFormCalc.Calculators.Numbers
{
    public class AdvanceNumber : BasicNumber
    {

        public bool isList;

        public PrimeOper primeOper { get; }


        public AdvanceNumber(double value, PrimeOper primeOper, List<Enum> functions) : base(value, functions)
        {
            this.isList = false;
            this.primeOper = primeOper;
        }


        public AdvanceNumber(double value) : base(value)
        {
            this.isList = false;
            this.primeOper = PrimeOper.None;
        }


        public AdvanceNumber(PrimeOper primeOper, List<Enum> functions) : base()
        {
            this.isList = true;
            this.functions = functions;
            this.primeOper = primeOper;
        }
    }
}
