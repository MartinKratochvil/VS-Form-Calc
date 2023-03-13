using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel
{
    public sealed class ConvertorPanel<T> : TableLayoutPanel where T : Enum
    {

        private Label inputLabel;

        private Label outputLabel;

        private Panel inputTypePanel;

        private Panel outputTypePanel;

        private ComboBox inputTypeComboBox;

        private ComboBox outputTypeComboBox;

        private ConvertorKeyboard.ConvertorKeyboard keyboard;

        private readonly ConvertorManager<T> manager;


        public ConvertorPanel()
        {
            InitializeComponent();

            manager = new ConvertorManager<T>();
            manager.OnInputLabelUpdate += InputLabelUpdate;
            manager.OnOutputLabelUpdate += OutputLabelUpdate;
            
            SetData(ConvertorDataHandler.Handle<T>());
        }


        private void InitializeComponent()
        {
            MinimumSize = new Size(320, 445);
            MaximumSize = new Size(1280, 890);
            BackColor= Color.Pink;
            Resize += PanelResize;

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
            inputTypeComboBox.SelectedValueChanged += InputTypeChanged;
            inputTypePanel.Controls.Add(inputTypeComboBox);

            outputTypeComboBox = new ComboBox {
                Size = new Size(314,0),
                Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.HotPink
            };
            outputTypeComboBox.SelectedValueChanged += OutputTypeChanged;
            outputTypePanel.Controls.Add(outputTypeComboBox);

            keyboard = new ConvertorKeyboard.ConvertorKeyboard();
            
            List<Control> rows = new List<Control> { inputLabel, inputTypePanel, outputLabel, outputTypePanel, keyboard };
            TableDataManager.SetAsymmetricalRows(this, rows);
        }

        public void Clear()
        {
            manager.Clear();
        }


        private void SetData(List<Enum> data)
        {
            if (data == null) {
                return;
            }

            inputTypeComboBox.DataSource = data.ToArray();
            outputTypeComboBox.DataSource = data.ToArray();
        }
        
        private void PanelResize(object sender, EventArgs args)
        {
            manager.UpdateInputLabel();
        }


        private void InputTypeChanged(object sender, EventArgs args)
        {
            T type = (T)inputTypeComboBox.SelectedValue;
            manager.ChangeInputType(type);
        }
        
        
        private void OutputTypeChanged(object sender, EventArgs args)
        {
            T type = (T)outputTypeComboBox.SelectedValue;
            manager.ChangeOutputType(type);
        }


        private void InputLabelUpdate(string message)
        {
            if (message[message.Length - 1] == ',') {
                inputLabel.Text = TrimTextToSize(message + '0', Width / 18);
                return;
            }

            inputLabel.Text = TrimTextToSize(message, Width / 18);
        }


        private void OutputLabelUpdate(string message)
        {
            outputLabel.Text = TrimTextToSize(message, Width / 18);
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