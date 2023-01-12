using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc.Components.PaperModeComponent
{
    public class PaperModeComponent : TextBox
    {
     
        public PaperModeComponent()
        {
            this.Multiline = true;
        }


        public void Calculate()
        {
            if (this.SelectionStart <= 0 || this.Text[this.SelectionStart - 1] != '=')
            {
                return;
            }

            try
            {
                AdvanceCalculator calc = new AdvanceCalculator(
                    ExampleConventor.Convert(GetExample()),
                    new AdvanceNumber(PrimeOper.None, new List<Enum>())
                );

                string s = String.Empty;
                List<List<List<AdvanceNumber>>> values = ExampleConventor.Convert(GetExample());

                foreach (List<List<AdvanceNumber>> idk1 in values)
                {
                    s += "{" + Environment.NewLine;

                    foreach (List<AdvanceNumber> idk2 in idk1)
                    {
                        s += "\t{" + Environment.NewLine;

                        foreach (AdvanceNumber idk3 in idk2)
                        {
                            s += "\t\t" + (idk3.isList? "list" : idk3.Value.ToString()) + " " + Enum.GetName(typeof(PrimeOper), idk3.primeOper) + Environment.NewLine;
                        }

                        s += "\t}" + Environment.NewLine;
                    }

                    s += "{" + Environment.NewLine;
                }

                MessageBox.Show(s);
                MessageBox.Show("ans: " + calc.GetResult().ToString());

                List<List<List<AdvanceNumber>>> values2 = new List<List<List<AdvanceNumber>>>
                {
                    new List<List<AdvanceNumber>>
                    {
                        new List<AdvanceNumber>
                        {
                            new AdvanceNumber(5, PrimeOper.None, new List<Enum> {}),
                            new AdvanceNumber(-1, PrimeOper.None, new List<Enum> {}),
                            new AdvanceNumber(PrimeOper.Multiply, new List<Enum> {})
                        }
                    },
                    new List<List<AdvanceNumber>>
                    {
                        new List<AdvanceNumber>
                        {
                            new AdvanceNumber(3, PrimeOper.None, new List<Enum> {}),
                            new AdvanceNumber(2, PrimeOper.None, new List<Enum> {})
                        }
                    }
                };

                AdvanceCalculator calc2 = new AdvanceCalculator(values2, new AdvanceNumber(PrimeOper.None, new List<Enum>()));

                MessageBox.Show("answer: " + calc2.GetResult().ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
            }

            
        }


        private string GetExample()
        {
            int start = IndexOfStartLine();
            string example = this.Text.Substring(start, this.SelectionStart - start);

            return new string(example
                .Where(c => c != ' ')
                .ToArray()
            );
        }


        private int IndexOfStartLine()
        {
            for (int i = this.SelectionStart - 2; i > 0; i--)
            {
                if (this.Text.Substring(i, 2) == Environment.NewLine)
                {
                    return i + 2;
                }
            }

            return 0;
        }
    }
}
