using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCalc {
    public class Number
    {
        private bool isList;

        private double value;

        private bool isNegative;

        private bool isPriorityOperation;

        private bool isMultiply;

        private bool isPow;

        private bool isSqrt;


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


        public bool IsList
        {
            get {
                return this.isList;
            }
            set
            {
                this.isList = value;
            }
        }


        public double Value
        {
            get
            {
                double value = this.isPow ? Math.Pow(this.value, 2) : this.value;

                return this.isSqrt ? Math.Sqrt(value) : value;
            }
            set
            {
                this.value = value;
            }
        }


        public bool IsNegative
        {
            get
            {
                return this.isNegative;
            }
        }


        public bool IsPriorityOperation
        {
            get
            {
                return this.isPriorityOperation;
            }
        }


        public bool IsMultiply
        {
            get
            {
                return this.isMultiply;
            }
        }
    }
}
