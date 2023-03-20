using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.GraphComponent;

public class GraphComponent : Panel
{

    private readonly GridControl gridControl;


    public GraphComponent(Size size)
    {
        Size = size;

        gridControl = new(size);
        gridControl.Render();

        Controls.Add(gridControl);
    }


    public void Render(int a, int b)
    {
        gridControl.GraphControl.GraphRender.Render(0, a, b);
    }


    public void Render(int a, int b, int c)
    {
        gridControl.GraphControl.GraphRender.Render(a, b, c);
    }
}