using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcPanel;
using WinFormCalc.Components.BasicCalcComponent.BasicCalcPanel;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcPanel;

namespace WinFormCalc.Forms
{
    public partial class MainForm : Form
    {

        private readonly BasicCalcPanel basicCalcPanel;

        private readonly AdvanceCalcPanel advanceCalcPanel;

        private readonly PrgCalcPanel prgCalcPanel;

        private Size formSize;


        public MainForm()
        {
            InitializeComponent();

            basicCalcPanel = new BasicCalcPanel();
            basicCalcPanel.Size = contentPanel.Size;

            advanceCalcPanel = new AdvanceCalcPanel();
            advanceCalcPanel.Size = contentPanel.Size;

            prgCalcPanel = new PrgCalcPanel();
            prgCalcPanel.Size = contentPanel.Size;
            
            contentPanel.Controls.Add(prgCalcPanel);

            formSize = Size;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Swag");
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            contentPanel.Width += Width - formSize.Width;
            contentPanel.Height += Height - formSize.Height;

            basicCalcPanel.Size = contentPanel.Size;
            advanceCalcPanel.Size = contentPanel.Size;
            prgCalcPanel.Size = contentPanel.Size;

            formSize = Size;
        }
    }
}
