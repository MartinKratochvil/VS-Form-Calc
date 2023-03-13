using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcPanel
{
    public sealed class PrgCalcPanel : TableLayoutPanel
    {
 
        private Label exampleLabel;

        private Label numberLabel;

        private PrgCalcFunctionPanel.PrgCalcFunctionPanel functionPanel;

        private PrgCalcKeyboard.PrgCalcKeyboard keyboard;

        private readonly PrgCalcManager manager;


        public PrgCalcPanel()
        {
            InitializeComponent();

            MinimumSize = new Size(320, 445);
            MaximumSize = new Size(1280, 890);
            BackColor= Color.Pink;
            Resize += PanelResize;

            manager = new PrgCalcManager();
            manager.OnExampleLabelUpdate += ExampleLabelUpdate;
            manager.OnNumberLabelUpdate += NumberLabelUpdate;
            manager.OnNumberTypeButtonUpdate += functionPanel.NumberTypeButtonUpdate;

            List<Control> rows = new List<Control> { exampleLabel, numberLabel, functionPanel, keyboard };
            TableDataManager.SetAsymmetricalRows(this, rows);
        }


        private void InitializeComponent()
        {
            exampleLabel = new Label{
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
                ForeColor = Color.Gray,
                Size = new Size(1280, 60),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.HotPink,
            };

            numberLabel = new Label {
                Size = new Size(1280, 130),
                Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.DeepPink,
                Text = "0"
            };

            functionPanel = new PrgCalcFunctionPanel.PrgCalcFunctionPanel();            
            keyboard = new PrgCalcKeyboard.PrgCalcKeyboard();
        }


        private void PanelResize(object sender, EventArgs args)
        {
            manager.UpdateExampleLabel();
            manager.UpdateNumberLabel();
        }


        private void ExampleLabelUpdate(string message)
        {
            exampleLabel.Text = TrimTextToSize(message, Width / 11);
        }
        
        
        private void NumberLabelUpdate(string message)
        {
            if (message[message.Length - 1] == ',') {
                numberLabel.Text = TrimTextToSize(message + '0', Width / 30);
                return;
            }

            numberLabel.Text = TrimTextToSize(message, Width / 30);
        }


        private string TrimTextToSize(string text, int maxSize)
        {
            if (text.Length <= maxSize) {
                return text;
            }

            return text.Substring(text.Length - maxSize);
        }
    }
}