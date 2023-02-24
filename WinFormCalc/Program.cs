using System;
using System.Windows.Forms;
using WinFormCalc.Forms;
using WinFormCalc.Operations.Functions;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.Functions.MathGonFunction;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;
using WinFormCalc.Operations.PrimeOperations.BinPrimeOper;


namespace WinFormCalc
{
    internal static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MathGon.Setup();
            MathFunc.Setup();
            BasicPrimeOperHandler.Setup();
            AdvancePrimeOperHandler.Setup();
            BinPrimeOperHandler.Setup();
            
            Application.Run(new Form1());
        }
    }
}
