using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using www.veinid365.cn.Configs;

namespace www.veinid365.cn.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfig _config;

        public EmailService(IOptions<EmailConfig> options)
        {
            _config = options.Value;
        }

        public async Task SendAsync(string toName, string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_config.Name, _config.Address));
            message.To.Add(new MailboxAddress(toName, toEmail));

            message.Subject = subject;

            message.Body = new TextPart("plain") { Text = body };
            
            await Send(message);
        }

        public async Task SendRangeAsync(IEnumerable<MailboxAddress> addresses, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_config.Name, _config.Address));
            message.To.AddRange(addresses);

            message.Subject = subject;

            message.Body = new TextPart("plain") { Text = body };

            await Send(message);
        }

        public async Task Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(_config.Host, 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(_config.UserName, _config.Password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

        }
    }
}