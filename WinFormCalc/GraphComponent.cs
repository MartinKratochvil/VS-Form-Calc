using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;

namespace WinFormCalc
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
        }


        public void Render()
        {
            Panel = new Panel()
            {
                Size = size,
                Location = location
            };

            gridControl.Render();

            Panel.Controls.Add(gridControl.PictureBox);
        }
    }
}