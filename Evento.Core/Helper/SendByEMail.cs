using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Evento.Core.Helper
{
    public class SendByEMail
    {
        public static void SendEmail()
        {
            var client = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential("raraniar@ucb.edu.bo", "Scugua1975")
            };

            var mailMessage = new MailMessage { From = new MailAddress("raraniar@ucb.edu.bo") };
            mailMessage.To.Add("ricardo.jal@gmail.com");
            mailMessage.Body = "Test";
            mailMessage.Subject = "Hello";
            client.Send(mailMessage);
        }
    }
}
