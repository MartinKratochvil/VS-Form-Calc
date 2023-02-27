using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcPanel
{
    public sealed class AdvanceCalcPanel : TableLayoutPanel
    {
 
        private Label exampleLabel;

        private Label numberLabel;

        private Button trigonometryButton;

        private AdvanceCalcKeyboard.AdvanceCalcKeyboard keyboard;

        private readonly AdvanceCalcManager calcManager;


        public AdvanceCalcPanel()
        {
            InitializeComponent();

            MinimumSize = new Size(320, 445);
            MaximumSize = new Size(1280, 890);
            BackColor= Color.Pink;
            Resize += PanelResize;

            calcManager = new AdvanceCalcManager();
            calcManager.OnExampleLabelUpdate += ExampleLabelUpdate;
            calcManager.OnNumberLabelUpdate += NumberLabelUpdate;

            List<Control> rows = new List<Control> { exampleLabel, numberLabel, trigonometryButton, keyboard };
            TableDataManager.SetAsymmetricalRows(this, rows);
        }


        private void InitializeComponent()
        {
            exampleLabel = new Label{
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
                ForeColor = Color.Gray,
                MaximumSize = new Size(1280,60),
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

            trigonometryButton = new Button {
                Size = new Size(1280, 90),
                Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                BackColor = Color.HotPink,
                Text = "Trigonometrie"
            };

            keyboard = new AdvanceCalcKeyboard.AdvanceCalcKeyboard();
        }


        private void PanelResize(object sender, EventArgs args)
        {
            calcManager.UpdateExampleLabel();
            calcManager.UpdateNumberLabel();
        }


        private void ExampleLabelUpdate(string message)
        {
            exampleLabel.Text = TrimTextToSize(message, Width / 11);
        }
        
        
        private void NumberLabelUpdate(string message)
        {
            if (message[message.Length - 1] == '.') {
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