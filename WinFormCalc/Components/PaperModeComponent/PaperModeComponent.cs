using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WinFormCalc.Calculators.AdvanceCalculator;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

namespace WinFormCalc.Components.PaperModeComponent;

public sealed class PaperModeComponent : TextBox
{

    public PaperModeComponent()
    {
        Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
        Multiline = true;
        KeyPress += PaperModeComponent_KeyPress;
    }


    private void PaperModeComponent_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) {
            Calculate();
        }
    }


    private void Calculate()
    {
        if (SelectionStart <= 0 || Text[SelectionStart - 1] != '=') {
            return;
        }

        try {
            AdvanceCalculator calc = new AdvanceCalculator(
                ExampleConvertor.Convert(GetExample()),
                new AdvanceNumber(AdvancePrimeOper.Plus, new List<Enum>())
            );

            string result = calc.GetResult();
            int cursor = SelectionStart;

            Text = Text.Insert(SelectionStart, Environment.NewLine + "= " + result);
            SelectionStart += cursor + result.Length + 4;
        }
        catch (Exception e) {
            MessageBox.Show("Error" + e.Message);
        }

            
    }


    private string GetExample()
    {
        int start = IndexOfStartLine();
        string example = Text.Substring(start, SelectionStart - start);

        return new string(example
            .Where(c => c != ' ')
            .ToArray()
        );
    }


    private int IndexOfStartLine()
    {
        for (int i = SelectionStart - 2; i > 0; i--) {
            if (Text.Substring(i, 2) == Environment.NewLine) {
                return i + 2;
            }
        }

        return 0;
    }
}