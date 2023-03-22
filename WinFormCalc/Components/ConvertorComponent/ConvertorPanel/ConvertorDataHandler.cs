using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel;

public static class ConvertorDataHandler
{

    public static List<Enum> Handle<T>() where T : Enum
    {
        List<T> TEnums = new List<T>((T[])Enum.GetValues(typeof(T)));
        List<Enum> data = new();

        TEnums.ForEach(item => { data.Add(item); });

        return data;
    }
}