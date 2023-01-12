using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc
{
    public partial class Grid : Form
    {
        public Grid()
        {
            InitializeComponent();
        }


        private void Grid_Load(object sender, EventArgs e)
        {
            GraphComponent grid = new GraphComponent(new Size(500, 500), new Point(100, 100));
            grid.Render(1, 2, -1);
            grid.Render(-1, 2);

            Controls.Add(grid.Panel);
        }
    }
}
