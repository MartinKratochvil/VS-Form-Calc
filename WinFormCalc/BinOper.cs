using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc
{
    public class BinOper
    {
        private delegate void BinDel(List<BinNumber> values, BinNumber x);

        private readonly static Dictionary<BinFunction, Delegate> func = new Dictionary<BinFunction, Delegate>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(BinFunction)).Length; i++)
            {
                MethodInfo method = typeof(BinOper).GetMethod(Enum.GetName(typeof(BinFunction), i));

                if (method != null)
                {
                    func.Add((BinFunction)i, (BinDel)Delegate.CreateDelegate(typeof(BinDel), method));
                }
            }
        }


        public static void Activate(List<BinNumber> values, BinNumber x, BinFunction binFunction)
        {
            if (binFunction != BinFunction.None)
            {
                func[binFunction].DynamicInvoke(values, x);
            }
        }


        public static void Multiply(List<BinNumber> values, BinNumber x)
        {
            values[values.Count - 1] = new BinNumber(values[values.Count - 1].value * x.value);
        }


        public static void Divide(List<BinNumber> values, BinNumber x)
        {
            values[values.Count - 1] = new BinNumber(values[values.Count - 1].value / x.value);
        }


        public static void Modulo(List<BinNumber> values, BinNumber x)
        {
            values[values.Count - 1] = new BinNumber(values[values.Count - 1].value % x.value);
        }


        public static void LeftShift(List<BinNumber> values, BinNumber x)
        {
            values[values.Count - 1] = new BinNumber(values[values.Count - 1].value << (int)x.value);
        }


        public static void RightShift(List<BinNumber> values, BinNumber x)
        {
            values[values.Count - 1] = new BinNumber(values[values.Count - 1].value >> (int)x.value);
        }
    }
}
