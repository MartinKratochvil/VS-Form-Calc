using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcPanel;
using WinFormCalc.Components.BasicCalcComponent.BasicCalcPanel;
using WinFormCalc.Components.ConvertorComponent.ConvertorPanel;
using WinFormCalc.Components.GraphComponent;
using WinFormCalc.Components.PaperModeComponent;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcPanel;
using WinFormCalc.Convertors.Area;
using WinFormCalc.Convertors.Data;
using WinFormCalc.Convertors.Length;
using WinFormCalc.Convertors.Speed;
using WinFormCalc.Convertors.Temperature;
using WinFormCalc.Convertors.Time;
using WinFormCalc.Convertors.Volume;

namespace WinFormCalc.Forms
{
    public partial class MainForm : Form
    {

        private readonly BasicCalcPanel basicCalcPanel;

        private readonly AdvanceCalcPanel advanceCalcPanel;

        private readonly PrgCalcPanel prgCalcPanel;

        private readonly PaperModeComponent paperModeComponent;

        private readonly GraphComponent graphComponent;

        private readonly ConvertorPanel<AreaEnum> areaConvertorPanel;

        private readonly ConvertorPanel<DataEnum> dataConvertorPanel;

        private readonly ConvertorPanel<LengthEnum> lengthConvertorPanel;

        private readonly ConvertorPanel<SpeedEnum> speedConvertorPanel;

        private readonly ConvertorPanel<TemperatureEnum> temperatureConvertorPanel;

        private readonly ConvertorPanel<TimeEnum> timeConvertorPanel;

        private readonly ConvertorPanel<VolumeEnum> volumeConvertorPanel;


        private Size formSize;

        private bool isMenuShow;


        public MainForm()
        {
            InitializeComponent();
            
            speedConvertorButton.Visible = false;

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

            areaConvertorPanel = new ConvertorPanel<AreaEnum>();
            areaConvertorPanel.Size = contentPanel.Size;

            dataConvertorPanel = new ConvertorPanel<DataEnum>();
            dataConvertorPanel.Size = contentPanel.Size;

            lengthConvertorPanel = new ConvertorPanel<LengthEnum>();
            lengthConvertorPanel.Size = contentPanel.Size;

            speedConvertorPanel = new ConvertorPanel<SpeedEnum>();
            speedConvertorPanel.Size = contentPanel.Size;

            temperatureConvertorPanel = new ConvertorPanel<TemperatureEnum>();
            temperatureConvertorPanel.Size = contentPanel.Size;

            timeConvertorPanel = new ConvertorPanel<TimeEnum>();
            timeConvertorPanel.Size = contentPanel.Size;

            volumeConvertorPanel = new ConvertorPanel<VolumeEnum>();
            volumeConvertorPanel.Size = contentPanel.Size;

            contentPanel.Controls.Add(areaConvertorPanel);

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
            areaConvertorPanel.Size = contentPanel.Size;
            dataConvertorPanel.Size = contentPanel.Size;
            lengthConvertorPanel.Size = contentPanel.Size;
            speedConvertorPanel.Size = contentPanel.Size;
            temperatureConvertorPanel.Size = contentPanel.Size;
            timeConvertorPanel.Size = contentPanel.Size;
            volumeConvertorPanel.Size = contentPanel.Size;

            menuContentPanel.Height = Height - 47;

            formSize = Size;
        }


        private void MenuIconClick(object sender, EventArgs e)
        {
            timerMenuPanel.Start();
        }


        private void MenuPanelTimerTick(object sender, EventArgs e)
        {
            if (isMenuShow) {
                menuPanel.Width -= 30;

                if (menuPanel.Width == 0) {
                    timerMenuPanel.Stop();
                    isMenuShow = false;
                }

                return;
            }

            menuPanel.Width += 30;

            if (menuPanel.Width == menuPanel.MaximumSize.Width) {
                timerMenuPanel.Stop();
                isMenuShow = true;
            }
        }


        private void BasicCalcButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(basicCalcPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;

            timerMenuPanel.Start();
        }


        private void AdvanceCalcButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(advanceCalcPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;

            timerMenuPanel.Start();
        }


        private void PrgCalcButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(prgCalcPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;

            timerMenuPanel.Start();
        }

        

        private void PaperModeButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(paperModeComponent);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }

        private void GridButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(graphComponent);
            placeholerLabel.Text = ((Button)sender).Text;

            Size = new Size(500, 550);
            FormBorderStyle = FormBorderStyle.FixedDialog;

            timerMenuPanel.Start();
        }


        private void AreaConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            areaConvertorPanel.Clear();
            contentPanel.Controls.Add(areaConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }


        private void DataConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            dataConvertorPanel.Clear();
            contentPanel.Controls.Add(dataConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }


        private void LengthConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            lengthConvertorPanel.Clear();
            contentPanel.Controls.Add(lengthConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }


        private void SpeedConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            speedConvertorPanel.Clear();
            contentPanel.Controls.Add(speedConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }


        private void TemperatureConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            temperatureConvertorPanel.Clear();
            contentPanel.Controls.Add(temperatureConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }


        private void TimeConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            timerMenuPanel.Start();
            contentPanel.Controls.Add(timeConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }


        private void VolumeConvertorButtonClick(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            volumeConvertorPanel.Clear();
            contentPanel.Controls.Add(volumeConvertorPanel);
            placeholerLabel.Text = ((Button)sender).Text;
            FormBorderStyle = FormBorderStyle.Sizable;
            
            timerMenuPanel.Start();
        }
    }
}
