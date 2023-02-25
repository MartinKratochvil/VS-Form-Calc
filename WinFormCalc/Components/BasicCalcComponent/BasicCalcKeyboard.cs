using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.BasicCalcComponent
{
    public sealed class BasicCalcKeyboard : TableLayoutPanel
    {

        List<List<Control>> keyboard;


        public BasicCalcKeyboard() {
            InitializeComponent();

            Size = new Size(1280, 700);
            BackColor = Color.DeepPink;

            TableDataManager.SetSymmetricalData(this, keyboard);
        }


        private void InitializeComponent()
        {
            keyboard = new List<List<Control>>();

            BasicCalcKeyboardEvents.KeyboardClickEvents.ForEach(buttonRowClickEvents => {
                List<Control> buttonRow = new List<Control>();
                
                foreach (var buttonClickEvent in buttonRowClickEvents) {
                    Button button = new Button() {
                        Size = new Size(320, 120),
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
