using System;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi
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
                // ÖNCE: Maildeki kod ile ekrandaki kutu uyuşuyor mu? (Veritabanına gitmeden önce)
                if (txtCode.Text.Trim() == GelenKod.Trim())
                {
                    // DURUM 1: ŞİFRE SIFIRLAMA
                    if (IsPasswordReset)
                    {
                        MessageBox.Show("Kod Doğrulandı! Lütfen yeni şifrenizi belirleyin.");
                        ResetPasswordForm rpf = new ResetPasswordForm
                        {
                            UserMail = GelenMail
                        };
                        rpf.Show();
                        this.Hide();
                    }
                    // DURUM 2: YENİ KAYIT (REGISTER)
                    else
                    {
                        // Kod doğru, kullanıcıyı DB'ye kaydet
                        _accountController.CompleteRegistration(GelenKullaniciAdi, GelenSifre, GelenMail, GelenAdSoyad, GelenTelefon);

                        MessageBox.Show("Kayıt Başarılı! Artık giriş yapabilirsiniz.", "Bilgi");

                        // Güvenlik/akış: doğrulamadan sonra doğrudan giriş ekranına dön.
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