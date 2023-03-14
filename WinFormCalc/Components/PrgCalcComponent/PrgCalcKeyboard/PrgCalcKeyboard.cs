using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcKeyboard;

public sealed class PrgCalcKeyboard : TableLayoutPanel
{

    List<List<Control>> keyboard;


    public PrgCalcKeyboard() {
        InitializeComponent();

        Size = new Size(1280, 590);
        BackColor = Color.DeepPink;

        TableDataManager.SetSymmetricalData(this, keyboard);
    }


    private void InitializeComponent()
    {
        keyboard = new();

        PrgCalcKeyboardEvents.KeyboardClickEvents.ForEach(buttonRowClickEvents => {
            List<Control> buttonRow = new();

            foreach (var buttonClickEvent in buttonRowClickEvents) {
                Button button = new Button {
                    Size = new Size(260, 100),
                    Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    ForeColor = Color.Black,
                    Text = buttonClickEvent.Key
                };

                button.Click += (_, _) => {
                    buttonClickEvent.Value.Invoke(buttonClickEvent.Key);
                };

                buttonRow.Add(button);
            }
            keyboard.Add(buttonRow);
        });
    }
}