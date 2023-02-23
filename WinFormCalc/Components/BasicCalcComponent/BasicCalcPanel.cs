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

        private Label example;

        private Label number;


        public BasicCalcPanel()
        {
            InitializeComponent();

            MinimumSize = new Size(320, 445);
            MaximumSize = new Size(1280, 890);
            BackColor= Color.Pink;

            List<Control> rows = new List<Control> { example, number, keyboard };
            TableDataManager.setAsymmetricalRows(this, rows);
        }


        private void InitializeComponent()
        {
            example = new Label() {
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
                ForeColor = Color.Gray,
                Size = new Size(1280, 60),
                TextAlign = ContentAlignment.MiddleRight,
                Text = "example",
                BackColor = Color.DeepPink
            };

            number = new Label() {
                Size = new Size(1280, 130),
                Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleRight,
                Text = "number",
                BackColor = Color.HotPink
            };

            keyboard = new BasicCalcKeyboard();

            /*numpad = new TableLayoutPanel {
                Size = new Size(3200, 3500),
                MinimumSize = new Size(320, 350),
                BackColor = Color.DeepPink
            };*/

            /*for (int i = 0; i < numpad.ColumnCount; i++) {
                numpad.ColumnStyles.Add(new ColumnStyle(
                    SizeType.Percent,
                    100f / numpad.ColumnCount
                ));
            }

            for (int i = 0; i < numpad.RowCount; i++) {
                numpad.RowStyles.Add(new RowStyle(
                    SizeType.Percent,
                    100f / numpad.RowCount
                ));
            }*/

            //tableLayoutPanel.TabIndex = 3;
            //this.tableLayoutPanel.Controls.Add(this.button22, 0, 5);
            //tableLayoutPanel.Location = new System.Drawing.Point(601, 131);
        }
    }
}
