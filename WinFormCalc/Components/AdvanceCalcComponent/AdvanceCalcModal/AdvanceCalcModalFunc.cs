using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcModal;

public class AdvanceCalcModalFunc : TableLayoutPanel
{

    private Button arcButton;

    private Button hypButton;

    public AdvanceCalcModalEvents.ButtonClick OnArcButtonClick;

    public AdvanceCalcModalEvents.ButtonClick OnHypButtonClick;


    public AdvanceCalcModalFunc()
    {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        arcButton = new Button {
            Size = new Size(300, 100),
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.Black,
            Text = "2nd"
        };
        arcButton.Click += (_, _) => OnArcButtonClick?.Invoke();

        hypButton = new Button {
            Size = new Size(300, 100),
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.Black,
            Text = "Hyp"
        };
        hypButton.Click += (_, _) => OnHypButtonClick?.Invoke();

        TableDataManager.SetAsymmetricalRows(this, new() {arcButton, hypButton});
    }
    
    
}