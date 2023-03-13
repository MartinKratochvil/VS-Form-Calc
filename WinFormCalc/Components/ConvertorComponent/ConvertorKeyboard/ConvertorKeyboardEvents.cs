using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard
{
    public static class ConvertorKeyboardEvents
    {

        public delegate void ButtonClick(string placeholder);

        public static event ButtonClick OnNumpadButtonClick;

        public static event ButtonClick OnCommaButtonClick;

        public static event ButtonClick OnClearEntryButtonClick;
        
        public static readonly List<Dictionary<string, Action<string>>> KeyboardClickEvents = new() {
            new() {
                { "7", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "4", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "1", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "CE", delegate(string placeholder) { OnClearEntryButtonClick?.Invoke(placeholder); } }
            },
            new() {
                { "8", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "5", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "2", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "0", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } }
            },
            new() {
                { "9", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "6", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { "3", delegate(string placeholder) { OnNumpadButtonClick?.Invoke(placeholder); } },
                { ",", delegate(string placeholder) { OnCommaButtonClick?.Invoke(placeholder); } }
            }
        };
    }
}