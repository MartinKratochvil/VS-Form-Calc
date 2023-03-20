using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.AdvanceCalcComponent.AdvanceCalcModal;

public class AdvanceCalcModal : TableLayoutPanel
{

    private AdvanceCalcModalFunc funcPanel;

    private Panel layerPanel;

    private bool isArc;

    private bool isHyp;

    private AdvanceCalcModalLayer trigonLayer;

    private AdvanceCalcModalLayer arcTrigonLayer;

    private AdvanceCalcModalLayer hypTrigonLayer;

    private AdvanceCalcModalLayer hypArcTrigonLayer;


    public AdvanceCalcModal()
    {
        InitializeComponent();

        isArc = false;
        isArc = false;

        funcPanel.ArcButtonClick += ArcButtonClick;
        funcPanel.HypButtonClick += HypButtonClick;

        ChangeLayer();
    }
    

    private void InitializeComponent()
    {
        funcPanel = new() {
            Size = new Size(300, 200)
        };

        layerPanel = new() {
            Size = new Size(960, 200)
        };
        layerPanel.Resize += PanelResize;

        trigonLayer = new(AdvanceCalcModalEvents.ModalClickEvents) {
            Size = new Size(960, 200)
        };

        arcTrigonLayer = new(AdvanceCalcModalEvents.ModalArcClickEvents) {
            Size = new Size(960, 200)
        };

        hypTrigonLayer = new(AdvanceCalcModalEvents.ModalHypClickEvents) {
            Size = new Size(960, 200)
        };

        hypArcTrigonLayer = new(AdvanceCalcModalEvents.ModalHypArcClickEvents) {
            Size = new Size(960, 200)
        };

        TableDataManager.SetAsymmetricalColumns(this, new() {funcPanel, layerPanel});
    }


    private void ArcButtonClick()
    {
        isArc = !isArc;
        ChangeLayer();
    }


    private void HypButtonClick()
    {
        isHyp = !isHyp;
        ChangeLayer();
    }
    

    private void ChangeLayer()
    {
        layerPanel.Controls.Clear();

        if (isArc) {
            if (isHyp) {
                layerPanel.Controls.Add(hypArcTrigonLayer);
                return;
            }
            
            layerPanel.Controls.Add(arcTrigonLayer);
        }

        if (isHyp) {
            layerPanel.Controls.Add(hypTrigonLayer);
            return;
        }
        
        layerPanel.Controls.Add(trigonLayer);
    }


    private void PanelResize(object sender, EventArgs e)
    {
        trigonLayer.Size = layerPanel.Size;
        arcTrigonLayer.Size = layerPanel.Size;
        hypTrigonLayer.Size = layerPanel.Size;
        hypArcTrigonLayer.Size = layerPanel.Size;
    }
}