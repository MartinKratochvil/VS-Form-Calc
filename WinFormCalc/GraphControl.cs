using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System;
using System.Collections.Generic;

namespace WinFormCalc
{
    public class GraphControl
    {

        private readonly Size size;
        
        private readonly Point location;

        private readonly GridControl gridControl;

        public Panel Panel { get; private set; }


        public GraphControl(Size size, Point location)
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

            RenderLabels();
        }


        private void RenderLabels()
        {
            int maxHoriz = size.Width / GridRender._space;
            int value = maxHoriz / -2;

            for (int i = 0; i <= maxHoriz; i++)
            {
                Label label = CreateLabel();

                label.Location = new Point(label.Location.X + GridRender._space * i - label.Width / 2, label.Location.Y + size.Height / 2);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Text = value.ToString();

                value++;

                if (i == size.Width / GridRender._space / 2)
                {
                    label.Visible = false;
                }

                gridControl.PictureBox.Controls.Add(label);
            }

            int maxVert = size.Height / GridRender._space;
            value = maxVert / -2;

            for (int i = 0; i <= maxVert; i++)
            {
                Label label = CreateLabel();

                label.Location = new Point(label.Location.X + size.Width / 2 - label.Width, label.Location.Y + GridRender._space * i - label.Height / 2);
                label.TextAlign = ContentAlignment.MiddleRight;
                label.Text = value.ToString();

                value++;

                if (i == size.Height / GridRender._space / 2)
                {
                    label.Visible = false;
                }

                gridControl.PictureBox.Controls.Add(label);
            }
        }


        private Label CreateLabel ()
        {
            return new Label()
            {
                Location = new Point(gridControl.PictureBox.Location.X * -1, gridControl.PictureBox.Location.Y * -1),
                Size = new Size(60, 20),
                AutoSize = false,
                Font = new Font("Microsoft YaHei", 10, FontStyle.Regular),
                BackColor = Color.Transparent,
            };
        }
    }
}