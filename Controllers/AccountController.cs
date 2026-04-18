using RestoranRezervasyonSistemi.Data;
using RestoranRezervasyonSistemi.Services;
using System;

namespace RestoranRezervasyonSistemi.Controllers
{
    public sealed class AccountController
    {
        private readonly UserRepository _users = new UserRepository();
        private readonly SmtpEmailService _email = new SmtpEmailService();

        public string SendRegistrationVerificationCode(string email, string username)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email boş olamaz.", nameof(email));
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Kullanıcı adı boş olamaz.", nameof(username));

            var code = new Random().Next(100000, 999999).ToString();
            _email.Send(email, "Kayıt Onay Kodu", $"Merhaba {username}, Kayıt onay kodunuz: {code}");
            return code;
        }

        public string StartPasswordReset(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email boş olamaz.", nameof(email));

            if (!_users.EmailExists(email))
                return null;

            var code = new Random().Next(100000, 999999).ToString();
            _users.UpdateVerificationCode(email, code);
            _email.Send(email, "Şifre Sıfırlama Kodu", "Şifre sıfırlama talebiniz için kodunuz: " + code);
            return code;
        }

        public void CompleteRegistration(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Kullanıcı adı boş olamaz.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Şifre boş olamaz.", nameof(password));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email boş olamaz.", nameof(email));

            _users.InsertUser(username, password, email);
        }

        public void CompleteRegistration(string username, string password, string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Kullanıcı adı boş olamaz.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Şifre boş olamaz.", nameof(password));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email boş olamaz.", nameof(email));

            // FullName is not collected yet; default to username (name/surname can be added later).
            _users.InsertUser(username, password, email, fullName: username, phone: phone);
        }

        public void CompleteRegistration(string username, string password, string email, string fullName, string phone)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("Kullanıcı adı boş olamaz.", nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Şifre boş olamaz.", nameof(password));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email boş olamaz.", nameof(email));

            _users.InsertUser(username, password, email, fullName: fullName, phone: phone);
        }

        public void UpdatePassword(string email, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email boş olamaz.", nameof(email));
            if (string.IsNullOrWhiteSpace(newPassword)) throw new ArgumentException("Şifre boş olamaz.", nameof(newPassword));

            _users.UpdatePasswordByEmail(email, newPassword);
        }
    }
}

