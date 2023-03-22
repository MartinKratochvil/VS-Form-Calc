using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Calculators.BasicCalculator;

namespace WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;

public class BasicPrimeOperHandler
{
        
    private delegate double PrimeOperDel(double origin, double operand);

    private static readonly Dictionary<BasicPrimeOper, PrimeOperDel> Operations = new();


    public static void Setup()
    {
        for (int i = 0; i < Enum.GetNames(typeof(BasicPrimeOper)).Length; i++) {
            MethodInfo method = typeof(BasicPrimeOperHandler).GetMethod(Enum.GetName(typeof(BasicPrimeOper), i) ?? String.Empty);

            if (method != null) {
                Operations.Add((BasicPrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
            }
        }
    }


    public static double Handle(double origin, BasicNumber operand)
    {
        return (double)Operations[operand.PrimeOper].DynamicInvoke(origin, operand.Value);
    }


    public static double Plus(double origin, double operand)
    {
        return origin + operand;
    }


    public static double Minus(double origin, double operand)
    {
        return origin - operand;
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
}