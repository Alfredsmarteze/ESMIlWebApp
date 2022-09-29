using Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public bool SendEmail(string userEmail, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration.GetSection("EmailCreName").GetSection("EmailUserName").Value);
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_configuration.GetSection("EmailCreName").GetSection("EmailUserName").Value,
                _configuration.GetSection("EmailCrePassword").GetSection("EmailUserPassword").Value);
            client.Host = _configuration.GetSection("EmailCreHost").GetSection("EmailHost").Value; 
            client.Port = _configuration.GetValue<int>("EmailCrePort:EmailPort"); 
            client.EnableSsl = _configuration.GetValue<bool>("EmailCreSsl:EmailSsl");

            bool success = false;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return success;  
            }
        }
    }
}
