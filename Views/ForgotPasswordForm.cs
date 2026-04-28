using System;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly AccountController _accountController = new AccountController();

        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtResetMail.Text?.Trim();
                var code = _accountController.StartPasswordReset(email);

                if (string.IsNullOrWhiteSpace(code))
                {
                    MessageBox.Show("Bu mail adresi sistemde kayıtlı değil!");
                    return;
                }

                MessageBox.Show("Sıfırlama kodu mailinize gönderildi!");

                var vf = new VerificationForm
                {
                    GelenMail = email,
                    GelenKod = code,
                    IsPasswordReset = true
                };
                vf.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}