using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc {
    public class Number {

        private bool isList;

        private double value;

        private List<Number> values;


        public Number (double value)
        {
            this.isList = false;
            this.value = value;
        }


        public Number (List<List<List<string>>> values)
        {
            this.isList = true;
            this.values = new List<Number>();

            values = new List<List<List<string>>>(values);

            List<string> numbers = new List<string>(values[0][0]);
            values.Remove(values[0]);

            foreach (string value in numbers)
            {
                if (value != "list")
                {
                    this.values.Add(new Number(Double.Parse(value)));

                    continue;
                }

                this.values.Add(new Number(values));
                values[0].Remove(values[0][0]);
            }
        }


        public double getResult()
        {
            if ( ! isList)
            {
                return this.value;
            }

            double result = 0;
            foreach (Number value in values)
            {
                result += value.getResult();
            }

            return result;
        }
    }
}
