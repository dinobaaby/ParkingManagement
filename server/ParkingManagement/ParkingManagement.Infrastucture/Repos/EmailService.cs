

using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using System.Web;

namespace ParkingManagement.Infrastucture.Repos
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest request)
        {
            var email = new MimeMessage();


            email.Sender = MailboxAddress.Parse(_emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = request.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = request.Body;


            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect(_emailSettings.Host, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate(_emailSettings.Email, _emailSettings.Password);

            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendEmailConfirmAccountAsync(string email, string token, string controllerName, string actionName)
        {
            var emailsend = new MimeMessage();

            emailsend.Sender = MailboxAddress.Parse(_emailSettings.Email);
            emailsend.To.Add(MailboxAddress.Parse(email));
            emailsend.Subject = "Please confirm your email address";
            var confirmActionLink = $"{SD.APIURL}{controllerName}/{actionName}?email={HttpUtility.UrlEncode(email)}&token={HttpUtility.UrlEncode(token)}";

            var body = $"<p>Hello,<br/><br/>Please click the following link to confirm your email address: <a href='{confirmActionLink}'>Confirm email</a></p>";

            var builder = new BodyBuilder() ;
            builder.HtmlBody = body;
            emailsend.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.Email, _emailSettings.Password);


            await smtp.SendAsync(emailsend);

            smtp.Disconnect(true);

        }
    }
}
