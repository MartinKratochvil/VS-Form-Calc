using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcModal;

public class PrgCalcModal : TableLayoutPanel
{

    private List<List<Control>> buttons;


    public PrgCalcModal()
    {
        InitializeComponent();
    }


    private void InitializeComponent()
    {
        buttons = new();
        
        PrgCalcModalEvents.ModalFuncClickEvents.ForEach(buttonRowClickEvents => {
            List<Control> buttonColumns = new();

            foreach (KeyValuePair<string, Action> buttonEvent in buttonRowClickEvents) {
                Button button = new Button {
                    Size = new Size(300, 100),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    ForeColor = Color.Black,
                    Text = buttonEvent.Key
                };

                button.Click += (_, _) => {
                    buttonEvent.Value.Invoke();
                };

                buttonColumns.Add(button);
            }

            buttons.Add(buttonColumns);
        });
        
        TableDataManager.SetSymmetricalData(this, buttons);
    }
}