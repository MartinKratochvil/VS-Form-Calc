using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormCalc.Components;
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

namespace WinFormCalc.Forms;

public partial class MainForm : Form
{

    private Control activeComponent;

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

        basicCalcPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        advanceCalcPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        prgCalcPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        paperModeComponent = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            Size = contentPanel.Size
        };

        graphComponent = new(new Size(500, 500));
        graphComponent.Render(3, 2, 5);

        areaConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        dataConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        lengthConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        speedConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        temperatureConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        timeConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        volumeConvertorPanel = new() {
            MinimumSize = new Size(320, 445),
            MaximumSize = new Size(1280, 890),
            BackColor = Color.FromArgb(37, 37, 38),
            Size = contentPanel.Size
        };

        formSize = Size;
        isMenuShow = true;

        ChangeComponent(basicCalcPanel, placeholderLabel.Text);
    }


    private void MainFormResize(object sender, EventArgs e)
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


    private void ChangeComponent(Control component, string placeholder)
    {
        activeComponent = component;

        contentPanel.Controls.Clear();
        contentPanel.Controls.Add(component);

        placeholderLabel.Text = placeholder;
            
        timerMenuPanel.Start();
            
        if (component.GetType() != typeof(GraphComponent)) {
            FormBorderStyle = FormBorderStyle.Sizable;
            return;
        }
            
        Size = new Size(500, 550);
        FormBorderStyle = FormBorderStyle.FixedDialog;
    }


    private void BasicCalcButtonClick(object sender, EventArgs e)
    {
        ChangeComponent(basicCalcPanel, ((Button)sender).Text);
    }


    private void AdvanceCalcButtonClick(object sender, EventArgs e)
    {
        ChangeComponent(advanceCalcPanel, ((Button)sender).Text);
    }


    private void PrgCalcButtonClick(object sender, EventArgs e)
    {
        ChangeComponent(prgCalcPanel, ((Button)sender).Text);
    }

        
    private void PaperModeButtonClick(object sender, EventArgs e)
    {
        ChangeComponent(paperModeComponent, ((Button)sender).Text);
    }


    private void GraphButtonClick(object sender, EventArgs e)
    {
        ChangeComponent(graphComponent, ((Button)sender).Text);
    }


    private void AreaConvertorButtonClick(object sender, EventArgs e)
    {
        areaConvertorPanel.Clear();
        ChangeComponent(areaConvertorPanel, ((Button)sender).Text);
    }


    private void DataConvertorButtonClick(object sender, EventArgs e)
    {
        dataConvertorPanel.Clear();
        ChangeComponent(dataConvertorPanel, ((Button)sender).Text);
    }


    private void LengthConvertorButtonClick(object sender, EventArgs e)
    {
        lengthConvertorPanel.Clear();
        ChangeComponent(lengthConvertorPanel, ((Button)sender).Text);
    }


    private void SpeedConvertorButtonClick(object sender, EventArgs e)
    {
        speedConvertorPanel.Clear();
        ChangeComponent(speedConvertorPanel, ((Button)sender).Text);
    }


    private void TemperatureConvertorButtonClick(object sender, EventArgs e)
    {
        temperatureConvertorPanel.Clear();
        ChangeComponent(temperatureConvertorPanel, ((Button)sender).Text);
    }


    private void TimeConvertorButtonClick(object sender, EventArgs e)
    {
        timeConvertorPanel.Clear();
        ChangeComponent(timeConvertorPanel, ((Button)sender).Text);
    }


    private void VolumeConvertorButtonClick(object sender, EventArgs e)
    {
        volumeConvertorPanel.Clear();
        ChangeComponent(volumeConvertorPanel, ((Button)sender).Text);
    }


    private void MainFormKeyPress(object sender, KeyPressEventArgs e)
    {
        if (activeComponent is PaperModeComponent || activeComponent is GraphComponent) {
            return;
        }

        char keyChar = char.ToLower(e.KeyChar);

        if (activeComponent is BasicCalcPanel) {
            ComponentKeyPressHandler.HandleBasicCalc(keyChar);
            return;
        }

        if (activeComponent is AdvanceCalcPanel) {
            ComponentKeyPressHandler.HandleAdvanceCalc(keyChar);
            return;
        }

        if (activeComponent is PrgCalcPanel) {
            ComponentKeyPressHandler.HandlePrgCalc(keyChar);
            return;
        }

        ComponentKeyPressHandler.HandleConvertor(keyChar);
    }
}