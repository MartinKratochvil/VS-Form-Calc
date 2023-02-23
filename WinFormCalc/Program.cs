using System;
using System.Windows.Forms;
using WinFormCalc.Calculators.GoniometricFunctions.Functions;
using WinFormCalc.Forms;


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
            MathOper.Setup();
            BinOper.Setup();
            Application.Run(new MainForm());
        }
    }
}
