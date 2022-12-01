using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormCalc
{
    public class GraphControl
    {

        private Size parentSize;

        public GraphRender GraphRender { get; private set; }

        public PictureBox PictureBox { get; private set; }


        public GraphControl(Size parentSize)
        {
            this.parentSize = parentSize;

            PictureBox = new PictureBox();
            GraphRender = new GraphRender();
        }

        public void Render ()
        {
            PictureBox.Size = new Size(GridControl._size, GridControl._size);
            PictureBox.Location = new Point(0, 0);
            PictureBox.BackColor = Color.Transparent;
            PictureBox.Image = GraphRender.Bitmap;
        }
    }
}
