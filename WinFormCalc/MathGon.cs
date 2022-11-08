using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc
{
    public class MathGon
    {

        public delegate double GonDel(double x);

        public static Dictionary<GonFunc, Delegate> func = new Dictionary<GonFunc, Delegate>();


        public static void Setup()
        {
            for(int i = 0; i < Enum.GetNames(typeof(GonFunc)).Length; i++)
            {
                MethodInfo method = typeof(MathGon).GetMethod(Enum.GetName(typeof(GonFunc), i));
                
                if (method != null)
                {
                    Func<Type[], Type> getType = Expression.GetActionType;
                    IEnumerable<Type> types = method.GetParameters().Select(p => p.ParameterType);

                    func.Add((GonFunc)i, (GonDel)Delegate.CreateDelegate(typeof(GonDel), method));
                }
            }

            /*List<String> methods = (List<String>)typeof(MathGon).GetMethods
                (
                    BindingFlags.Public |
                    BindingFlags.Static
                )
            .Select(idk => idk.Name).Distinct();
            
            foreach (string methodName in methods)
            {
                MethodInfo method = typeof(MathGon).GetMethod(methodName);

                Func<Type[], Type> getType = Expression.GetActionType;
                List<Type> types = (List<Type>)method.GetParameters().Select(p => p.ParameterType);

                func.Add(GonFunc.Sin, (GonDel)Delegate.CreateDelegate(typeof(GonDel), method));
                //MessageBox.Show(method + ": " + typeof(MathGon).GetMethod(method).Invoke(method, new Object[1] { 1 }).ToString());
            }*/
        }


        public static double Calc(double x, GonFunc gonFunc)
        {
            return (double)MathGon.func[gonFunc].DynamicInvoke(x);
        } 


        public static double Sin(double x)
        {
            return Math.Sin(x);

        }


        public static double Cosin(double x)
        {
            return Math.Cos(x);
        }


        public static double Tan(double x)
        {
            return Math.Tan(x);
        }


        public static double Sec(double x)
        {
            return 1 / Math.Cos(x);
        }


        public static double Cosec(double x)
        {
            return 1 / Math.Sin(x);
        }


        public static double Cotan(double x)
        {
            return 1 / Math.Tan(x);
        }


        public static double Arcsin(double x)
        {
            return Math.Atan(x / Math.Sqrt(-x * x + 1));
        }


        public static double Arccos(double x)
        {
            return Math.Atan(-x / Math.Sqrt(-x * x + 1)) + 2 * Math.Atan(1);
        }


        public static double Arctan(double x)
        {
            return Math.Atan(x);
        }


        public static double Arcsec(double x)
        {
            return 2 * Math.Atan(1) - Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
        }


        public static double Arccosec(double x)
        {
            return Math.Atan(Math.Sign(x) / Math.Sqrt(x * x - 1));
        }


        public static double Arccotan(double x)
        {
            return 2 * Math.Atan(1) - Math.Atan(x);
        }


        public static double HSin(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / 2;
        }


        public static double HCos(double x)
        {
            return (Math.Exp(x) + Math.Exp(-x)) / 2;
        }


        public static double HTan(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / (Math.Exp(x) + Math.Exp(-x));
        }


        public static double HSec(double x)
        {
            return 2 / (Math.Exp(x) + Math.Exp(-x));
        }


        public static double HCosec(double x)
        {
            return 2 / (Math.Exp(x) - Math.Exp(-x));
        }


        public static double HCotan(double x)
        {
            return (Math.Exp(x) + Math.Exp(-x)) / (Math.Exp(x) - Math.Exp(-x));
        }


        public static double HArcsin(double x)
        {
            return Math.Log(x + Math.Sqrt(x * x + 1));
        }


        public static double HArccos(double x)
        {
            return Math.Log(x + Math.Sqrt(x * x - 1));
        }


        public static double HArctan(double x)
        {
            return Math.Log((1 + x) / (1 - x)) / 2;
        }


        public static double HArcsec(double x)
        {
            return Math.Log((Math.Sqrt(-x * x + 1) + 1) / x);
        }


        public static double HArccosec(double x)
        {
            return Math.Log((Math.Sign(x) * Math.Sqrt(x * x + 1) + 1) / x);
        }


        public static double HArccotan(double x)
        {
            return Math.Log((x + 1) / (x - 1)) / 2;
        }


        /*public static double LogN(double x, double n)
        {
            return Math.Log(x) / Math.Log(n);
        }*/
    }
}
