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
            /*List<List<List<Number>>> values = new List<List<List<Number>>>{
                new List<List<Number>>{
                    new List<Number>{
                        new Number(8, false, false, false, false, false), new Number(32, false, false, false, false, false), new Number(8, false, true, false, true, true), new Number(true, false, false, false, false)
                    }
                },
                new List<List<Number>>{
                    new List<Number>{
                        new Number(4, false, false, false, true, false), new Number(3, true, false, false, true, false)
                    }
                }
            };*/

            //AdvanceCalculation calc = new AdvanceCalculation(values, new Number(false, false, false, false, false));

            //MessageBox.Show("Result: " + calc.GetResult().ToString());

            List<Number> values1 = new List<Number>
            {
                new Number(4, false, false, false, true, false), new Number(5, true, false, false, true, true), new Number(9, false, true, true, false, true)
            };

            Calc calc = new Calc(values1);

            MessageBox.Show(calc.GetResult().ToString());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) Application.Exit();
        }
    }
}
