using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel
{
    public sealed class ConvertorPanel : TableLayoutPanel
    {

        private Label inputLabel;

        private Label outputLabel;

        private Panel inputTypePanel;

        private Panel outputTypePanel;

        private ComboBox inputTypeComboBox;

        private ComboBox outputTypeComboBox;

        private ConvertorKeyboard.ConvertorKeyboard keyboard;

        private readonly ConvertorManager manager;


        public ConvertorPanel()
        {
            InitializeComponent();

            MinimumSize = new Size(320, 445);
            MaximumSize = new Size(1280, 890);
            BackColor= Color.Pink;

            manager = new ConvertorManager();
            //manager.OnExampleLabelUpdate += ExampleLabelUpdate;
            //manager.OnNumberLabelUpdate += NumberLabelUpdate;

            List<Control> rows = new List<Control> { inputLabel, inputTypePanel, outputLabel, outputTypePanel, keyboard };
            TableDataManager.SetAsymmetricalRows(this, rows);
        }


        private void InitializeComponent()
        {
            inputLabel = new Label {
                Size = new Size(1280, 115),
                Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.DeepPink,
                Text = "0"
            };

            outputLabel = new Label{
                Size = new Size(1280, 115),
                Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.DeepPink,
                Text = "0"
            };

            inputTypePanel = new Panel {
                Size = new Size(1280, 115)
            };
            
            outputTypePanel = new Panel {
                Size = new Size(1280, 115)
            };
            
            inputTypeComboBox = new ComboBox {
                Size = new Size(314, 0),
                Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.HotPink
            };
            inputTypePanel.Controls.Add(inputTypeComboBox);

            outputTypeComboBox = new ComboBox {
                Size = new Size(314,0),
                Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.HotPink
            };
            outputTypePanel.Controls.Add(outputTypeComboBox);

            keyboard = new ConvertorKeyboard.ConvertorKeyboard();
        }
    }
}