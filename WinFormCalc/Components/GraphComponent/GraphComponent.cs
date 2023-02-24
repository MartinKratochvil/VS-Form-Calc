using System.Drawing;
using System.Windows.Forms;

namespace WinFormCalc.Components.GraphComponent
{
    public class GraphComponent
    {

        private readonly Size size;
        
        private readonly Point location;

        private readonly GridControl gridControl;

        public Panel Panel { get; private set; }


        public GraphComponent(Size size, Point location)
        {
            this.size = size;
            this.location = location;

            gridControl = new GridControl(size);

            Panel = new Panel()
            {
                Size = size,
                Location = location
            };

            gridControl.Render();

            Panel.Controls.Add(gridControl.PictureBox);
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
}