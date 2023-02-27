using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinFormCalc.Calculators.BasicCalculator;
using WinFormCalc.Components.BasicCalcComponent;
using WinFormCalc.Components.BasicCalcComponent.BasicCalcPanel;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;

namespace WinFormCalc.Forms
{
    public partial class Form1 : Form
    {

        BasicCalcPanel panel;


        public Form1() {
            InitializeComponent();

            panel = new BasicCalcPanel();
            Controls.Add(panel);
        }


        private void button1_Click(object sender, EventArgs e)
        {
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

            MessageBox.Show("kkt: " + programmerCalculator.GetResult());*/
            
            
            /*List<List<List<AdvanceNumber>>> values = new List<List<List<AdvanceNumber>>>
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

            //MessageBox.Show(Temperature.Convert(35.6, TemperatureEnum.Fahrenheit, TemperatureEnum.Kelvin).ToString());

            //panel.Size = new Size(500, 600);

            List<BasicNumber> numbers = new List<BasicNumber> {
                new BasicNumber(5, BasicPrimeOper.Plus, new List<MathFunction>{}),
                new BasicNumber(5, BasicPrimeOper.Multiply, new List<MathFunction>{}),
                new BasicNumber(2, BasicPrimeOper.Multiply, new List<MathFunction>{ MathFunction.Sqr, MathFunction.Sqr })
            };

            BasicCalculator calc = new BasicCalculator(numbers);

            MessageBox.Show(calc.GetResult());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
