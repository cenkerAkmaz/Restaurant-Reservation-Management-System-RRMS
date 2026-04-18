using System;
using System.Windows.Forms;
using RestoranRezervasyonSistemi.Views;
using RestoranRezervasyonSistemi.Controllers;

namespace RestoranRezervasyonSistemi
{
    public partial class LoginForm : Form
    {
        private readonly LoginController _loginController = new LoginController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                var identifier = !string.IsNullOrWhiteSpace(txtUser.Text)
                    ? txtUser.Text.Trim()
                    : txtFullName.Text?.Trim();

                var currentUser = _loginController.CheckLogin(identifier, txtPass.Text);

                if (currentUser == null)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                    return;
                }

                if (string.Equals(currentUser.Role, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Admin Paneline Hoş Geldiniz!");
                    var adminPanel = new AdminPanel();
                    adminPanel.Show();
                }
                else
                {
                    MessageBox.Show("Giriş Başarılı! Masa Planına Yönlendiriliyorsunuz.");
                    var main = new MainForm
                    {
                        AktifKullaniciMail = currentUser.Email,
                        CurrentUser = currentUser
                    };
                    main.Show();
                }

                Hide(); // Login formunu gizle
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnGoRegister_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.Show();
            this.Hide();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm fp = new ForgotPasswordForm();
            fp.Show();
            this.Hide();
        }
    }
}