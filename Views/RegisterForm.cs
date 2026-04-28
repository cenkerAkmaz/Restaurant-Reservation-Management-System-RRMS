using System;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class RegisterForm : Form
    {
        private readonly AccountController _accountController = new AccountController();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtMail.Text?.Trim();
                var username = txtUser.Text?.Trim();
                var fullName = txtFullName.Text?.Trim();
                var phone = txtPhone.Text?.Trim();
                var code = _accountController.SendRegistrationVerificationCode(email, username);

                MessageBox.Show("Onay kodu mail adresinize gönderildi!");

                var vf = new VerificationForm
                {
                    GelenMail = email,
                    GelenKullaniciAdi = username,
                    GelenAdSoyad = fullName,
                    GelenSifre = txtPass.Text,
                    GelenTelefon = phone,
                    GelenKod = code
                };
                vf.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderim hatası: " + ex.Message);
            }
        }
    }
}