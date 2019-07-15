using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerStore.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;

            //var emailMessage = new MimeMessage();

            //emailMessage.From.Add(new MailboxAddress("Администрация сайта BeerStore", "admin@example.com"));
            //emailMessage.To.Add(new MailboxAddress("", email));
            //emailMessage.To.Add(new MailboxAddress("", "it@example.com"));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = message
            //};

            //using (var client = new SmtpClient())
            //{            
            //    //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //    await client.ConnectAsync("smtp.yandex.ru", 465, true);
            //    //client.AuthenticationMechanisms.Remove("XOAUTH2");
            //    await client.AuthenticateAsync("admin@example.com", "password1");
            //    await client.SendAsync(emailMessage);
            //    await client.DisconnectAsync(true);
            //}
        }
    }
}
