using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.AdvanceCalculator;

namespace WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper
{
    public class AdvancePrimeOperHandler
    {

        private delegate void PrimeOperDel(List<AdvanceNumber> values, AdvanceNumber x);

        private static readonly Dictionary<AdvancePrimeOper, PrimeOperDel> Operations = new Dictionary<AdvancePrimeOper, PrimeOperDel>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(AdvancePrimeOper)).Length; i++) {
                MethodInfo method = typeof(AdvancePrimeOperHandler).GetMethod(Enum.GetName(typeof(AdvancePrimeOper), i) ?? string.Empty);

                if (method != null) {
                    Operations.Add((AdvancePrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
                }
            }
        }


        public static void Handle(List<AdvanceNumber> values, AdvanceNumber x, AdvancePrimeOper primeOper)
        {
            if (primeOper != AdvancePrimeOper.None)
            {
                Operations[primeOper].DynamicInvoke(values, x);
            }
        }


        public static void Multiply(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(values[values.Count - 1].Value * x.Value);
        }


        public static void Divide(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(values[values.Count - 1].Value / x.Value);
        }
        
        
        public static void Modulo(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(values[values.Count - 1].Value % x.Value);
        }


        public static void Pow(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(Math.Pow(values[values.Count - 1].Value, x.Value));
        }


        public static void YRoot(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(Math.Pow(values[values.Count - 1].Value, 1f / x.Value));
        }
    }
}
