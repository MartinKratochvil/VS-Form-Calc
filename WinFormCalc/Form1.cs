using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc
{
    public partial class Form1 : Form
    {

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            List<List<List<Number>>> values = new List<List<List<Number>>>{
                new List<List<Number>>{
                    new List<Number>{
                        new Number(3, false, false, false, false, false), new Number(32, false, false, false, false, false), new Number(8, false, true, false, true, true), new Number(true, false, false, false, false)
                    }
                },
                new List<List<Number>>{
                    new List<Number>{
                        new Number(4, false, false, false, true, false), new Number(3, true, false, false, true, false)
                    }
                }
            };

            Calculation calc = new Calculation(values, new Number(false, false, false, false, false));

            MessageBox.Show("Result: " + calc.GetResult().ToString());
        }
    }
}
