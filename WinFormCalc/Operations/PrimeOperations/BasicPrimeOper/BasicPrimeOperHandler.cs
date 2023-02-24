using System;
using System.Collections.Generic;
using System.Reflection;

namespace WinFormCalc.Operations.PrimeOperations.BasicPrimeOper
{
    public class BasicPrimeOperHandler
    {
        
        private delegate double PrimeOperDel(double origin, double operate);

        private static readonly Dictionary<PrimeOperations.BasicPrimeOper.BasicPrimeOper, PrimeOperDel> Operations = new Dictionary<PrimeOperations.BasicPrimeOper.BasicPrimeOper, PrimeOperDel>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(PrimeOperations.BasicPrimeOper.BasicPrimeOper)).Length; i++) {
                MethodInfo method = typeof(BasicPrimeOperHandler).GetMethod(Enum.GetName(typeof(PrimeOperations.BasicPrimeOper.BasicPrimeOper), i) ?? String.Empty);

                if (method != null) {
                    Operations.Add((PrimeOperations.BasicPrimeOper.BasicPrimeOper)i, (PrimeOperDel)Delegate.CreateDelegate(typeof(PrimeOperDel), method));
                }
            }
        }


        public static double Handle(double origin, double operate, PrimeOperations.BasicPrimeOper.BasicPrimeOper primeOper)
        {
            if (primeOper == PrimeOperations.BasicPrimeOper.BasicPrimeOper.None) {
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