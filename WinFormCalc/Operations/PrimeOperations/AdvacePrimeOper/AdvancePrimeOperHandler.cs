using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.AdvanceCalculator;

namespace WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper
{
    public class AdvancePrimeOperHandler
    {

        private delegate double PrimeOperDel(double origin, double operand);

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


        public static bool Handle(List<AdvanceNumber> values, AdvanceNumber operand)
        {
            if (operand.PrimeOper != AdvancePrimeOper.Plus && operand.PrimeOper != AdvancePrimeOper.Minus) {
                double value = (double)Operations[operand.PrimeOper].DynamicInvoke(
                    SetNumberSign(values).Value,
                    operand.Value
                );

                values[values.Count - 1] = new AdvanceNumber(value);

                return true;
            }

            return false;
        }


        private static AdvanceNumber SetNumberSign(List<AdvanceNumber> values) {
            AdvanceNumber origin = values[values.Count - 1];

            if (origin.PrimeOper == AdvancePrimeOper.Minus) {
                origin.Value *= -1;
            }

            return origin;
        }


        public static double Multiply(double origin, double operand)
        {
            return origin * operand;
        }


        public static double Divide(double origin, double operand)
        {
            return origin / operand;
        }


        public static double Modulo(double origin, double operand)
        {
            return origin % operand;
        }


        public static double Pow(double origin, double operand)
        {
            return Math.Pow(origin, operand);
        }


        public static double YRoot(double origin, double operand)
        {
            return Math.Pow(origin, 1f / operand);
        }
    }
}
