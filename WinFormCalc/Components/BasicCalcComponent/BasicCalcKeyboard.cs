using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            BasicCalcKeyboardEvents.KeyboardClickEvents.ForEach(eventRow => {
                List<Control> buttonRow = new List<Control>();
                
                foreach (var keyValuePair in eventRow) {
                    Button button = new Button() {
                        Size = new Size(320, 120),
                        Text = keyValuePair.Key
                    };

                    button.Click +=
                        (sender, e) =>
                        keyValuePair.Value.Invoke(keyValuePair.Key)
                    ;
                    
                    buttonRow.Add(button);
                }
                keyboard.Add(buttonRow);
            });
        }
    }
}
