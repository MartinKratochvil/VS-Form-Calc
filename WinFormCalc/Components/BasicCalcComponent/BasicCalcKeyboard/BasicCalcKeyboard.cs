using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.BasicCalcComponent.BasicCalcKeyboard;

public sealed class BasicCalcKeyboard : TableLayoutPanel
{

    private List<List<Control>> keyboard;


    public BasicCalcKeyboard() {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        Size = new Size(1280, 700);
        BackColor = Color.DeepPink;

        keyboard = new List<List<Control>>();

        BasicCalcKeyboardEvents.KeyboardClickEvents.ForEach(buttonRowClickEvents => {
            List<Control> buttonRow = new List<Control>();

            foreach (KeyValuePair<string, Action<string>> buttonClickEvent in buttonRowClickEvents) {
                Button button = new Button {
                    Size = new Size(320, 120),
                    Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    ForeColor = Color.Black,
                    Text = buttonClickEvent.Key
                };

                button.Click += (_, _) =>
                        buttonClickEvent.Value.Invoke(buttonClickEvent.Key)
                    ;

                buttonRow.Add(button);
            }
            keyboard.Add(buttonRow);
        });

        TableDataManager.SetSymmetricalData(this, keyboard);
    }
}