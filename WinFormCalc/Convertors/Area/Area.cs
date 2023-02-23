using System;

namespace WinFormCalc.Convertors
{
    public class Area
    {
        public static Double Convert(double value, AreaEnum from, AreaEnum to)
        {
            int fromType = (int)from;
            int toType = (int)to < 100 ? (int)to : 0;

            if ((int)fromType < (int)toType)
            {
                return value / Math.Pow(100, (int)toType - (int)fromType);
            }

            return value * Math.Pow(100, (int)fromType - (int)toType);
        }
    }
}
