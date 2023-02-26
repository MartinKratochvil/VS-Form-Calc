using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.BasicCalcComponent
{
    public static class BasicCalcKeyboardEvents
    {

        public delegate void ButtonClick(string placeholder);
        
        public static event ButtonClick OnNumpadButtonClick;

        public static event ButtonClick OnPlusButtonClick;

        public static event ButtonClick OnMinusButtonClick;

        public static event ButtonClick OnMultiplyButtonClick;

        public static event ButtonClick OnDivideButtonClick;

        public static event ButtonClick OnModuloButtonClick;

        public static event ButtonClick OnFactButtonClick;

        public static event ButtonClick OnAbsButtonClick;

        public static event ButtonClick OnPowButtonClick;

        public static event ButtonClick OnSqrtButtonClick;

        public static event ButtonClick OnCommaButtonClick;

        public static event ButtonClick OnClearButtonClick;

        public static event ButtonClick OnClearEntryButtonClick;

        public static event ButtonClick OnBackButtonClick;

        public static event ButtonClick OnEqualsButtonClick;

        public static readonly List<Dictionary<string, Action<string>>> KeyboardClickEvents = new List<Dictionary<string, Action<string>>> {
            new Dictionary<string, Action<string>> {
                { "%", delegate(string placeholder) { OnModuloButtonClick?.Invoke(placeholder); } },
                { "n!", delegate(string placeholder) { OnFactButtonClick?.Invoke(placeholder); } },
                { "7", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "4", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "1", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "|n|", delegate(string placeholder) { OnAbsButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string, Action<string>> {
                { "CE", delegate(string placeholder) { OnClearEntryButtonClick?.Invoke(placeholder); } },
                { "x²", delegate(string placeholder) { OnPowButtonClick?.Invoke(placeholder); } },
                { "8", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "5", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "2", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "0", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string, Action<string>> {
                { "C", delegate(string placeholder) { OnClearButtonClick?.Invoke(placeholder); } },
                { "√x", delegate(string placeholder) { OnSqrtButtonClick?.Invoke(placeholder); } },
                { "9", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "6", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "3", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { ",", delegate(string placeholder) { OnCommaButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string,Action<string>> {
                { "Back", delegate(string placeholder) { OnBackButtonClick?.Invoke(placeholder); } },
                { "/", delegate(string placeholder) { OnDivideButtonClick?.Invoke(placeholder); } },
                { "*", delegate(string placeholder) { OnMultiplyButtonClick?.Invoke(placeholder); } },
                { "-", delegate(string placeholder) { OnMinusButtonClick?.Invoke(placeholder); } },
                { "+", delegate(string placeholder) { OnPlusButtonClick?.Invoke(placeholder); } },
                { "=", delegate(string placeholder) { OnEqualsButtonClick?.Invoke(placeholder); } }
            }
        };
    }
}
