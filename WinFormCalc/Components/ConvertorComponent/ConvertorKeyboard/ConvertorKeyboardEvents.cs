using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard;

public static class ConvertorKeyboardEvents
{

    public delegate void ButtonClick(string placeholder);

    public static event ButtonClick OnNumpadButtonClick;

    public static event ButtonClick OnCommaButtonClick;

    public static event ButtonClick OnClearEntryButtonClick;
        
    public static readonly List<Dictionary<string, Action<string>>> KeyboardClickEvents = new() {
        new() {
            { "7", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "4", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "1", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "CE", placeholder => OnClearEntryButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "8", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "5", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "2", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "0", placeholder => OnNumpadButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "9", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "6", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "3", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { ",", placeholder => OnCommaButtonClick?.Invoke(placeholder) }
        }
    };

    public static readonly Dictionary<char, Action<string>> KeyboardKeyPressEvents = new() {
        { '0', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '1', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '2', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '3', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '4', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '5', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '6', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '7', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '8', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '9', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { ',', placeholder => OnCommaButtonClick?.Invoke(placeholder) },
        { '.', placeholder => OnCommaButtonClick?.Invoke(placeholder) },
        { (char)Keys.Back, placeholder => OnClearEntryButtonClick?.Invoke(placeholder) },
    };
}