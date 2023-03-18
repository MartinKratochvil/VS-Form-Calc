using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcPanel
{
    public sealed class AdvanceCalcPanel : Panel
    {

        private TableLayoutPanel contentPanel;

        private Label exampleLabel;

        private Label numberLabel;

        private Button trigonometryButton;

        private AdvanceCalcModal.AdvanceCalcModal trigonometryModal;

        private AdvanceCalcKeyboard.AdvanceCalcKeyboard keyboard;

        private readonly AdvanceCalcManager manager;


        public AdvanceCalcPanel()
        {
            InitializeComponent();

            manager = new AdvanceCalcManager();
            manager.OnExampleLabelUpdate += ExampleLabelUpdate;
            manager.OnNumberLabelUpdate += NumberLabelUpdate;
            MessageBox.Show(keyboard.Location.X + " " + keyboard.Location.Y);
        }


        private void InitializeComponent()
        {
            
            Resize += PanelResize;

            trigonometryModal = new() {
                MinimumSize = new Size(300, 100),
                MaximumSize = new Size(1200, 200),
                BackColor = Color.HotPink,
                Visible = false
            };
            Controls.Add(trigonometryModal);

            contentPanel = new() {
                Size = new Size(320, 445),
                BackColor= Color.Pink
            };
            Controls.Add(contentPanel);

            exampleLabel = new() {
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
                ForeColor = Color.Gray,
                MaximumSize = new Size(1280,60),
                Size = new Size(1280, 60),
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.HotPink,
            };

            numberLabel = new() {
                Size = new Size(1280, 130),
                Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleRight,
                BackColor = Color.DeepPink,
                Text = "0"
            };

            trigonometryButton = new() {
                Size = new Size(1280, 90),
                Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                BackColor = Color.HotPink,
                Text = "Trigonometrie"
            };
            trigonometryButton.Click += (_, _) => trigonometryModal.Visible = !trigonometryModal.Visible;

            keyboard = new() {
                Size = new Size(1280, 600),
                BackColor = Color.DeepPink
            };

            List<Control> rows = new() { exampleLabel, numberLabel, trigonometryButton, keyboard };
            TableDataManager.SetAsymmetricalRows(contentPanel, rows);
        }


        private void PanelResize(object sender, EventArgs args)
        {
            contentPanel.Size = Size;
            ModalResize();

            manager.UpdateExampleLabel();
            manager.UpdateNumberLabel();
        }


        private void ModalResize()
        {
            trigonometryModal.Location = keyboard.Location with { X = 0 };
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