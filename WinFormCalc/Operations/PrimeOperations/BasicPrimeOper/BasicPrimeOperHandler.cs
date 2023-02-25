using System;
using System.Collections.Generic;
using System.Reflection;

namespace WinFormCalc.Operations.PrimeOperations.BasicPrimeOper
{
    public class BasicPrimeOperHandler
    {
        
        private delegate double PrimeOperDel(double origin, double operate);

        private static readonly Dictionary<BasicPrimeOper, PrimeOperDel> Operations = new Dictionary<BasicPrimeOper, PrimeOperDel>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(BasicPrimeOper)).Length; i++) {
                MethodInfo method = typeof(BasicPrimeOperHandler).GetMethod(Enum.GetName(typeof(BasicPrimeOper), i) ?? String.Empty);

                if (method != null) {
                    Operations.Add((BasicPrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
                }
            }
        }


        public static double Handle(double origin, double operate, BasicPrimeOper primeOper)
        {
            if (primeOper == BasicPrimeOper.None) {
                return origin + operate;
            }
            
            return (double)Operations[primeOper].DynamicInvoke(origin, operate);
        }


        public static double Multiply(double origin, double operate)
        {
            return origin * operate;
        }


        public static double Divide(double origin, double operate)
        {
            return origin / operate;
        }


        public static double Modulo(double origin, double operate)
        {
            return origin % operate;
        }
    }
}