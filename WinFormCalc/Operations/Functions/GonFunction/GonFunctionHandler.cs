﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace WinFormCalc.Operations.Functions.GonFunction;

public class GonFunctionHandler
{

    private delegate double GonFunctionDel(double x);

    private static readonly Dictionary<GonFunction, GonFunctionDel> Operations = new();


    public static void Setup()
    {
        for(int i = 0; i < Enum.GetNames(typeof(GonFunction)).Length; i++) {
            MethodInfo method = typeof(GonFunctionHandler).GetMethod(Enum.GetName(typeof(GonFunction), i) ?? string.Empty);
                
            if (method != null) {
                Operations.Add((GonFunction)i, (GonFunctionDel)Delegate.CreateDelegate(typeof(GonFunctionDel), method));
            }
        }
    }


    public static double Handle(double x, GonFunction gonFunction)
    {
        return (double)Operations[gonFunction].DynamicInvoke(x);
    } 


    public static double Sin(double x)
    {
        return Math.Sin(x);
    }


    public static double Cosin(double x)
    {
        return Math.Cos(x);
    }


    public static double Tan(double x)
    {
        return Math.Tan(x);
    }


    public static double Sec(double x)
    {
        return 1 / Math.Cos(x);
    }


    public static double Cosec(double x)
    {
        return 1 / Math.Sin(x);
    }


    public static double Cotan(double x)
    {
        return 1 / Math.Tan(x);
    }


    public static double Arcsin(double x)
    {
        return Math.Atan(x / Math.Sqrt(-x * x + 1));
    }


    public static double Arccos(double x)
    {
        return Math.Atan(-x / Math.Sqrt(-x * x + 1)) + 2 * Math.Atan(1);
    }


    public static double Arctan(double x)
    {
        return Math.Atan(x);
    }


    public static double Arcsec(double x)
    {
        return 2 * Math.Atan(1) - Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
    }


    public static double Arccosec(double x)
    {
        return Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
    }


    public static double Arccotan(double x)
    {
        return 2 * Math.Atan(1) - Math.Atan(x);
    }


    public static double HSin(double x)
    {
        return (Math.Exp(x) - Math.Exp(-x)) / 2;
    }


    public static double HCos(double x)
    {
        return (Math.Exp(x) + Math.Exp(-x)) / 2;
    }


    public static double HTan(double x)
    {
        return (Math.Exp(x) - Math.Exp(-x)) / (Math.Exp(x) + Math.Exp(-x));
    }


    public static double HSec(double x)
    {
        return 2 / (Math.Exp(x) + Math.Exp(-x));
    }


    public static double HCosec(double x)
    {
        return 2 / (Math.Exp(x) - Math.Exp(-x));
    }


    public static double HCotan(double x)
    {
        return (Math.Exp(x) + Math.Exp(-x)) / (Math.Exp(x) - Math.Exp(-x));
    }


    public static double HArcsin(double x)
    {
        return Math.Log(x + Math.Sqrt(x * x + 1));
    }


    public static double HArccos(double x)
    {
        return Math.Log(x + Math.Sqrt(x * x - 1));
    }


    public static double HArctan(double x)
    {
        return Math.Log((1 + x) / (1 - x)) / 2;
    }


    public static double HArcsec(double x)
    {
        return Math.Log((Math.Sqrt(-x * x + 1) + 1) / x);
    }


    public static double HArccosec(double x)
    {
        return Math.Log((Math.Sign(x) * Math.Sqrt(x * x + 1) + 1) / x);
    }


    public static double HArccotan(double x)
    {   
        return Math.Log((x + 1) / (x - 1)) / 2;
    }
}