using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcKeyboard;

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
            { "x²", placeholder => OnSqrButtonClick?.Invoke(placeholder) },
            { "x³", placeholder => OnCubeButtonClick?.Invoke(placeholder) },
            { "√x", placeholder => OnSqrtButtonClick?.Invoke(placeholder) },
            { "∛x", placeholder => OnCubeRootButtonClick?.Invoke(placeholder) },
            { "xⁿ", placeholder => OnPowButtonClick?.Invoke(placeholder) },
            { "ⁿ√x", placeholder => OnYRootButtonClick?.Invoke(placeholder) },
            { "log", placeholder => OnLogButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "eⁿ", placeholder => OnEulPowButtonClick?.Invoke(placeholder) },
            { "π", placeholder => OnPiButtonClick?.Invoke(placeholder) },
            { "(", placeholder => OnOpenBracketButtonClick?.Invoke(placeholder) },
            { "7", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "4", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "1", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "ln", placeholder => OnLnButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "CE", placeholder => OnClearEntryButtonClick?.Invoke(placeholder) },
            { "e", placeholder => OnEulButtonClick?.Invoke(placeholder) },
            { ")", placeholder => OnCloseBracketButtonClick?.Invoke(placeholder) },
            { "8", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "5", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "2", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "0", placeholder => OnNumpadButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "C", placeholder => OnClearButtonClick?.Invoke(placeholder) },
            { "|x|", placeholder => OnAbsButtonClick?.Invoke(placeholder) },
            { "n!", placeholder => OnFactButtonClick?.Invoke(placeholder) },
            { "9", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "6", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { "3", placeholder => OnNumpadButtonClick?.Invoke(placeholder) },
            { ",", placeholder => OnCommaButtonClick?.Invoke(placeholder) }
        },
        new() {
            { "Back", placeholder => OnBackButtonClick?.Invoke(placeholder) },
            { "%", placeholder => OnModuloButtonClick?.Invoke(placeholder) },
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
        { '+', placeholder => OnPlusButtonClick?.Invoke(placeholder) },
        { '-', placeholder => OnMinusButtonClick?.Invoke(placeholder) },
        { '*', placeholder => OnMultiplyButtonClick?.Invoke(placeholder) },
        { '/', placeholder => OnDivideButtonClick?.Invoke(placeholder) },
        { '%', placeholder => OnModuloButtonClick?.Invoke(placeholder) },
        { '!', placeholder => OnFactButtonClick?.Invoke(placeholder) },
        { '|', placeholder => OnAbsButtonClick?.Invoke(placeholder) },
        { '^', placeholder => OnPowButtonClick?.Invoke(placeholder) },
        { ',', placeholder => OnCommaButtonClick?.Invoke(placeholder) },
        { '.', placeholder => OnCommaButtonClick?.Invoke(placeholder) },
        { 'p', placeholder => OnPiButtonClick?.Invoke(placeholder) },
        { 'e', placeholder => OnEulButtonClick?.Invoke(placeholder) },
        { 'l', placeholder => OnLogButtonClick?.Invoke(placeholder) },
        { '(', placeholder => OnOpenBracketButtonClick?.Invoke(placeholder) },
        { ')', placeholder => OnCloseBracketButtonClick?.Invoke(placeholder) },
        { '=', placeholder => OnEqualsButtonClick?.Invoke(placeholder) },
        { (char)Keys.Back, placeholder => OnBackButtonClick?.Invoke(placeholder) }
    };
}