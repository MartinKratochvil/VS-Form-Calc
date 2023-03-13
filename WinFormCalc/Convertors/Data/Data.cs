using System;

namespace WinFormCalc.Convertors.Data
{
    public static class Data
    {
        public static double Convert(double value, DataEnum from, DataEnum to)
        {
            int fromType = Math.Abs((int)from);
            int toType = Math.Abs((int)to);

            value = BitByteConvertor(value, (int)from > 0, true);

            if (fromType < toType) {
                return BitByteConvertor(
                    value / Math.Pow(1024, toType - fromType),
                    true,
                    (int)to > 0
                );
            }

            return BitByteConvertor(
                value * Math.Pow(1024, fromType - toType),
                true,
                (int)to > 0
            );
        }

        private static double BitByteConvertor(double value, bool isFromByte, bool isToByte)
        {
            if (!isFromByte && isToByte) {
                return value / 8;
            }

            if (isFromByte && ! isToByte) {
                return value * 8;
            }

            return value;
        }
    }
}
