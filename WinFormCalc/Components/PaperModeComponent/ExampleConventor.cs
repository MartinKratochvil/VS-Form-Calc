using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc.Components.PaperModeComponent
{
    public static class ExampleConventor
    {

        public static List<List<List<AdvanceNumber>>> Convert(string example)
        {
            List<List<List<AdvanceNumber>>> values = new List<List<List<AdvanceNumber>>>();
            values.Add(new List<List<AdvanceNumber>>());
            values[0].Add(new List<AdvanceNumber>());

            string payload = String.Empty;
            PrimeOper primeOper = PrimeOper.None;
            bool isNegative = false;
            
            int i = 0; 

            foreach (char c in example)
            {
                if (Char.IsDigit(c) || c == '.')
                {
                    payload += c;

                    continue;
                }

                if (c == '(' && payload == String.Empty)
                {
                    values[i][values[i].Count - 1].Add(new AdvanceNumber(primeOper, new List<Enum>()));

                    i++;

                    if (i >= values.Count)
                    {
                        values.Add(new List<List<AdvanceNumber>>());
                    }

                    values[i].Add(new List<AdvanceNumber>());
                    primeOper = PrimeOper.None;

                    continue;
                }

                if (payload != String.Empty)
                {
                    MessageBox.Show("payload: " + payload);

                    if (!Double.TryParse(payload, out double num))
                    {
                        throw new FormatException("kkte špatné číslo!!");
                    }

                    values[i][values[i].Count - 1].Add(new AdvanceNumber
                    (
                        isNegative ? (num * -1) : num,
                        primeOper,
                        new List<Enum>()
                    ));
                }

                payload = String.Empty;
                primeOper = PrimeOper.None;
                isNegative = false;

                switch (c)
                {
                    case '+': break;

                    case '-':
                    {
                        isNegative = true;

                        break;
                    }

                    case '*':
                    {
                        primeOper = PrimeOper.Multiply;

                        break;
                    }

                    case '/':
                    {
                        primeOper = PrimeOper.Divide;
                        
                        break;
                    }

                    /*case '(':
                    {
                        values[i][values.Count - 1].Add(new AdvanceNumber(num, PrimeOper.Multiply, new List<Enum>()));

                        break;
                    }*/

                    case ')':
                    {
                        i--;

                        break;
                    }

                    case '=':
                    {
                        return values;
                    }

                    default:
                    {
                        throw new FormatException("kkte špatný znak!!");
                    }
                }
            }

            throw new Exception();
        }


        private static void ChangeState(ref bool isNumber, ref string payload)
        {
            isNumber = !isNumber;
            payload = String.Empty;
        }
    }
}
