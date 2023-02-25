using System.Collections.Generic;

namespace WinFormCalc.Components.BasicCalcComponent
{
    public class BasicCalcKeyboardEvents
    {

        public delegate void ButtonClick(string placeholder);
        
        public static event ButtonClick OnNumpadButtonClick;

        public static event ButtonClick OnPlusButtonClick;

        public static event ButtonClick OnMinusButtonClick;

        public static event ButtonClick OnMultiplyButtonClick;

        public static event ButtonClick OnDivideButtonClick;

        public static event ButtonClick OnPowButtonClick;

        public static event ButtonClick OnSqrtButtonClick;

        public static event ButtonClick OnModuloButtonClick;

        public static event ButtonClick OnEqualsButtonClick;

        public static event ButtonClick OnCommaButtonClick;

        public static event ButtonClick OnClearButtonClick;

        public static event ButtonClick OnClearEntryButtonClick;

        public static event ButtonClick OnFactorialButtonClick;
        
        public static event ButtonClick OnAbsButtonClick;
        
        public static event ButtonClick OnBackButtonClick;

        public static readonly List<Dictionary<string, ButtonClick>> KeyboardClickEvents = new List<Dictionary<string, ButtonClick>> {
            new Dictionary<string, ButtonClick> {
                { "%", OnModuloButtonClick },
                { "n!", OnFactorialButtonClick },
                { "7", OnNumpadButtonClick },
                { "4", OnNumpadButtonClick },
                { "1", OnNumpadButtonClick },
                { "|n|", OnAbsButtonClick }
            },
            new Dictionary<string, ButtonClick> {
                { "CE", OnClearEntryButtonClick },
                { "pow", OnPowButtonClick },
                { "8", OnNumpadButtonClick },
                { "5", OnNumpadButtonClick },
                { "2", OnNumpadButtonClick },
                { "0", OnNumpadButtonClick }
            },
            new Dictionary<string, ButtonClick> {
                { "C", OnClearButtonClick },
                { "sqrt", OnSqrtButtonClick },
                { "9", OnNumpadButtonClick },
                { "6", OnNumpadButtonClick },
                { "3", OnNumpadButtonClick },
                { ",", OnCommaButtonClick }
            },
            new Dictionary<string, ButtonClick> {
                { "Back", OnBackButtonClick },
                { "/", OnDivideButtonClick },
                { "*", OnMultiplyButtonClick },
                { "-", OnMinusButtonClick },
                { "+", OnPlusButtonClick },
                { "=", OnEqualsButtonClick }
            }
        };
    }
}
