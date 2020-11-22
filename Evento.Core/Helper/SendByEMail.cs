using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Evento.Core.Helper
{
    public class SendByEMail
    {        
        public static void SendEmail(string EmailClient)
        {
            string EmailServer = "mavila@ucb.edu.bo";
            string PasswServer = "Qac67546";
            var client = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(EmailServer, PasswServer)
            };

            var mailMessage = new MailMessage { From = new MailAddress(EmailServer) };
            mailMessage.To.Add(EmailClient);
            mailMessage.Body = "Test";
            mailMessage.Subject = "Hello";
            client.Send(mailMessage);
        }
    }
}
