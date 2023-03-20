using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard;

public class ConvertorKeyboard : TableLayoutPanel
{

    private List<List<Control>> keyboard;


    public ConvertorKeyboard() {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        Size = new Size(1280, 400);
        BackColor = Color.DeepPink;

        keyboard = new();

        ConvertorKeyboardEvents.KeyboardClickEvents.ForEach(buttonRowClickEvents => {
            List<Control> buttonRow = new List<Control>();

            foreach (KeyValuePair<string, Action<string>> buttonClickEvent in buttonRowClickEvents) {
                Button button = new Button {
                    Size = new Size(430, 100),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
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