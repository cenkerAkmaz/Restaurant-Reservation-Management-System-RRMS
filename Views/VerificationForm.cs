using System;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi.Views
{
    public partial class VerificationForm : Form
    {
        // Dışarıdan gelen veriler
        public string GelenMail { get; set; }
        public string GelenKullaniciAdi { get; set; }
        public string GelenAdSoyad { get; set; }
        public string GelenSifre { get; set; }
        public string GelenTelefon { get; set; }
        public string GelenKod { get; set; }

        // Bu değişken Kayıt mı (False) yoksa Şifre Sıfırlama mı (True) olduğunu belirler
        public bool IsPasswordReset { get; set; } = false;

        private readonly AccountController _accountController = new AccountController();

        public VerificationForm()
        {
            InitializeComponent();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim() == GelenKod.Trim())
                {
                    if (IsPasswordReset)
                    {
                        MessageBox.Show("Kod Doğrulandı! Lütfen yeni şifrenizi belirleyin.");
                        var rpf = new ResetPasswordForm
                        {
                            UserMail = GelenMail
                        };
                        rpf.Show();
                        this.Hide();
                    }
                    else
                    {
                        _accountController.CompleteRegistration(GelenKullaniciAdi, GelenSifre, GelenMail, GelenAdSoyad, GelenTelefon);

                        MessageBox.Show("Kayıt Başarılı! Artık giriş yapabilirsiniz.", "Bilgi");

                        var login = new LoginForm();
                        login.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı kod girdiniz! Lütfen mailinizi tekrar kontrol edin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    }
}