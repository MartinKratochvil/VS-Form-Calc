using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.AdvanceCalcComponent
{
    public class AdvanceCalcKeyboardEvents
    {

        public delegate void ButtonClick(string placeholder);
        
        public static event ButtonClick OnNumpadButtonClick;

        public static event ButtonClick OnPlusButtonClick;

        public static event ButtonClick OnMinusButtonClick;

        public static event ButtonClick OnMultiplyButtonClick;

        public static event ButtonClick OnDivideButtonClick;

        public static event ButtonClick OnModuloButtonClick;

        public static event ButtonClick OnFactorialButtonClick;

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
                { "x²", delegate(string placeholder) { OnFactorialButtonClick?.Invoke(placeholder); } },
                { "x³", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "√x", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "∛x", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "xⁿ", delegate(string placeholder) { OnClearEntryButtonClick?.Invoke(placeholder); } },
                { "ⁿ√x", delegate(string placeholder) { OnPowButtonClick?.Invoke(placeholder); } },
                { "log", delegate(string placeholder) { OnAbsButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string, Action<string>> {
                { "eⁿ", delegate(string placeholder) { OnAbsButtonClick?.Invoke(placeholder); } },
                { "π", delegate(string placeholder) { OnAbsButtonClick?.Invoke(placeholder); } },
                { "(", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "7", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "4", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "1", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "ln", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string, Action<string>> {
                { "CE", delegate(string placeholder) { OnClearButtonClick?.Invoke(placeholder); } },
                { "e", delegate(string placeholder) { OnSqrtButtonClick?.Invoke(placeholder); } },
                { ")", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "8", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "5", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "2", delegate(string placeholder) { OnCommaButtonClick?.Invoke(placeholder); } },
                { "0", delegate(string placeholder) { OnCommaButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string,Action<string>> {
                { "C", delegate(string placeholder) { OnBackButtonClick?.Invoke(placeholder); } },
                { "|x|", delegate(string placeholder) { OnDivideButtonClick?.Invoke(placeholder); } },
                { "n!", delegate(string placeholder) { OnMultiplyButtonClick?.Invoke(placeholder); } },
                { "9", delegate(string placeholder) { OnMinusButtonClick?.Invoke(placeholder); } },
                { "6", delegate(string placeholder) { OnPlusButtonClick?.Invoke(placeholder); } },
                { "3", delegate(string placeholder) { OnEqualsButtonClick?.Invoke(placeholder); } },
                { ",", delegate(string placeholder) { OnEqualsButtonClick?.Invoke(placeholder); } }
            },
            new Dictionary<string,Action<string>> {
                { "Back", delegate(string placeholder) { OnBackButtonClick?.Invoke(placeholder); } },
                { "%", delegate(string placeholder) { OnDivideButtonClick?.Invoke(placeholder); } },
                { "/", delegate(string placeholder) { OnMultiplyButtonClick?.Invoke(placeholder); } },
                { "*", delegate(string placeholder) { OnMinusButtonClick?.Invoke(placeholder); } },
                { "-", delegate(string placeholder) { OnPlusButtonClick?.Invoke(placeholder); } },
                { "+", delegate(string placeholder) { OnEqualsButtonClick?.Invoke(placeholder); } },
                { "=", delegate(string placeholder) { OnEqualsButtonClick?.Invoke(placeholder); } }
            }
        };
    }
}