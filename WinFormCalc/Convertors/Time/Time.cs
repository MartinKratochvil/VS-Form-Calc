using System;

namespace WinFormCalc.Convertors.Time;

public class Time
{

    public static double Convert(double value, TimeEnum from, TimeEnum to)
    {
        value = ConvertToSec(value, (int)from);

        return ConvertFromSec(value, (int)to);
    }


    private static double ConvertToSec(double value, int size)
    {
        if (size < 0) {
            return value / Math.Abs(size);
        }

        if (size > 1_000_000) {
            value *= size / 1_000_000f;
        }

        return value * (size > 1_000_000 ? (int)TimeEnum.Day : size);
    }


    private static double ConvertFromSec(double value, int size)
    {
        if (size < 0) {
            return value * Math.Abs(size);
        }

        if (size > 1_000_000) {
            value /= size / 1_000_000f;
        }

        return value / (size > 1_000_000 ? (int)TimeEnum.Day : size);
    }
}