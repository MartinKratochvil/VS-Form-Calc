using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components.AdvanceCalcComponent;
using WinFormCalc.Components.BasicCalcComponent;
using WinFormCalc.Components.ProgrammerCalcComponent;

namespace WinFormCalc.Forms
{
    public partial class MainForm : Form
    {

        private readonly BasicCalcPanel basicCalcPanel;

        private readonly AdvanceCalcPanel advanceCalcPanel;

        private readonly ProgrammerCalcPanel programmerCalcPanel;

        private Size formSize;


        public MainForm()
        {
            InitializeComponent();

            basicCalcPanel = new BasicCalcPanel();
            basicCalcPanel.Size = contentPanel.Size;

            advanceCalcPanel = new AdvanceCalcPanel();
            advanceCalcPanel.Size = contentPanel.Size;

            programmerCalcPanel = new ProgrammerCalcPanel();
            programmerCalcPanel.Size = contentPanel.Size;
            
            contentPanel.Controls.Add(programmerCalcPanel);

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
            programmerCalcPanel.Size = contentPanel.Size;

            formSize = Size;
        }
    }
}
