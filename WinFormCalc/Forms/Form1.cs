using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormCalc.Convertors;
using WinFormCalc.Transfers;

namespace WinFormCalc
{
    public partial class Form1 : Form
    {

        public Form1() {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) {

            /*List<List<List<Number>>> values = new List<List<List<Number>>>{
                new List<List<Number>>{
                    new List<Number>{
                        new Number(5, PrimeOper.None, new List<Enum>() {}), new Number(16, PrimeOper.Multiply, new List<Enum>() {Function.Sqrt}), new Number(-8, PrimeOper.None, new List<Enum>() {}), new Number(PrimeOper.None, new List<Enum>() {})
                    }
                },
                new List<List<Number>>{
                    new List<Number>{
                        new Number(4, PrimeOper.None, new List<Enum>() {}), new Number(4, PrimeOper.None, new List<Enum>() {Function.Pow}), new Number(2, PrimeOper.Divide, new List<Enum>() {Function.Pow})
                    }
                }
            };*/

            /*List<List<List<BinNumber>>> binValues = new List<List<List<BinNumber>>>
            {
                new List<List<BinNumber>>
                {
                    new List<BinNumber>
                    {
                        new BinNumber("1011", VarType.Bin, VarSize.Long, BinFunction.None),
                        new BinNumber(3, VarSize.Long, BinFunction.None),
                        new BinNumber(1, VarSize.Long, BinFunction.LeftShift),
                        new BinNumber(-1, VarSize.Long, BinFunction.None),
                        new BinNumber(BinFunction.Multiply)
                    }
                },
                new List<List<BinNumber>>
                {
                    new List<BinNumber>
                    {
                        new BinNumber(3, VarSize.Long, BinFunction.None),
                        new BinNumber(2, VarSize.Long, BinFunction.None)
                    }
                }
            };

            ProgrammerCalculator programmerCalculator = new ProgrammerCalculator(binValues, new BinNumber(BinFunction.None));

            MessageBox.Show("kkt: " + programmerCalculator.GetResult());
            
            
            List<List<List<AdvanceNumber>>> values = new List<List<List<AdvanceNumber>>>
            {
                new List<List<AdvanceNumber>>
                {
                    new List<AdvanceNumber>
                    {
                        new AdvanceNumber(4, PrimeOper.None, new List<Enum> {GonFunc.Sin}),
                        new AdvanceNumber(32, PrimeOper.None, new List<Enum> {}),
                        new AdvanceNumber(8, PrimeOper.Divide, new List<Enum> {Function.Pow, Function.Sqrt}),
                        new AdvanceNumber(-1, PrimeOper.None, new List<Enum> {}),
                        new AdvanceNumber(PrimeOper.Multiply, new List<Enum> {})
                    }
                },
                new List<List<AdvanceNumber>>
                {
                    new List<AdvanceNumber>
                    {
                        new AdvanceNumber(4, PrimeOper.None, new List<Enum> {Function.Pow}),
                        new AdvanceNumber(-1, PrimeOper.None, new List<Enum> {}),
                        new AdvanceNumber(3, PrimeOper.Multiply, new List<Enum> {Function.Pow})
                    }
                }
            };

            AdvanceCalculator calc = new AdvanceCalculator(values, new AdvanceNumber(PrimeOper.None, new List<Enum>()));

            MessageBox.Show("Result: " + calc.GetResult().ToString());*/

            /*List<Number> values1 = new List<Number>
            {
                new Number(4, false, false, false, true, false), new Number(5, true, false, false, true, true), new Number(9, false, true, true, false, true)
            };

            Calc calc = new Calc(values1);

            MessageBox.Show(calc.GetResult().ToString());*/

            //Action i = MathGon.idk[(int)GonFunc.Sin];
            //i();
            /*MessageBox.Show(MathGon.Calc(1, GonFunc.HArctan).ToString());
            MessageBox.Show(MathGon.Calc(1, GonFunc.Cotan).ToString());
            MessageBox.Show(MathGon.Calc(1, GonFunc.Sin).ToString());*/


            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            /*DateTime now = DateTime.Now;
            DateTime newDate = now.AddDays(2000);

            MessageBox.Show(now.ToString());
            MessageBox.Show(Date.ConvertTimeSpanToString(Date.CompareDate(newDate, now)));*/

            //MessageBox.Show(Data.Convert(1, DataEnum.YottaByte, DataEnum.Bit).ToString());

            //MessageBox.Show(Length.Convert(1, LengthEnum.Foot, LengthEnum.Inch).ToString());

            //MessageBox.Show(Volume.Convert(1, VolumeEnum.CubicMeter, VolumeEnum.Liter).ToString());

            //MessageBox.Show(Area.Convert(10000, AreaEnum.SquareMeter, AreaEnum.Hectare).ToString());

            //MessageBox.Show(Time.Convert(1, TimeEnum.Month, TimeEnum.Day).ToString());

            //MessageBox.Show(Temperature.Convert(35.6, TemperatureEnum.Fahrenheit, TemperatureEnum.Kelvin).ToString());;;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) Application.Exit();
        }
    }
}
