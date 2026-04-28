using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class ResetPasswordForm : Form
    {
        public string UserMail { get; set; }
        private readonly AccountController _accountController = new AccountController();

        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string pass1 = txtNewPass.Text;
            string pass2 = txtNewPassConfirm.Text;

            // 1. Boş mu kontrol et
            if (string.IsNullOrEmpty(pass1) || string.IsNullOrEmpty(pass2))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            // 2. Şifreler uyuşuyor mu kontrol et
            if (pass1 != pass2)
            {
                MessageBox.Show("Girdiğiniz şifreler birbirliyle eşleşmiyor!");
                return;
            }

            // 3. Veritabanında Güncelle
            try
            {
                _accountController.UpdatePassword(UserMail, pass1);

                MessageBox.Show("Şifreniz başarıyla güncellendi! Giriş yapabilirsiniz.");

                // Kullanıcıyı tekrar login ekranına gönderiyoruz
                LoginForm login = new LoginForm();
                login.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message);
            }
        }
    }
}
