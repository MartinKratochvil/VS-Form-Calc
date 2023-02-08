﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalc.Convertors
{
    public class Speed
    {
        public static Double Convert(double value, SpeedEnum from, SpeedEnum to)
        {
            int fromType = (int)from;
            int toType = (int)to < 100 ? (int)to : 0;

            if ((int)fromType < (int)toType)
            {
                return value / Math.Pow(1000, (int)toType - (int)fromType);
            }

            return value * Math.Pow(1000, (int)fromType - (int)toType);
        }
    }
}
