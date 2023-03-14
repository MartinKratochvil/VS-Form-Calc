using System;

namespace WinFormCalc.Convertors.Speed;

public class Speed
{
    public static Double Convert(double value, SpeedEnum from, SpeedEnum to)
    {
        int fromType = (int)from;
        int toType = (int)to < 100 ? (int)to : 0;

        if (fromType < toType) {
            return value / Math.Pow(1000, toType - fromType);
        }

        return value * Math.Pow(1000, fromType - toType);
    }
}