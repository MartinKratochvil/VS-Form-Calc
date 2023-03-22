using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.GraphComponent;

public class GraphPanel : Panel
{

    private readonly GridControl gridControl;


    public GraphPanel()
    {
        Size = new Size(500, 500);

        gridControl = new(Size);
        gridControl.Setup();

        Controls.Add(gridControl);
    }


    public void Render(int a, int b, int c)
    {
        gridControl.GraphControl.Render(a, b, c);
    }
}