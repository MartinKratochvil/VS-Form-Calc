using System;
using System.Collections.Generic;
using WinFormCalc.Calculators.Numbers;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;

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
                if (Char.IsDigit(c) || c == ',')
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
                    if (! Double.TryParse(payload, out double num))
                    {
                        throw new FormatException("Špatné číslo!!");
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
                        throw new FormatException("Špatný znak!!");
                    }
                }
            }

            throw new Exception("No example!!");
        }


        /*private static void ChangeState(ref bool isNumber, ref string payload)
        {
            isNumber = !isNumber;
            payload = String.Empty;
        }*/
    }
}
