using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Calculators.ProgrammerCalculator;

namespace WinFormCalc.Calculators.GoniometricFunctions.Functions
{
    public static class BinOper
    {
        private delegate void BinDel(List<ProgrammerNumber> values, ProgrammerNumber x);

        private readonly static Dictionary<BinFunction, Delegate> func = new Dictionary<BinFunction, Delegate>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(BinFunction)).Length; i++)
            {
                MethodInfo method = typeof(BinOper).GetMethod(Enum.GetName(typeof(BinFunction), i));

                if (method != null)
                {
                    func.Add((BinFunction)i, (BinDel)Delegate.CreateDelegate(typeof(BinDel), method));
                }
            }
        }


        public static void Activate(List<ProgrammerNumber> values, ProgrammerNumber x, BinFunction binFunction)
        {
            if (binFunction != BinFunction.None)
            {
                func[binFunction].DynamicInvoke(values, x);
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
