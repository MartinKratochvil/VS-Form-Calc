using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

namespace WinFormCalc
{
    public class GridControl
    {

        public const int _size = 2500;

        private readonly Size parentSize;

        private Point startPoint;
        
        private Point stopPoint;

        private bool pressed;

        private readonly GridRender gridRender;

        public PictureBox PictureBox { get; private set; }


        public GridControl(Size parentSize)
        {
            this.parentSize = parentSize;
            pressed = false;

            PictureBox = new PictureBox();

            gridRender = new GridRender();
            
        }


        public void Render()
        {
            PictureBox.Size = new Size(_size, _size);
            PictureBox.Location = new Point( -1 * (_size / 2 - parentSize.Width / 2), -1 * (_size / 2 - parentSize.Height / 2));
            PictureBox.Image = gridRender.Bitmap;

            PictureBox.MouseDown += MouseDown;
            PictureBox.MouseUp += MouseUp;
            PictureBox.MouseMove += MouseMove;

            //graphics.DrawEllipse(boldPen, 50, 50, 300, 200);
        }


        private void MouseDown(object sender, MouseEventArgs e)
        {
            pressed = true;

            startPoint = PictureBox.PointToClient(Cursor.Position);
        }


        private void MouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
        }


        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (! pressed)
            {
                return;
            }

            stopPoint = PictureBox.PointToClient(Cursor.Position);

            PictureBox.Location = Move();
            MoveLabels();

            startPoint = PictureBox.PointToClient(Cursor.Position);
        }


        private Point Move()
        {
            Point location = new Point(
                PictureBox.Location.X + (stopPoint.X - startPoint.X),
                PictureBox.Location.Y + (stopPoint.Y - startPoint.Y)
            );

            int minHorizontal = -1 * (_size - parentSize.Width);
            int minVertical = -1 * (_size - parentSize.Height);

            location.X = ValidateAxis(location.X, minHorizontal);
            location.Y = ValidateAxis(location.Y, minVertical);

            return location;
        }


        private void MoveLabels()
        {
            foreach (Control c in PictureBox.Controls)
            {
                if (! (c is Label))
                {
                    continue;
                }

                if (c.Location.Y == _size / 2)
                {
                    if (c.Location.X + c.Parent.Location.X + c.Width < 0 && startPoint.X - stopPoint.X > 0)
                    {
                        c.Location = new Point(c.Location.X + GridRender._space * PictureBox.Controls.Count / 2, c.Location.Y);
                        c.Text = (Int32.Parse(c.Text) + 5).ToString();
                        c.Visible = true;
                    }

                    if (c.Location.X + c.Parent.Location.X - c.Width > parentSize.Width && startPoint.X - stopPoint.X < 0)
                    {
                        c.Location = new Point(c.Location.X - GridRender._space * PictureBox.Controls.Count / 2, c.Location.Y);
                        c.Text = (Int32.Parse(c.Text) - 5).ToString();
                        c.Visible = true;
                    }

                    continue;
                }

                if (c.Location.Y + c.Parent.Location.Y + c.Height < 0 && startPoint.Y - stopPoint.Y > 0)
                {
                    c.Location = new Point(c.Location.X, c.Location.Y + GridRender._space * PictureBox.Controls.Count / 2);
                    c.Text = (Int32.Parse(c.Text) + 5).ToString();
                    c.Visible = true;
                }

                if (c.Location.Y + c.Parent.Location.Y - c.Height > parentSize.Height && startPoint.Y - stopPoint.Y < 0)
                {
                    c.Location = new Point(c.Location.X, c.Location.Y - GridRender._space * PictureBox.Controls.Count / 2);
                    c.Text = (Int32.Parse(c.Text) - 5).ToString();
                    c.Visible = true;
                }
            }
        }


        private int ValidateAxis(int x, int border)
        {
            x = x > 0 ? 0 : x;
            x = x < border ? border : x;

            return x;
        }
    }
}
