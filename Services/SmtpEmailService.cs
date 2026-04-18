using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace RestoranRezervasyonSistemi.Services
{
    public sealed class SmtpEmailService
    {
        public void Send(string toEmail, string subject, string body)
        {
            var host = ConfigurationManager.AppSettings["SmtpHost"];
            var portRaw = ConfigurationManager.AppSettings["SmtpPort"];
            var enableSslRaw = ConfigurationManager.AppSettings["SmtpEnableSsl"];
            var username = ConfigurationManager.AppSettings["SmtpUsername"];
            var password = ConfigurationManager.AppSettings["SmtpPassword"];
            var fromEmail = ConfigurationManager.AppSettings["SmtpFromEmail"] ?? username;
            var fromName = ConfigurationManager.AppSettings["SmtpFromName"];

            int.TryParse(portRaw, out var port);
            if (port <= 0) port = 587;

            bool.TryParse(enableSslRaw, out var enableSsl);
            if (string.IsNullOrWhiteSpace(host)) host = "smtp.gmail.com";

            using (var message = new MailMessage())
            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = enableSsl;

                if (!string.IsNullOrWhiteSpace(username))
                    client.Credentials = new NetworkCredential(username, password);

                message.From = string.IsNullOrWhiteSpace(fromName)
                    ? new MailAddress(fromEmail)
                    : new MailAddress(fromEmail, fromName);

                message.To.Add(toEmail);
                message.Subject = subject;
                message.Body = body;

                client.Send(message);
            }
        }
    }
}

