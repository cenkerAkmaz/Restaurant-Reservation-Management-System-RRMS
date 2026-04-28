using System;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Views;

namespace RestoranRezervasyonSistemi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}