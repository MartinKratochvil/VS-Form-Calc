using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcKeyboard
{
    public static class AdvanceCalcKeyboardEvents
    {

        public delegate void ButtonClick(string placeholder);
        
        public static event ButtonClick OnNumpadButtonClick;

        public static event ButtonClick OnPlusButtonClick;

        public static event ButtonClick OnMinusButtonClick;

        public static event ButtonClick OnMultiplyButtonClick;

        public static event ButtonClick OnDivideButtonClick;

        public static event ButtonClick OnModuloButtonClick;

        public static event ButtonClick OnPowButtonClick;

        public static event ButtonClick OnYRootButtonClick;

        public static event ButtonClick OnSqrButtonClick;

        public static event ButtonClick OnSqrtButtonClick;

        public static event ButtonClick OnCubeButtonClick;

        public static event ButtonClick OnCubeRootButtonClick;

        public static event ButtonClick OnAbsButtonClick;

        public static event ButtonClick OnFactButtonClick;

        public static event ButtonClick OnLogButtonClick;

        public static event ButtonClick OnLnButtonClick;

        public static event ButtonClick OnEulPowButtonClick;

        public static event ButtonClick OnPiButtonClick;

        public static event ButtonClick OnEulButtonClick;

        public static event ButtonClick OnOpenBracketButtonClick;

        public static event ButtonClick OnCloseBracketButtonClick;

        public static event ButtonClick OnCommaButtonClick;

        public static event ButtonClick OnClearButtonClick;

        public static event ButtonClick OnClearEntryButtonClick;

        public static event ButtonClick OnBackButtonClick;

        public static event ButtonClick OnEqualsButtonClick;

        public static readonly List<Dictionary<string, Action<string>>> KeyboardClickEvents = new() {
            new() {
                { "x²", delegate(string placeholder) { OnSqrButtonClick?.Invoke(placeholder); } },
                { "x³", delegate(string placeholder) { OnCubeButtonClick?.Invoke(placeholder); } },
                { "√x", delegate(string placeholder) { OnSqrtButtonClick?.Invoke(placeholder); } },
                { "∛x", delegate(string placeholder) { OnCubeRootButtonClick?.Invoke(placeholder); } },
                { "xⁿ", delegate(string placeholder) { OnPowButtonClick?.Invoke(placeholder); } },
                { "ⁿ√x", delegate(string placeholder) { OnYRootButtonClick?.Invoke(placeholder); } },
                { "log", delegate(string placeholder) { OnLogButtonClick?.Invoke(placeholder); } }
            },
            new() {
                { "eⁿ", delegate(string placeholder) { OnEulPowButtonClick?.Invoke(placeholder); } },
                { "π", delegate(string placeholder) { OnPiButtonClick?.Invoke(placeholder); } },
                { "(", delegate(string placeholder) { OnOpenBracketButtonClick?.Invoke(placeholder); } },
                { "7", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "4", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "1", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "ln", delegate(string placeholder) { OnLnButtonClick?.Invoke(placeholder); } }
            },
            new() {
                { "CE", delegate(string placeholder) { OnClearEntryButtonClick?.Invoke(placeholder); } },
                { "e", delegate(string placeholder) { OnEulButtonClick?.Invoke(placeholder); } },
                { ")", delegate(string placeholder) { OnCloseBracketButtonClick?.Invoke(placeholder); } },
                { "8", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "5", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "2", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "0", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } }
            },
            new() {
                { "C", delegate(string placeholder) { OnClearButtonClick?.Invoke(placeholder); } },
                { "|x|", delegate(string placeholder) { OnAbsButtonClick?.Invoke(placeholder); } },
                { "n!", delegate(string placeholder) { OnFactButtonClick?.Invoke(placeholder); } },
                { "9", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "6", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "3", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { ",", delegate(string placeholder) { OnCommaButtonClick?.Invoke(placeholder); } }
            },
            new() {
                { "Back", delegate(string placeholder) { OnBackButtonClick?.Invoke(placeholder); } },
                { "%", delegate(string placeholder) { OnModuloButtonClick?.Invoke(placeholder); } },
                { "/", delegate(string placeholder) { OnDivideButtonClick?.Invoke(placeholder); } },
                { "*", delegate(string placeholder) { OnMultiplyButtonClick?.Invoke(placeholder); } },
                { "-", delegate(string placeholder) { OnMinusButtonClick?.Invoke(placeholder); } },
                { "+", delegate(string placeholder) { OnPlusButtonClick?.Invoke(placeholder); } },
                { "=", delegate(string placeholder) { OnEqualsButtonClick?.Invoke(placeholder); } }
            }
        };
    }
}