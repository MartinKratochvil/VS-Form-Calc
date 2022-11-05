using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormCalc {

    public class Number
    {

        public bool isList;

        private double value;

        private bool isNegative;

        public bool isPriorityOperation { get; private set; }

        public bool isMultiply { get; private set; }

        private bool isPow;

        private bool isSqrt;

        public double Value
        {
            get
            {
                double value = this.isNegative ? this.value * -1 : this.value;
                value = this.isPow ? Math.Pow(value, 2) : value;

                return this.isSqrt ? Math.Sqrt(value) : value;
            }
            set
            {
                this.value = value;
            }
        }


        public Number (bool isNegative, bool isPriorityOperation, bool isMultiply, bool isPow, bool isSqrt)
        {
            this.isList = true;
            this.isNegative = isNegative;
            this.isPriorityOperation = isPriorityOperation;
            this.isMultiply = isMultiply;
            this.isPow = isPow;
            this.isSqrt = isSqrt;
        }


        public Number (double value, bool isNegative, bool isPriorityOperation, bool isMultiply, bool isPow, bool isSqrt)
        {
            this.isList = false;
            this.value = value;
            this.isNegative = isNegative;
            this.isPriorityOperation = isPriorityOperation;
            this.isMultiply = isMultiply;
            this.isPow = isPow;
            this.isSqrt = isSqrt;
        }
    }
}
