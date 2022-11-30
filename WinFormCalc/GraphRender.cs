using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalc
{
    public class GraphRender
    {

        private Graphics graphics;

        private Pen graphPen;

        public Bitmap Bitmap { get; private set; }


        public GraphRender()
        {
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
            Bitmap = new Bitmap(GridControl._size, GridControl._size, pixelFormat);

            graphics = Graphics.FromImage(Bitmap);

            //Color penColor = Color.FromArgb(255, 192, 192, 192);
            graphPen = new Pen(Color.Red, 3);

            Render();
        }


        private void Render()
        {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            RenderGraph();
        }


        private void RenderGraph()
        {
            int pointsNum = GridControl._size / GridRender._space * 5;
            List<Point> points = new List<Point>();

            for (int i = 0; i <= pointsNum; i++)
            {
                if (i * GridRender._space / 5 < 0 || i * GridRender._space / 5> GridControl._size)
                {
                    continue;
                }

                points.Add(new Point(i * GridRender._space / 5, i * GridRender._space / 5));
            }

            //Point[] points = { new Point(50, 50), new Point(70, 100), new Point(100, 20), new Point(100, 100), new Point(70, 200) };
            graphics.DrawCurve(graphPen, points.ToArray());
        }
    }
}
