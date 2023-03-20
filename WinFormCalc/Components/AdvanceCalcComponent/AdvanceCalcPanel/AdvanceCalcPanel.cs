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
        }


        private void InitializeComponent()
        {
            Resize += PanelResize;

            trigonometryModal = new() {
                MinimumSize = new Size(315, 100),
                MaximumSize = new Size(1260, 200),
                BackColor = Color.FromArgb(62, 62, 66),
                Visible = false
            };
            Controls.Add(trigonometryModal);

            contentPanel = new() {
                Size = new Size(320, 445)
            };
            Controls.Add(contentPanel);

            exampleLabel = new() {
                MaximumSize = new Size(1280,60),
                Size = new Size(1280, 60),
                Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.FromArgb(37, 37, 38),
                BackColor = Color.FromArgb(2, 132, 234)
            };

            numberLabel = new() {
                Size = new Size(1280, 130),
                Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 238),
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.FromArgb(45, 45, 48),
                BackColor = Color.FromArgb(10, 157, 255),
                Text = "0"
            };

            trigonometryButton = new() {
                Size = new Size(1280, 90),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.FromArgb(10, 187, 255),
                BackColor = Color.FromArgb(45, 45, 48),
                Text = "Trigonometrie"
            };
            trigonometryButton.Click += (_, _) => trigonometryModal.Visible = !trigonometryModal.Visible;

            keyboard = new() {
                Size = new Size(1280, 600)
            };

            List<Control> rows = new() { exampleLabel, numberLabel, trigonometryButton, keyboard };
            TableDataManager.SetAsymmetricalRows(contentPanel, rows);
        }


        private void PanelResize(object sender, EventArgs args)
        {
            contentPanel.Size = Size;
            trigonometryModal.Location = keyboard.Location with { X = 0 };

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