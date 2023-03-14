using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcKeyboard;

public static class PrgCalcKeyboardEvents
{

    public delegate void ButtonClick(string placeholder);
        
    public static event ButtonClick OnNumpadButtonClick;

    public static event ButtonClick OnPlusButtonClick;

    public static event ButtonClick OnMinusButtonClick;

    public static event ButtonClick OnMultiplyButtonClick;

    public static event ButtonClick OnDivideButtonClick;

    public static event ButtonClick OnModuloButtonClick;

    public static event ButtonClick OnLeftShiftButtonClick;

    public static event ButtonClick OnRightShiftButtonClick;

    public static event ButtonClick OnOpenBracketButtonClick;

    public static event ButtonClick OnCloseBracketButtonClick;

    public static event ButtonClick OnCommaButtonClick;

    public static event ButtonClick OnClearButtonClick;

    public static event ButtonClick OnClearEntryButtonClick;

    public static event ButtonClick OnBackButtonClick;

    public static event ButtonClick OnEqualsButtonClick;

    public static readonly List<Dictionary<string, Action<string>>> KeyboardClickEvents = new() {
        new() {
            { "<<", placeholder => OnLeftShiftButtonClick?.Invoke(placeholder) },
            { "A", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "B", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "C", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "D", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "E", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        },
        new() {
            { ">>", placeholder => OnRightShiftButtonClick?.Invoke(placeholder) },
            { "(", placeholder => OnOpenBracketButtonClick?.Invoke(placeholder) },
            { "7", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "4", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "1", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "F", placeholder => OnNumpadButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "CE", placeholder => OnClearEntryButtonClick?.Invoke(placeholder) },
            { ")", placeholder => OnCloseBracketButtonClick?.Invoke(placeholder) },
            { "8", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "5", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "2", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "0", placeholder => OnNumpadButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "C", placeholder => OnClearButtonClick?.Invoke(placeholder) },
            { "%", placeholder => OnModuloButtonClick?.Invoke(placeholder) },
            { "9", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "6", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "3", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { ",", placeholder => OnCommaButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "Back", placeholder => OnBackButtonClick?.Invoke(placeholder) },
            { "/", placeholder => OnDivideButtonClick?.Invoke(placeholder) },
            { "*", placeholder => OnMultiplyButtonClick?.Invoke(placeholder) },
            { "-", placeholder => OnMinusButtonClick?.Invoke(placeholder) },
            { "+", placeholder => OnPlusButtonClick?.Invoke(placeholder) },
            { "=", placeholder => OnEqualsButtonClick?.Invoke(placeholder) }
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
        { 'a', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { 'b', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { 'c', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { 'd', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { 'e', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { 'f', placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
        { '+', placeholder => OnPlusButtonClick?.Invoke(placeholder) },
        { '-', placeholder => OnMinusButtonClick?.Invoke(placeholder) },
        { '*', placeholder => OnMultiplyButtonClick?.Invoke(placeholder) },
        { '/', placeholder => OnDivideButtonClick?.Invoke(placeholder) },
        { '%', placeholder => OnModuloButtonClick?.Invoke(placeholder) },
        { ',', placeholder => OnCommaButtonClick?.Invoke(placeholder) },
        { '.', placeholder => OnCommaButtonClick?.Invoke(placeholder) },
        { '(', placeholder => OnOpenBracketButtonClick?.Invoke(placeholder) },
        { ')', placeholder => OnCloseBracketButtonClick?.Invoke(placeholder) },
        { '<', placeholder => OnLeftShiftButtonClick?.Invoke(placeholder) },
        { '>', placeholder => OnRightShiftButtonClick?.Invoke(placeholder) },
        { '=', placeholder => OnEqualsButtonClick?.Invoke(placeholder) },
        { (char)Keys.Back, placeholder => OnBackButtonClick?.Invoke(placeholder) }
    };
}