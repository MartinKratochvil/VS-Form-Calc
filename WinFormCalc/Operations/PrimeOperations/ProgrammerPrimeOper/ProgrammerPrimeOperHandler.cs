using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.ProgrammerCalculator;

namespace WinFormCalc.Operations.PrimeOperations.ProgrammerPrimeOper
{
    public static class ProgrammerPrimeOperHandler
    {

        private delegate long PrimeOperDel(long origin, long operand);

        private static readonly Dictionary<ProgrammerPrimeOper, PrimeOperDel> Operations = new Dictionary<ProgrammerPrimeOper, PrimeOperDel>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(ProgrammerPrimeOper)).Length; i++) {
                MethodInfo method = typeof(ProgrammerPrimeOperHandler).GetMethod(Enum.GetName(typeof(ProgrammerPrimeOper), i) ?? string.Empty);

                if (method != null) {
                    Operations.Add((ProgrammerPrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
                }
            }
        }


        public static bool Handle(List<ProgrammerNumber> values, ProgrammerNumber operand)
        {
            if (operand.PrimeOper == ProgrammerPrimeOper.Plus || operand.PrimeOper == ProgrammerPrimeOper.Minus) {
                return false;
            }

            long value = (long)Operations[operand.PrimeOper].DynamicInvoke(
                SetNumberSign(values).Value,
                operand.Value
            );

            values[values.Count - 1] = new ProgrammerNumber(value);

            return true;
        }


        private static ProgrammerNumber SetNumberSign(List<ProgrammerNumber> values) {
            ProgrammerNumber origin = values[values.Count - 1];

            if (origin.PrimeOper == PrimeOperations.ProgrammerPrimeOper.ProgrammerPrimeOper.Minus) {
                origin.Value *= -1;
            }

            return origin;
        }


        public static long Multiply(long origin, long operand)
        {
            return origin * operand;
        }


        public static long Divide(long origin, long operand)
        {
            return origin / operand;
        }


        public static long Modulo(long origin, long operand)
        {
            return origin * operand;
        }


        public static long LeftShift(long origin, long operand)
        {
            return origin << (int)operand;
        }


        public static long RightShift(long origin, long operand)
        {
            return origin >> (int)operand;
        }


        public static long And(long origin, long operand)
        {
            return origin & operand;
        }


        public static long Or(long origin, long operand)
        {
            return origin | operand;
        }


        public static long Nand(long origin, long operand)
        {
            return ~ (origin & operand);
        }


        public static long Nor(long origin, long operand)
        {
            return ~ (origin | operand);
        }


        public static long Xor(long origin, long operand)
        {
            return origin ^ operand;
        }


        public static long Xnor(long origin, long operand)
        {
            return ~ (origin ^ operand);
        }
    }
}
