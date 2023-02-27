using System;
using System.Windows.Forms;
using WinFormCalc.Forms;
using WinFormCalc.Operations.Functions.GonFunction;
using WinFormCalc.Operations.Functions.MathFunction;
using WinFormCalc.Operations.PrimeOperations.AdvacePrimeOper;
using WinFormCalc.Operations.PrimeOperations.BasicPrimeOper;
using WinFormCalc.Operations.PrimeOperations.ProgrammerPrimeOper;


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
            
            GonFunctionHandler.Setup();
            MathFunctionHandler.Setup();
            BasicPrimeOperHandler.Setup();
            AdvancePrimeOperHandler.Setup();
            ProgrammerPrimeOperHandler.Setup();
            
            Application.Run(new MainForm());
        }
    }
}
