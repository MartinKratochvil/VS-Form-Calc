using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcModal;

public static class AdvanceCalcModalEvents
{

    public delegate void ButtonClick();

    public static event ButtonClick OnSinButtonClick;

    public static event ButtonClick OnCosinButtonClick;

    public static event ButtonClick OnTanButtonClick;

    public static event ButtonClick OnSecButtonClick;

    public static event ButtonClick OnCosecButtonClick;

    public static event ButtonClick OnCotanButtonClick;

    public static event ButtonClick OnArcsinButtonClick;

    public static event ButtonClick OnArccosinButtonClick;

    public static event ButtonClick OnArctanButtonClick;

    public static event ButtonClick OnArcsecButtonClick;

    public static event ButtonClick OnArccosecButtonClick;

    public static event ButtonClick OnArccotanButtonClick;

    public static event ButtonClick OnHSinButtonClick;

    public static event ButtonClick OnHCosinButtonClick;

    public static event ButtonClick OnHTanButtonClick;

    public static event ButtonClick OnHSecButtonClick;

    public static event ButtonClick OnHCosecButtonClick;

    public static event ButtonClick OnHCotanButtonClick;

    public static event ButtonClick OnHArcsinButtonClick;

    public static event ButtonClick OnHArccosinButtonClick;

    public static event ButtonClick OnHArctanButtonClick;

    public static event ButtonClick OnHArcsecButtonClick;

    public static event ButtonClick OnHArccosecButtonClick;

    public static event ButtonClick OnHArccotanButtonClick;

    public static readonly List<Dictionary<string, Action>> ModalClickEvents = new() {
        new() {
            { "Sin", () => OnSinButtonClick?.Invoke() },
            { "Sec", () => OnSecButtonClick?.Invoke() }
        },
        new() {
            { "Cos", () => OnCosinButtonClick?.Invoke() },
            { "Csc", () => OnCosecButtonClick?.Invoke() },
        },
        new() {
            { "Tan", () => OnTanButtonClick?.Invoke() },
            { "Cot", () => OnCotanButtonClick?.Invoke() }
        }
    };

    public static readonly List<Dictionary<string, Action>> ModalArcClickEvents = new() {
        new() {
            { "Sin⁻¹", () => OnArcsinButtonClick?.Invoke() },
            { "Sec⁻¹", () => OnArcsecButtonClick?.Invoke() }
        },
        new() {
            { "Cos⁻¹", () => OnArccosinButtonClick?.Invoke() },
            { "Csc⁻¹", () => OnArccosecButtonClick?.Invoke() }
        },
        new() {
            { "Tan⁻¹", () => OnArctanButtonClick?.Invoke() },
            { "Cot⁻¹", () => OnArccotanButtonClick?.Invoke() }
        }
    };

    public static readonly List<Dictionary<string, Action>> ModalHypClickEvents = new() {
        new() {
            { "Sinh", () => OnHSinButtonClick?.Invoke() },
            { "Sech", () => OnHSecButtonClick?.Invoke() }
        },
        new() {
            { "Cosh", () => OnHCosinButtonClick?.Invoke() },
            { "Csch", () => OnHCosecButtonClick?.Invoke() }
        },
        new() {
            { "Tanh", () => OnHTanButtonClick?.Invoke() },
            { "Coth", () => OnHCotanButtonClick?.Invoke() }
        }
    };
    
    public static readonly List<Dictionary<string, Action>> ModalHypArcClickEvents = new() {
        new() {
            {"Sinh⁻¹", () => OnHArcsinButtonClick?.Invoke() },
            {"Sech⁻¹", () => OnHArcsecButtonClick?.Invoke() }
        },
        new() {
            {"Cosh⁻¹", () => OnHArccosinButtonClick?.Invoke() },
            {"Csch⁻¹", () => OnHArccosecButtonClick?.Invoke() }
        },
        new() {
            {"Tanh⁻¹", () => OnHArctanButtonClick?.Invoke() },
            {"Coth⁻¹", () => OnHArccotanButtonClick?.Invoke() }
        }
    };
}