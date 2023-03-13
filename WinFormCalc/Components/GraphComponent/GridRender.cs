using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WinFormCalc.Components.GraphComponent
{
    public class GridRender
    {

        public const int Space = 125;

        private readonly Pen linePen;

        private readonly Pen subLinePen;

        private readonly Pen axisPen;

        private readonly Graphics graphics;

        public Bitmap Bitmap { get; }


        public GridRender()
        {
            PixelFormat pixelFormat = PixelFormat.Format32bppArgb;
            Bitmap = new Bitmap(GridControl._size, GridControl._size, pixelFormat);

            graphics = Graphics.FromImage(Bitmap);

            Color penColor = Color.FromArgb(255, 192, 192, 192);

            linePen = new Pen(penColor, 2);
            subLinePen = new Pen(penColor, 1);
            axisPen = new Pen(Color.Black, 2);

            Render();
        }


        private void Render()
        {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            //TODO: change background
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, Bitmap.Width, Bitmap.Height);

            DrawGrid();

            DrawAxes();

            //Point[] points = { new Point(50, 50), new Point(70, 100), new Point(100, 20), new Point(100, 100), new Point(70, 200)};
            //graphics.DrawCurve(axisPen, points);    
        }


        private void DrawGrid()
        {
            for (int i = 0; i < 2; i++) {
                bool column = i % 2 == 0;

                for (int j = 0; j < GridControl._size / Space; j++) {
                    Point start = column ?
                        new Point(Space * j - 1, 0) :
                        new Point(0, Space * j - 1)
                    ;

                    Point end = column ?
                        new Point(Space * j - 1, GridControl._size - 1) :
                        new Point(GridControl._size - 1, Space * j - 1)
                    ;

                    graphics.DrawLine(linePen, start, end);

                    for (int k = 0; k < 4; k++) {
                        if (column) {
                            start.X += Space / 5;
                            end.X += Space / 5;
                        }
                        else {
                            start.Y += Space / 5;
                            end.Y += Space / 5;
                        }

                        graphics.DrawLine(subLinePen, start, end);
                    }
                }
            }
        }


        private void DrawAxes()
        {
            for (int i = 0; i < 2; i++) {
                bool column = i % 2 == 0;

                Point start = column ?
                    new Point(GridControl._size / 2, 0) :
                    new Point(0, GridControl._size / 2)
                ;

                Point end = column ?
                    new Point(GridControl._size / 2, GridControl._size - 1) :
                    new Point(GridControl._size - 1, GridControl._size / 2)
                ;

                graphics.DrawLine(axisPen, start, end);
            }
        }
    }
}
