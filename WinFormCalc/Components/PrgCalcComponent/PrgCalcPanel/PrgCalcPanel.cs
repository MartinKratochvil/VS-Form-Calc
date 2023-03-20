using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcFunctionPanel;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcPanel;

public sealed class PrgCalcPanel : Panel
{
 
    private TableLayoutPanel contentPanel;

    private Label exampleLabel;

    private Label numberLabel;

    private PrgCalcFunctionPanel.PrgCalcFunctionPanel functionPanel;

    private PrgCalcModal.PrgCalcModal functionModal;

    private PrgCalcKeyboard.PrgCalcKeyboard keyboard;

    private readonly PrgCalcManager manager;


    public PrgCalcPanel()
    {
        InitializeComponent();

        manager = new PrgCalcManager();
        manager.OnExampleLabelUpdate += ExampleLabelUpdate;
        manager.OnNumberLabelUpdate += NumberLabelUpdate;
        manager.OnNumberTypeButtonUpdate += functionPanel.NumberTypeButtonUpdate;

        PrgCalcFunctionPanelEvents.OnLogicalFunctionButtonClick += _ => functionModal.Visible = !functionModal.Visible;
    }


    private void InitializeComponent()
    {
        Resize += PanelResize;

        functionModal = new() {
            MinimumSize = new Size(225, 100),
            MaximumSize = new Size(900, 200),
            BackColor = Color.HotPink,
            Visible = false
        };
        Controls.Add(functionModal);
        
        contentPanel = new() {
            Size = new Size(320, 445),
            BackColor= Color.Pink
        };
        Controls.Add(contentPanel);

        exampleLabel = new Label {
            Size = new Size(1280, 60),
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238),
            TextAlign = ContentAlignment.MiddleRight,
            ForeColor = Color.Gray,
            BackColor = Color.HotPink,
        };

        numberLabel = new Label {
            Size = new Size(1280, 130),
            Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 238),
            TextAlign = ContentAlignment.MiddleRight,
            ForeColor = Color.Black,
            BackColor = Color.DeepPink,
            Text = "0"
        };

        functionPanel = new PrgCalcFunctionPanel.PrgCalcFunctionPanel();            
        keyboard = new PrgCalcKeyboard.PrgCalcKeyboard();

        List<Control> rows = new() { exampleLabel, numberLabel, functionPanel, keyboard };
        TableDataManager.SetAsymmetricalRows(contentPanel, rows);
    }


    private void PanelResize(object sender, EventArgs args)
    {
        contentPanel.Size = Size;
        functionModal.Location = keyboard.Location with { X = 0 };
        
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