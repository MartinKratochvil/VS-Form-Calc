using System;

namespace WinFormCalc.Convertors.Area
{
    public static class Area
    {
        public static double Convert(double value, AreaEnum from, AreaEnum to)
        {
            int fromType = (int)from;
            int toType = (int)to < 100 ? (int)to : 0;

            if (fromType < toType) {
                return value / Math.Pow(100, toType - fromType);
            }

            return value * Math.Pow(100, fromType - toType);
        }
    }
}
