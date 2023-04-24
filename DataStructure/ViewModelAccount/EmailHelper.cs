using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
    public class EmailHelper
    {


        public bool SendEmail(string userEmail, string confirmationLink)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("alfredsmarteze@gmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink; 

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("alfredsmarteze@gmail.com", "shycsqlmybdcdols");
            //client.Credentials = new System.Net.NetworkCredential("alfredsmarteze@gmail.com", "Y!X3eXp-5Y1a9j");
            client.Host = "smtp.gmail.com";
            //client.Host= "smtpout.secureserver.net";//"smtpout.secureserver.net";
            client.Port = 587;// 25;//80;
            client.EnableSsl = true;
                         
            bool success=false;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return success;  // log exception
            }
            
        }


    }
}
