using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            List<List<List<string>>> values = new List<List<List<string>>>{
                new List<List<string>>{
                    new List<string>{
                        "8", "list"
                    }
                },
                new List<List<string>>{
                    new List<string>{
                        "5", "3"
                    }
                }
            };

            Number calc = new Number(values);

            MessageBox.Show("Result: " + calc.getResult().ToString());
        }
    }
}
