using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalc.Convertors
{
    public enum TimeEnum
    {
        Millisecond = -1,
        Second = 0,
        Minute = 1,
        Hour = 2,
        Day = 1000000,
        Month = 30436875,
        Year = 365242500
    }
}
