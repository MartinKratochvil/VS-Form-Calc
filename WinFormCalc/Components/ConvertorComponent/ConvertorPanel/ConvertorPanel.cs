using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel;

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
    }


    private void InitializeComponent()
    {
        Resize += PanelResize;

        inputLabel = new() {
            Size = new Size(1280, 115),
            Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.FromArgb(37, 37, 38),
            BackColor = Color.FromArgb(2, 132, 234),
            Text = "0"
        };

        outputLabel = new() {
            Size = new Size(1280, 115),
            Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
            TextAlign = ContentAlignment.MiddleLeft,
            ForeColor = Color.FromArgb(45, 45, 48),
            BackColor = Color.FromArgb(10, 157, 255),
            Text = "0"
        };

        inputTypePanel = new() {
            Size = new Size(1280, 115)
        };
            
        outputTypePanel = new() {
            Size = new Size(1280, 115)
        };
            
        inputTypeComboBox = new() {
            Size = new Size(314, 0),
            FlatStyle = FlatStyle.Flat,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.FromArgb(10, 187, 255),
            BackColor = Color.FromArgb(45, 45, 48)
        };
        inputTypeComboBox.SelectedValueChanged += InputTypeChanged;
        inputTypePanel.Controls.Add(inputTypeComboBox);

        outputTypeComboBox = new() {
            Size = new Size(314,0),
            FlatStyle = FlatStyle.Flat,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.FromArgb(10, 187, 255),
            BackColor = Color.FromArgb(45, 45, 48)
        };
        outputTypeComboBox.SelectedValueChanged += OutputTypeChanged;
        outputTypePanel.Controls.Add(outputTypeComboBox);

        keyboard = new() {
            Size = new Size(1280, 400)
        };
            
        List<Control> rows = new() { inputLabel, inputTypePanel, outputLabel, outputTypePanel, keyboard };
        TableDataManager.SetAsymmetricalRows(this, rows);
        
        SetData(ConvertorDataHandler.Handle<T>());
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