using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormCalc.Components.BasicCalcComponent;

namespace WinFormCalc.Forms
{
    public partial class MainForm : Form
    {

        BasicCalcPanel basicCalcPanel;


        public MainForm()
        {
            InitializeComponent();

            basicCalcPanel = new BasicCalcPanel();
            basicCalcPanel.Size = contentPanel.Size;

            contentPanel.Controls.Add(basicCalcPanel);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            basicCalcPanel.Size = new Size(1280, 890);
            contentPanel.Size = new Size(1280, 890);
        }
    }
}
