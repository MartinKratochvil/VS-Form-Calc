using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WinFormCalc.Components.GraphComponent
{
    public class GraphRender
    {

        private Graphics graphics;

        private Pen graphPen;

        public Bitmap Bitmap { get; }


        public GraphRender()
        {
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
            Bitmap = new Bitmap(GridControl._size, GridControl._size, pixelFormat);

            graphics = Graphics.FromImage(Bitmap);

            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            //Color penColor = Color.FromArgb(255, 192, 192, 192);
            graphPen = new Pen(Color.Red, 3);
        }


        public void Render(int a, int b, int c)
        {
            int space = GridRender.Space / 5;
            int pointsNum = GridControl._size / space / 2;

            List<Point> points = new List<Point>();

            for (int i = pointsNum * -1; i <= pointsNum; i++) {
                int x = i;
                int y = -1 * (a * (int)Math.Pow(x, 2) + b * x + c);

                /*if ((y + pointsNum) * space < 0 || (y + pointsNum) * space > GridControl._size)
                {
                    continue;
                }*/

                //MessageBox.Show(x + " " + y);

                points.Add(new Point((x + pointsNum) * space, (y + pointsNum) * space));
            }

            graphics.DrawCurve(graphPen, points.ToArray());
        }
    }
}
