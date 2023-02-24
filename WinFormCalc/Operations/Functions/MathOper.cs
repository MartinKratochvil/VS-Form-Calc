using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.AdvanceCalculator;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;

namespace WinFormCalc.Calculators.GoniometricFunctions.Functions
{
    public class MathOper
    {

        private delegate void OperDel(List<AdvanceNumber> values, AdvanceNumber x);

        private readonly static Dictionary<PrimeOper, Delegate> func = new Dictionary<PrimeOper, Delegate>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(PrimeOper)).Length; i++)
            {
                MethodInfo method = typeof(MathOper).GetMethod(Enum.GetName(typeof(PrimeOper), i));

                if (method != null)
                {
                    func.Add((PrimeOper)i, (OperDel)Delegate.CreateDelegate(typeof(OperDel), method));
                }
            }
        }


        public static void Activate(List<AdvanceNumber> values, AdvanceNumber x, PrimeOper primeOper)
        {
            if (primeOper != PrimeOper.None)
            {
                func[primeOper].DynamicInvoke(values, x);
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


        public static void Pow(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(Math.Pow(values[values.Count - 1].Value, x.Value));
        }


        public static void Sqrt(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(Math.Pow(values[values.Count - 1].Value, 1f / x.Value));
        }


        public static void Log(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(Math.Log(values[values.Count - 1].Value, x.Value));
        }


        public static void EulPow(List<AdvanceNumber> values, AdvanceNumber x)
        {
            values[values.Count - 1] = new AdvanceNumber(Math.Pow(values[values.Count - 1].Value, x.Value));
        }
    }
}
