using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcFunctionPanel;

public class PrgCalcFunctionPanel : TableLayoutPanel
{

    private Button logicalFunctionButton;

    private Button numberTypeButton;
        

    public PrgCalcFunctionPanel()
    {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        logicalFunctionButton = new Button {
            Size = new Size(640, 110),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.FromArgb(10, 187, 255),
            BackColor = Color.FromArgb(45, 45, 48),
            Text = @"Logické funkce"
        };
        logicalFunctionButton.Click += PrgCalcFunctionPanelEvents.LogicalFunctionButtonClick;

        numberTypeButton = new Button {
            Size = new Size(640, 110),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.FromArgb(10, 187, 255),
            BackColor = Color.FromArgb(45, 45, 48),
            Text = @"Dec"
        };
        numberTypeButton.Click += PrgCalcFunctionPanelEvents.NumberTypeButtonClick;

        List<Control> columns = new() { logicalFunctionButton, numberTypeButton };
        TableDataManager.SetAsymmetricalColumns(this, columns);
    }


    public void NumberTypeButtonUpdate(string message)
    {
        numberTypeButton.Text = message;
    }
}