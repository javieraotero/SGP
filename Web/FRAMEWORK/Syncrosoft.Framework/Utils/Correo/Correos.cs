using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Syncrosoft.Framework.Utils.Correo
{


    public class Correos
    {

        /*
         * Cliente SMTP
         * Gmail:  smtp.gmail.com  puerto:587
         * Hotmail: smtp.liva.com  puerto:25
         */

        SmtpClient server = new SmtpClient(ConfigurationManager.AppSettings["SmtpClient"], int.Parse(ConfigurationManager.AppSettings["SmtpClientport"]));

        public Correos()
        {
            /*
            * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["UserNamePassword"]);
            server.EnableSsl = false;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }

}
