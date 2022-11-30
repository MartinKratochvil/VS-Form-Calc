using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormCalc
{
    public class BinNumber
    {
        public long value;

        public BinFunction function;

        public bool isList;


        public BinNumber(string value, VarType type, VarSize size, BinFunction function)
        {
            this.isList = false;
            this.function = function;

            try
            {
                this.value = Convert.ToInt64(value, (int)type);
            }
            catch
            {
                this.value = 0;
            }
            
        }


        public BinNumber(long value, VarSize size, BinFunction function)
        {
            this.isList = false;
            this.value = value;
            this.function = function;
        }


        public BinNumber(long value)
        {
            this.isList = false;
            this.value = value;
        }


        public BinNumber(BinFunction function)
        {
            this.isList = true;
            this.function = function;
        }
    }
}
