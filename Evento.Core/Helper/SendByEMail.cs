using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Evento.Core.Helper
{
    public class SendByEMail
    {        
        public static void SendEmailUsuario(String Nombre,string EmailClient, string Clave, IConfiguration _configuration)
        {            
            string Smtp = _configuration["EventoSettings:SMTP"];
            int Puerto = Convert.ToInt32(_configuration["EventoSettings:Port"]);
            string EmailServer = _configuration["EventoSettings:Email"];
            string PasswServer = _configuration["EventoSettings:EmailPass"];
            string SitioWeb = _configuration["EventoSettings:UrlSite"];
            string txtBody = @"<font size=5>Saludos "+Nombre+",</font><br><br>" +
                              "<font size=5>Usted tiene acceso al sistema CICE2020(2do Congreso Internacional de Ciencias Empresariales)</font><br>" +
                              "<font size=5>sus credenciales de acceso son:</font><br><br>" +
                              "<font size=5>Usuario: " + EmailClient + "</font><br>" +
                              "<font size=5>Clave: " + Clave+ "</font><br>" +
                              "<font size=5>Click Para Sitio Web:<a href='" + SitioWeb + "'>CICE2020</a></font><br>" +
                              "<font size=5>Mensaje automatico desde CICE2020</font>";
            string txtSubject = "Acceso al Sistema CICE2020"; ;
            var client = new SmtpClient(Smtp)
            {
                Port = Puerto,
                UseDefaultCredentials = true,
                EnableSsl = true,                
                Credentials = new NetworkCredential(EmailServer, PasswServer)
            };

            var mailMessage = new MailMessage(EmailServer,EmailClient);            
            mailMessage.Body = txtBody;
            mailMessage.Subject =  txtSubject;
            mailMessage.IsBodyHtml = true;
            client.Send(mailMessage);
        }
    }
}
