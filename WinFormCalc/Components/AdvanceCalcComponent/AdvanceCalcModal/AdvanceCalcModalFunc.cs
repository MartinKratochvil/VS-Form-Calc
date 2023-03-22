using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcModal;

public class AdvanceCalcModalFunc : TableLayoutPanel
{

    private Button arcButton;

    private Button hypButton;

    public AdvanceCalcModalEvents.ButtonClick ArcButtonClick;

    public AdvanceCalcModalEvents.ButtonClick HypButtonClick;


    public AdvanceCalcModalFunc()
    {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        arcButton = new() {
            Size = new Size(300, 100),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.FromArgb(10, 187, 255),
            BackColor = Color.FromArgb(45, 45, 48),
            Text = "2nd"
        };
        arcButton.Click += (_, _) => ArcButtonClick?.Invoke();

        hypButton = new() {
            Size = new Size(300, 100),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
            ForeColor = Color.FromArgb(10, 187, 255),
            BackColor = Color.FromArgb(45, 45, 48),
            Text = "Hyp"
        };
        hypButton.Click += (_, _) => HypButtonClick?.Invoke();

        TableDataManager.SetAsymmetricalRows(this, new() {arcButton, hypButton});
    }
    
    
}