﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace WinFormCalc.Operations.Functions.MathFunction;

public class MathFunctionHandler
{

    private delegate double FuncDel(double x);

    private static readonly Dictionary<MathFunction, FuncDel>Operations = new();


    public static void Setup()
    {
        int enumCount = Enum.GetNames(typeof(MathFunction)).Length;

        for (int i = 0; i < enumCount; i++) {
            MethodInfo method = typeof(MathFunctionHandler).GetMethod(
                Enum.GetName(typeof(MathFunction), i) ?? 
                string.Empty
            );

            if (method == null) {
                continue;
            }

            Operations.Add(
                (MathFunction)i,
                (FuncDel)Delegate.CreateDelegate(typeof(FuncDel), method)
            );
        }
    }


    public static double Handle(double x, MathFunction gonFunc)
    {
        return (double)Operations[gonFunc].Invoke(x);
    }


    public static double Sqr(double x)
    {
        return Math.Pow(x, 2);
    }


    public static double Cube(double x)
    {
        return Math.Pow(x, 3);
    }


    public static double Sqrt(double x)
    {
        return Math.Pow(x, 1f / 2f);
    }


    public static double CubeRoot(double x)
    {
        return Math.Pow(x, 1f / 3f);
    }


    public static double Abs(double x)
    {
        return Math.Abs(x);
    }


    public static double Round(double x)
    {
        return Math.Round(x);
    }


    public static double Floor(double x)
    {
        return Math.Floor(x);
    }


    public static double Ceil(double x)
    {
        return Math.Ceiling(x);
    }


    public static double Fact(double x)
    {
        if (x == 0 || x == 1) return 1;

        if (x > 1)
        {
            return x * Fact(x - 1);
        }
            
        throw new FormatException();
    }


    public static double Log(double x)
    {
        return Math.Log10(x);
    }


    public static double Ln(double x)
    {
        return Math.Log(x);
    }
        
        
    public static double EulPow(double x)
    {
        return Math.Pow(Math.E, x);
    }
}