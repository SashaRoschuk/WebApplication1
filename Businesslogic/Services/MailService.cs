using Businesslogic.Intefaces;
using MailKit.Security;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Services;
using MailKit.Net.Smtp;

namespace Businesslogic.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;
        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendMailAsync(string subject, string body, string to , string? from)
        { 
           
 

 
               MailData data = configuration.GetSection(nameof(MailData)).Get<MailData>();



                // create message

                var email = new MimeMessage();

                email.From.Add(MailboxAddress.Parse(from ?? data.Email));

                email.To.Add(MailboxAddress.Parse(to));

                email.Subject = subject;

                email.Body = new TextPart(TextFormat.Text) { Text = body };

                // send email

                using var smtp = new SmtpClient();

                await smtp.ConnectAsync(data.Host, data.Port, SecureSocketOptions.StartTls);

                await smtp.AuthenticateAsync(data.Email, data.Password);

                await smtp.SendAsync(email);

                await smtp.DisconnectAsync(true);

                
        }
    }
}
