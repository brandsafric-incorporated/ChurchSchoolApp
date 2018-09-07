using ChurchSchool.Service.Contracts;
using ChurchSchool.Shared;
using Microsoft.Extensions.Options;
using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;

namespace ChurchSchool.Service.Implementations
{
    public class EmailService : IEmailService
    {
        private ApplicationSettings _configuration;

        public EmailService(IOptions<ApplicationSettings> configuration)
        {
            _configuration = configuration.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromTitle"></param>
        /// <param name="to"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>        
        /// <returns></returns>
        public async Task<bool> SendEmail(string to, string title, string content, bool isHtmlBody)
        {
            var mailMessage = new MailMessage(_configuration.EmailSettings.Login, to)
            {
                Body = content,
                IsBodyHtml = isHtmlBody,
                Subject = title,                
                From = new MailAddress(_configuration.EmailSettings.Login, "Seminário da Igreja de Deus no Brasil - Petrópolis")                
            };            
            

            using (var emailClient = new SmtpClient(_configuration.EmailSettings.Host, _configuration.EmailSettings.Port))
            {
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = new NetworkCredential(_configuration.EmailSettings.Login, _configuration.EmailSettings.Password);
                emailClient.EnableSsl = _configuration.EmailSettings.IsSecureConnection;
                emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                
                await emailClient.SendMailAsync(mailMessage);
            }

            return true;
        }
    }
}
