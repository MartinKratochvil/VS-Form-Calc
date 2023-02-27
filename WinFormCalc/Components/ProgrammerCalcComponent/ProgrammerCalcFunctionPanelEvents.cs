using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormCalc.Components.ProgrammerCalcComponent
{
    public static class ProgrammerCalcFunctionPanelEvents
    {

        public delegate void ButtonClick(string placeholder);

        public static event ButtonClick OnLogicalFunctionButtonClick;

        public static event ButtonClick OnNumberTypeButtonClick;


        public static void LogicalFunctionButtonClick(object sender, EventArgs args)
        {
            OnLogicalFunctionButtonClick?.Invoke(((Button)sender).Text);
        }


        public static void NumberTypeButtonClick(object sender, EventArgs args)
        {
            OnNumberTypeButtonClick?.Invoke(((Button)sender).Text);
        }
    }
}