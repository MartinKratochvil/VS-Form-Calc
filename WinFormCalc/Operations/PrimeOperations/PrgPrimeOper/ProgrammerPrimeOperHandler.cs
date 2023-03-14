using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.PrgCalculator;

namespace WinFormCalc.Operations.PrimeOperations.PrgPrimeOper;

public static class ProgrammerPrimeOperHandler
{

    private delegate long PrimeOperDel(long origin, long operand);

    private static readonly Dictionary<PrgPrimeOper, PrimeOperDel> Operations = new();


    public static void Setup()
    {
        for (int i = 0; i < Enum.GetNames(typeof(PrgPrimeOper)).Length; i++) {
            MethodInfo method = typeof(ProgrammerPrimeOperHandler).GetMethod(Enum.GetName(typeof(PrgPrimeOper), i) ?? string.Empty);

            if (method != null) {
                Operations.Add((PrgPrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
            }
        }
    }


    public static bool Handle(List<PrgNumber> values, PrgNumber operand)
    {
        if (operand.PrimeOper == PrgPrimeOper.Plus || operand.PrimeOper == PrgPrimeOper.Minus) {
            return false;
        }

        long value = (long)Operations[operand.PrimeOper].DynamicInvoke(
            SetNumberSign(values).Value,
            operand.Value
        );

        values[values.Count - 1] = new PrgNumber(value);

        return true;
    }


    private static PrgNumber SetNumberSign(List<PrgNumber> values) {
        PrgNumber origin = values[values.Count - 1];

        if (origin.PrimeOper == PrgPrimeOper.Minus) {
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