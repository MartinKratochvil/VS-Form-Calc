using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc.Components.BasicCalcComponent
{
    public class BasicCalcKeyboard : TableLayoutPanel
    {

        List<List<Control>> keyboard;

        public delegate void ButtonClick();

        public event ButtonClick OnPlusButtonClick;


        public BasicCalcKeyboard() {
            InitializeComponent();

            Size = new Size(1280, 700);
            BackColor = Color.DeepPink;

            TableDataManager.SetSymmetricalData(this, keyboard);
        }


        private void InitializeComponent()
        {
            keyboard = new List<List<Control>>();

            for(int i = 0; i < 4; i++) {
                List<Control> row = new List<Control>();
                
                for(int j = 0; j < 6; j++) {
                    Button button = new Button() {
                        Size = new Size(320, 120),
                        Text = "s"
                    };

                    button.Click += (object sender, EventArgs e) => OnPlusButtonClick.Invoke();

                    row.Add(button);
                }

                keyboard.Add(row);
            }
        }
    }
}
