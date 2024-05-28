using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace ShopApp.WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        private Task Execute(string email, string subject, string htmlMessage)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "shopappmailsender@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", email);

            mimeMessage.To.Add(mailboxAddressTo);

            
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody= htmlMessage;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject = subject;


            SmtpClient client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("shopappmailsender@gmail.com", "kxuprbxrckkokfri");
            client.Send(mimeMessage);
            client.Disconnect(true);
            
            return Task.CompletedTask;
        }
    }
}
