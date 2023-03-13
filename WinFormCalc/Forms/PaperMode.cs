using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormCalc.Components.PaperModeComponent;

namespace WinFormCalc.Forms
{
    public partial class PaperMode : Form
    {

        PaperModeComponent paperModeComponent;


        public PaperMode()
        {
            InitializeComponent();

            paperModeComponent = new PaperModeComponent();
            paperModeComponent.Location = new Point(12, 12);
            paperModeComponent.Size = new Size(450, 300);
            Controls.Add(paperModeComponent);
        }
    }
}
