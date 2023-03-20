using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.BasicCalcComponent.BasicCalcPanel;

public sealed class BasicCalcPanel : TableLayoutPanel
{

    private Label exampleLabel;

    private Label numberLabel;

    private BasicCalcKeyboard.BasicCalcKeyboard keyboard;

    private readonly BasicCalcManager manager;


    public BasicCalcPanel()
    {
        InitializeComponent();

        manager = new BasicCalcManager();
        manager.OnExampleLabelUpdate += ExampleLabelUpdate;
        manager.OnNumberLabelUpdate += NumberLabelUpdate;
    }


    private void InitializeComponent()
    {
        
        Resize += PanelResize;

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

        keyboard = new() {
            Size = new Size(1280, 700),
            BackColor = Color.FromArgb(37, 37, 38)
        };

        List<Control> rows = new() { exampleLabel, numberLabel, keyboard };
        TableDataManager.SetAsymmetricalRows(this, rows);
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