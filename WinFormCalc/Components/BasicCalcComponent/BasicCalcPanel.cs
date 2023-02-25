using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc.Components.BasicCalcComponent
{
    public class BasicCalcPanel : TableLayoutPanel
    {

        private BasicCalcKeyboard keyboard;

        private Label exampleLabel;

        private Label numberLabel;

        private BasicCalcManager basicCalcManager;


        public BasicCalcPanel()
        {
            InitializeComponent();

            MinimumSize = new Size(320, 445);
            MaximumSize = new Size(1280, 890);
            BackColor= Color.Pink;

            basicCalcManager = new BasicCalcManager();
            basicCalcManager.OnExampleLabelUpdate += ExampleLabelUpdate;
            basicCalcManager.OnNumberLabelUpdate += NumberLabelUpdate;

            List<Control> rows = new List<Control> { exampleLabel, numberLabel, keyboard };
            TableDataManager.SetAsymmetricalRows(this, rows);
        }


        private void InitializeComponent()
        {
            exampleLabel = new Label() {
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
                ForeColor = Color.Gray,
                Size = new Size(1280, 60),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.DeepPink
            };

            numberLabel = new Label() {
                Size = new Size(1280, 130),
                Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleRight,
                Text = "0",
                BackColor = Color.HotPink
            };

            keyboard = new BasicCalcKeyboard();
        }


        private void ExampleLabelUpdate(string message)
        {
            exampleLabel.Text = message;
        }
        
        
        private void NumberLabelUpdate(string message)
        {
            if (message == string.Empty) {
                numberLabel.Text = "0";
                return;
            }

            if (message[message.Length - 1] == '.') {
                numberLabel.Text = message + '0';
                return;                
            }

            numberLabel.Text = message;
        }
    }
}
