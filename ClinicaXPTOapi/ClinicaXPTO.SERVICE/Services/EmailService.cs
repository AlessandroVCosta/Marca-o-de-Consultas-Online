
using ClinicaXPTO.SHARED.IService;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ClinicaXPTO.SERVICE.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtp;
        private readonly string _from;

        public EmailService(IConfiguration config)
        {
            var section = config.GetSection("Email");
            var host = section["Host"];
            var port = int.Parse(section["Port"]!);
            var user = section["Username"];
            var pass = section["Password"];
            _from = section["From"]!;

            _smtp = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            using var msg = new MailMessage(_from, to, subject, htmlBody)
            {
                IsBodyHtml = true
            };
            await _smtp.SendMailAsync(msg);
        }
    }
}
