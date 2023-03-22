using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcKeyboard;

public sealed class AdvanceCalcKeyboard : TableLayoutPanel
{

    private List<List<Control>> keyboard;


    public AdvanceCalcKeyboard() {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        

        keyboard = new();

        AdvanceCalcKeyboardEvents.KeyboardClickEvents.ForEach(buttonRowClickEvents => {
            List<Control> buttonRow = new();

            foreach (KeyValuePair<string, Action<string>> buttonClickEvent in buttonRowClickEvents) {
                Button button = new() {
                    Size = new Size(260, 90),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    ForeColor = Color.FromArgb(10, 187, 255),
                    BackColor = Color.FromArgb(45, 45, 48),
                    Text = buttonClickEvent.Key
                };

                button.Click += (_, _) => {
                    buttonClickEvent.Value.Invoke(buttonClickEvent.Key);
                };

                buttonRow.Add(button);
            }

            keyboard.Add(buttonRow);
        });
        
        TableDataManager.SetSymmetricalData(this, keyboard);
    }
}