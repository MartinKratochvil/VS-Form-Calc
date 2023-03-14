using System.Linq;
using WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcKeyboard;
using WinFormCalc.Components.BasicCalcComponent.BasicCalcKeyboard;
using WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcKeyboard;

namespace WinFormCalc.Components;

public static class ComponentKeyPressHandler
{

    public static void HandleBasicCalc(char placeholder)
    {
        if ( ! BasicCalcKeyboardEvents.KeyboardKeyPressEvents.Keys.Contains(placeholder)) {
            return;
        }

        BasicCalcKeyboardEvents.KeyboardKeyPressEvents[placeholder].Invoke(placeholder.ToString());
    }


    public static void HandleAdvanceCalc(char placeholder)
    {
        if ( ! AdvanceCalcKeyboardEvents.KeyboardKeyPressEvents.Keys.Contains(placeholder)) {
            return;
        }

        AdvanceCalcKeyboardEvents.KeyboardKeyPressEvents[placeholder].Invoke(placeholder.ToString());
    }


    public static void HandlePrgCalc(char placeholder)
    {
        if ( ! PrgCalcKeyboardEvents.KeyboardKeyPressEvents.Keys.Contains(placeholder)) {
            return;
        }

        PrgCalcKeyboardEvents.KeyboardKeyPressEvents[placeholder].Invoke(placeholder.ToString());
    }


    public static void HandleConvertor(char placeholder)
    {
        if ( ! ConvertorKeyboardEvents.KeyboardKeyPressEvents.Keys.Contains(placeholder)) {
            return;
        }

        ConvertorKeyboardEvents.KeyboardKeyPressEvents[placeholder].Invoke(placeholder.ToString());
    }
}