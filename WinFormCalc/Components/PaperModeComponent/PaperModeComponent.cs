using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WinFormCalc.Calculators.AdvanceCalculator;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;

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
                    ExampleConvertor.Convert(GetExample()),
                    new AdvanceNumber(AdvancePrimeOper.None, new List<Enum>())
                );

                string result = calc.GetResult();
                int cursor = SelectionStart;

                //RemoveLine();

                Text = Text.Insert(SelectionStart, Environment.NewLine + "= " + result);
                SelectionStart += cursor + result.Length + 4;

                //MessageBox.Show("ans: " + calc.GetResult().ToString());

                /*string s = String.Empty;
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

                MessageBox.Show(s);*/
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
            }

            
        }

        /*private void RemoveLine()
        {
            if (Text.Length < SelectionStart + 2)
            {
                return;
            }

            if (Text.Substring(SelectionStart + 2, 1) == "=")
            {
                MessageBox.Show("ss");

                String text = Text.Substring(SelectionStart + 2);

                for(int i = 0; i < text.Length - 1; i++)
                {
                    if (Text.Substring(i, 2) != Environment.NewLine)
                    {
                        continue;
                    }

                    Text = Text.Remove(SelectionStart + 2, SelectionStart + i + 2);
                }
            }
        }*/


        private string GetExample()
        {
            int start = IndexOfStartLine();
            string example = Text.Substring(start, SelectionStart - start);

            return new string(example
                .Where(c => c != ' ')
                .ToArray()
            );
        }


        private int IndexOfStartLine()
        {
            for (int i = SelectionStart - 2; i > 0; i--)
            {
                if (Text.Substring(i, 2) == Environment.NewLine)
                {
                    return i + 2;
                }
            }

            return 0;
        }
    }
}
