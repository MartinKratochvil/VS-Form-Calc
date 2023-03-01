using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard
{
    public class ConvertorKeyboard : TableLayoutPanel
    {

        List<List<Control>> keyboard;


        public ConvertorKeyboard() {
            InitializeComponent();

            Size = new Size(1280, 400);
            BackColor = Color.DeepPink;

            TableDataManager.SetSymmetricalData(this, keyboard);
        }


        private void InitializeComponent()
        {
            keyboard = new List<List<Control>>();

            ConvertorKeyboardEvents.KeyboardClickEvents.ForEach(buttonRowClickEvents => {
                List<Control> buttonRow = new List<Control>();

                foreach (var buttonClickEvent in buttonRowClickEvents) {
                    Button button = new Button {
                        Size = new Size(430, 100),
                        Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                        ForeColor = Color.Black,
                        Text = buttonClickEvent.Key
                    };

                    button.Click += (sender, e) => 
                        buttonClickEvent.Value(buttonClickEvent.Key)
                    ;

                    buttonRow.Add(button);
                }
                keyboard.Add(buttonRow);
            });
        }
    }
}