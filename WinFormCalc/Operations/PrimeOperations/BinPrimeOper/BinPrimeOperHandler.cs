using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.ProgrammerCalculator;

namespace WinFormCalc.Operations.PrimeOperations.BinPrimeOper
{
    public static class BinPrimeOperHandler
    {
        private delegate void PrimeOperDel(List<ProgrammerNumber> values, ProgrammerNumber x);

        private static readonly Dictionary<PrimeOperations.BinPrimeOper.BinPrimeOper, PrimeOperDel> Operations = new Dictionary<PrimeOperations.BinPrimeOper.BinPrimeOper, PrimeOperDel>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(PrimeOperations.BinPrimeOper.BinPrimeOper)).Length; i++) {
                MethodInfo method = typeof(BinPrimeOperHandler).GetMethod(Enum.GetName(typeof(PrimeOperations.BinPrimeOper.BinPrimeOper), i) ?? string.Empty);

                if (method != null) {
                    Operations.Add((PrimeOperations.BinPrimeOper.BinPrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
                }
            }
        }


        public static void Handle(List<ProgrammerNumber> values, ProgrammerNumber x, PrimeOperations.BinPrimeOper.BinPrimeOper primeOper)
        {
            if (primeOper != PrimeOperations.BinPrimeOper.BinPrimeOper.None) {
                Operations[primeOper].DynamicInvoke(values, x);
            }
        }


        public static void Multiply(List<ProgrammerNumber> values, ProgrammerNumber x)
        {
            values[values.Count - 1] = new ProgrammerNumber(values[values.Count - 1].value * x.value);
        }


        public static void Divide(List<ProgrammerNumber> values, ProgrammerNumber x)
        {
            values[values.Count - 1] = new ProgrammerNumber(values[values.Count - 1].value / x.value);
        }


        public static void Modulo(List<ProgrammerNumber> values, ProgrammerNumber x)
        {
            values[values.Count - 1] = new ProgrammerNumber(values[values.Count - 1].value % x.value);
        }


        public static void LeftShift(List<ProgrammerNumber> values, ProgrammerNumber x)
        {
            values[values.Count - 1] = new ProgrammerNumber(values[values.Count - 1].value << (int)x.value);
        }


        public static void RightShift(List<ProgrammerNumber> values, ProgrammerNumber x)
        {
            values[values.Count - 1] = new ProgrammerNumber(values[values.Count - 1].value >> (int)x.value);
        }
    }
}
