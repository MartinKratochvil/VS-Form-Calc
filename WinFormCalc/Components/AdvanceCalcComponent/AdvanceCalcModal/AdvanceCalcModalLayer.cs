using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcModal;

public class AdvanceCalcModalLayer : TableLayoutPanel
{

    private List<List<Control>> layer;

    private readonly List<Dictionary<string, Action>> clickEvents;


    public AdvanceCalcModalLayer(List<Dictionary<string, Action>> clickEvents)
    {
        this.clickEvents = clickEvents;
        
        InitializeComponent();

        TableDataManager.SetSymmetricalData(this, layer);
    }


    private void InitializeComponent()
    {
        layer = new();

        clickEvents.ForEach(buttonRowClickEvents => {
            List<Control> buttonColumns = new();

            foreach (KeyValuePair<string, Action> buttonEvent in buttonRowClickEvents) {
                Button button = new() {
                    Size = new Size(320, 100),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    ForeColor = Color.FromArgb(10, 187, 255),
                    BackColor = Color.FromArgb(45, 45, 48),
                    Text = buttonEvent.Key
                };

                button.Click += (_, _) => {
                    buttonEvent.Value.Invoke();
                };

                buttonColumns.Add(button);
            }
            layer.Add(buttonColumns);
        });
    }
}