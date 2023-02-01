using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc.Transfers
{
    public static class Data
    {
        public static double Convert(double value, DataEnum from, DataEnum to)
        {
            int fromType = Math.Abs((int)from);
            int toType = Math.Abs((int)to);

            value = BitByteConvertor(value, (int)from > 0, true);

            if ((int)fromType < (int)toType)
            {
                return BitByteConvertor
                (
                    value / Math.Pow(1024, (int)toType - (int)fromType),
                    true,
                    (int)to > 0
                );
            }

            return BitByteConvertor
            (
                value * Math.Pow(1024, (int)fromType - (int)toType),
                true,
                (int)to > 0
            );
        }

        private static double BitByteConvertor(double value, bool isFromByte, bool isToByte)
        {
            if (!isFromByte && isToByte)
            {
                return value / 8;
            }

            if (isFromByte && ! isToByte)
            {
                return value * 8;
            }

            return value;
        }
    }
}
