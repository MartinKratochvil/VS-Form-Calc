using System;
using System.Collections.Generic;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcModal;

public class PrgCalcModalEvents
{
    public delegate void ButtonClick();

    public static event ButtonClick OnAndButtonClick;
    public static event ButtonClick OnOrButtonClick;
    public static event ButtonClick OnNandButtonClick;
    public static event ButtonClick OnNorButtonClick;
    public static event ButtonClick OnXorButtonClick;
    public static event ButtonClick OnXnorButtonClick;

    public static readonly List<Dictionary<string, Action>> ModalFuncClickEvents = new() {
        new() {
            { "And", () => OnAndButtonClick?.Invoke() },
            { "Or⁻¹", () => OnOrButtonClick?.Invoke() }
        },
        new() {
            { "Nand", () => OnNandButtonClick?.Invoke() },
            { "Nor", () => OnNorButtonClick?.Invoke() }
        },
        new() {
            { "Xor", () => OnXorButtonClick?.Invoke() },
            { "Xnor", () => OnXnorButtonClick?.Invoke() }
        }
    };
}