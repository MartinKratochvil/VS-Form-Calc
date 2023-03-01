using System;
using System.Collections.Generic;
using System.Reflection;
using WinFormCalc.Convertors;
using WinFormCalc.Convertors.Area;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel
{
    public class ConvertorDataHandler
    {
        private delegate void SetData();

        private static readonly Dictionary<Convertor, SetData> Methods = new Dictionary<Convertor, SetData>();


        public static void Setup()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Convertor)).Length; i++) {
                MethodInfo method = typeof(ConvertorDataHandler).GetMethod(Enum.GetName(typeof(Convertor), i) ?? string.Empty);

                if (method != null) {
                    Methods.Add((Convertor)i, (SetData)Delegate.CreateDelegate(typeof(SetData), method));
                }
            }
        }


        public static void Handle(Convertor convertor)
        {
            Methods[convertor].DynamicInvoke();
        }
    }
}