using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components.AdvanceCalcComponent;
using WinFormCalc.Components.BasicCalcComponent;

namespace WinFormCalc.Forms
{
    public partial class MainForm : Form
    {

        private BasicCalcPanel basicCalcPanel;

        private AdvanceCalcPanel advanceCalcPanel;

        private Size formSize;


        public MainForm()
        {
            InitializeComponent();

            basicCalcPanel = new BasicCalcPanel();
            basicCalcPanel.Size = contentPanel.Size;

            advanceCalcPanel = new AdvanceCalcPanel();
            advanceCalcPanel.Size = contentPanel.Size;
            
            contentPanel.Controls.Add(advanceCalcPanel);

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

            formSize = Size;
        }
    }
}
