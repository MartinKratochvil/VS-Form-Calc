using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalc {
    public class Values {
        public Values (double number) { 
            this.number = number;

        }
        private double number;
        private List<Values> values;
    }
}
