using System;

namespace WinFormCalc.Convertors
{
    public class Length
    {
        public static Double Convert(double value, LengthEnum from, LengthEnum to)
        {
            int fromType = (int)from;
            int toType = (int)to < 100 ? (int)to : 0;

            if ((int)from >= 100)
            {
                fromType = 0;
                value = ConvertUSToSi(value, (int)from);
            }

            if ((int)fromType < (int)toType)
            {
                return ConvertSiToUS
                (
                    value / Math.Pow(10, (int)toType - (int)fromType),
                    (int)to
                );
            }

            return ConvertSiToUS
            (
                value * Math.Pow(10, (int)fromType - (int)toType),
                (int)to
            );
        }


        private static double ConvertUSToSi(double value, int size)
        {
            return value * size / 10;
        }


        private static double ConvertSiToUS(double value, int size)
        {
            if (size < 100)
            {
                return value;
            }

            return value / size * 10;
        }
    }
}
