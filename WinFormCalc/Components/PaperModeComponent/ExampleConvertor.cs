﻿using System;
using System.Collections.Generic;
using WinFormCalc.Calculators.AdvanceCalculator;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Components.PaperModeComponent;

public static class ExampleConvertor
{

    public static List<List<List<AdvanceNumber>>> Convert(string example)
    {
        List<List<List<AdvanceNumber>>> values = new();
        values.Add(new());
        values[0].Add(new());

        string payload = String.Empty;
        AdvancePrimeOper advancePrimeOper = AdvancePrimeOper.Plus;
        bool isNegative = false;
            
        int i = 0; 

        foreach (char c in example) {
            if (Char.IsDigit(c) || c == ',') {
                payload += c;

                continue;
            }

            if (c == '(' && payload == String.Empty) {
                values[i][values[i].Count - 1].Add(new AdvanceNumber(advancePrimeOper, new List<Enum>()));

                i++;

                if (i >= values.Count) {
                    values.Add(new());
                }

                values[i].Add(new());
                advancePrimeOper = AdvancePrimeOper.Plus;

                continue;
            }

            if (payload != String.Empty) {
                if (! Double.TryParse(payload, out double num)) {
                    throw new FormatException("Špatné číslo!!");
                }

                values[i][values[i].Count - 1].Add(new AdvanceNumber(
                    isNegative ? (num * -1) : num,
                    advancePrimeOper,
                    new()
                ));
            }

            payload = String.Empty;
            advancePrimeOper = AdvancePrimeOper.Plus;
            isNegative = false;

            switch (c) {
                case '+': break;
                case '-': {
                    isNegative = true;
                    break;
                }
                case '*': {
                    advancePrimeOper = AdvancePrimeOper.Multiply;
                    break;
                }
                case '/': {
                    advancePrimeOper = AdvancePrimeOper.Divide;
                    break;
                }
                case ')': {
                    i--;
                    break;
                }
                case '=': {
                    return values;
                }
                default: {
                    throw new FormatException("Špatný znak!!");
                }
            }
        }

        throw new Exception("No example!!");
    }
}