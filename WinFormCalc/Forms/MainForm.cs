using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcPanel;
using WinFormCalc.Components.BasicCalcComponent.BasicCalcPanel;
using WinFormCalc.Components.ConvertorComponent.ConvertorPanel;
using WinFormCalc.Components.GraphComponent;
using WinFormCalc.Components.PaperModeComponent;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcPanel;
using WinFormCalc.Convertors;
using WinFormCalc.Convertors.Area;

namespace WinFormCalc.Forms
{
    public partial class MainForm : Form
    {

        private readonly BasicCalcPanel basicCalcPanel;

        private readonly AdvanceCalcPanel advanceCalcPanel;

        private readonly PrgCalcPanel prgCalcPanel;

        private readonly PaperModeComponent paperModeComponent;

        private readonly GraphComponent graphComponent;

        private readonly ConvertorPanel<AreaEnum> convertorPanel;

        private Size formSize;

        private bool isMenuShow;


        public MainForm()
        {
            InitializeComponent();

            basicCalcPanel = new BasicCalcPanel();
            basicCalcPanel.Size = contentPanel.Size;

            advanceCalcPanel = new AdvanceCalcPanel();
            advanceCalcPanel.Size = contentPanel.Size;

            prgCalcPanel = new PrgCalcPanel();
            prgCalcPanel.Size = contentPanel.Size;

            paperModeComponent = new PaperModeComponent();
            paperModeComponent.Size = contentPanel.Size;
            
            graphComponent = new GraphComponent(new Size(500, 500));
            graphComponent.Render(3, 2, 5);

            convertorPanel = new ConvertorPanel<AreaEnum>();
            convertorPanel.Size = contentPanel.Size;

            contentPanel.Controls.Add(convertorPanel);

            formSize = Size;
            isMenuShow= false;
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            contentPanel.Width += Width - formSize.Width;
            contentPanel.Height += Height - formSize.Height;

            basicCalcPanel.Size = contentPanel.Size;
            advanceCalcPanel.Size = contentPanel.Size;
            prgCalcPanel.Size = contentPanel.Size;
            paperModeComponent.Size = contentPanel.Size;
            convertorPanel.Size = contentPanel.Size;

            panelMenuContent.Height = Height - 47;

            formSize = Size;
        }


        private void pictureBoxMenu_Click(object sender, EventArgs e)
        {
            timerMenuPanel.Start();
        }


        private void timerMenuPanel_Tick(object sender, EventArgs e)
        {
            if (isMenuShow) {
                panelMenu.Width -= 30;

                if (panelMenu.Width == 0) {
                    timerMenuPanel.Stop();
                    isMenuShow = false;
                }

                return;
            }

            panelMenu.Width += 30;

            if (panelMenu.Width == panelMenu.MaximumSize.Width) {
                timerMenuPanel.Stop();
                isMenuShow = true;
            }
        }


        private void buttonBasicCalc_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(basicCalcPanel);
            labelPlaceholer.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;

            timerMenuPanel.Start();
        }


        private void buttonAdvanceCalc_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(advanceCalcPanel);
            labelPlaceholer.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;

            timerMenuPanel.Start();
        }


        private void buttonPrgCalc_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(prgCalcPanel);
            labelPlaceholer.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;

            timerMenuPanel.Start();
        }

        

        private void buttonPaperMode_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(paperModeComponent);
            labelPlaceholer.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(graphComponent);
            labelPlaceholer.Text = ((Button)sender).Text;

            Size = new Size(500, 550);
            FormBorderStyle = FormBorderStyle.FixedDialog;

            timerMenuPanel.Start();
        }
    }
}
