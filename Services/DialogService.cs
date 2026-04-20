using System;
using System.Windows.Forms;

namespace RestoranRezervasyonSistemi.Services
{
    public static class DialogService
    {
        public static void ShowError(string message, string title = "Hata")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowWarning(string message, string title = "Uyarı")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowInfo(string message, string title = "Bilgi")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ShowConfirmation(string message, string title = "Onay")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
