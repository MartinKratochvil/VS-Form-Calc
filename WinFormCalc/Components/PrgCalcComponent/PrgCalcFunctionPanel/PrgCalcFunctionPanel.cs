﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcFunctionPanel
{
    public class PrgCalcFunctionPanel : TableLayoutPanel
    {

        private Button logicalFunctionButton;

        private Button numberTypeButton;
        

        public PrgCalcFunctionPanel()
        {
            InitializeComponent();

            Size = new Size(1280, 110);

            List<Control> columns = new List<Control> { logicalFunctionButton, numberTypeButton };
            TableDataManager.SetAsymmetricalColumns(this, columns);
        }


        private void InitializeComponent()
        {
            logicalFunctionButton = new Button {
                Size = new Size(640, 110),
                Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                BackColor = Color.HotPink,
                Text = @"Logické funkce"
            };
            logicalFunctionButton.Click += PrgCalcFunctionPanelEvents.LogicalFunctionButtonClick;

            numberTypeButton = new Button {
                Size = new Size(640, 110),
                Font = new Font("Segoe UI Semibold",  14.25F, FontStyle.Bold, GraphicsUnit.Point, 238),
                ForeColor = Color.Black,
                BackColor = Color.HotPink,
                Text = @"Dec"
            };
            numberTypeButton.Click += PrgCalcFunctionPanelEvents.NumberTypeButtonClick;
        }


        public void NumberTypeButtonUpdate(string message)
        {
            numberTypeButton.Text = message;
        }
    }
}