using System;

namespace WinFormCalc.Convertors.Volume;

public class Volume
{
    public static Double Convert(double value, VolumeEnum from, VolumeEnum to)
    {
        int fromType = (int)from;
        int toType = (int)to < 100 ? (int)to : 0;

        if (fromType < toType) {
            return value / Math.Pow(1000, toType - fromType);
        }

        return value * Math.Pow(1000, fromType - toType);
    }
}