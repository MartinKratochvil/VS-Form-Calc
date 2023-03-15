﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcModal;

public class AdvanceCalcModalLayer : TableLayoutPanel
{

    private List<List<Control>> layer;

    private List<Dictionary<string, Action>> clickEvents;


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
                Button button = new Button {
                    Size = new Size(300, 100),
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    ForeColor = Color.Black,
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