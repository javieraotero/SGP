using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSO.SGP.EntidadesDeNegocio
{
    public class EntityHelper
    {
        static readonly String _EncryptionKey = "eid729";

        public static string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            if (!string.IsNullOrEmpty(cipherText))
            {
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(_EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return cipherText;
        }


        public static void EnviarMailAlta(ECO_Usuarios usuario, string Clave)
        {
            // Forma el contenido del correo de activacion de cuenta
            string subject = "Poder Judicial La Pampa - Alta Sistema de Compras";

            StringBuilder body = new StringBuilder();

            body.AppendFormat("<p>Estimado/a " +usuario.Nombre+"</p>");
            body.AppendFormat("<p>Ha realizado su INSCRIPCION en el Sistema de compras del Poder Judicial de La Pampa.</p>");
            body.AppendFormat("<p>Recibirá la confirmación definitiva cuando haya sido verificada la documentación presentada.</p>");
            body.AppendFormat("<p><b>A partir de este momento podrá identificarse en el sistema mediante las siguientes credenciales:</b></p>");
            body.AppendFormat("<p><b>Usuario:</b>" +usuario.Mail+"<br>");
            body.AppendFormat("<b>Contraseña:" +Clave+"</b></p>");
            body.AppendFormat("<p> Para acceder al sitio entrar al siguiente link:  'http://compras.justicialapampa.gob.ar/'</p>");
            body.AppendFormat("<p>--------------------<br>");
            //body.AppendFormat("Si usted no solicitó el cambio o recuperación de su contraseña ni encargó a nadie que lo haga en su nombre por favor contáctese con la administración del sitio.<br>");
            body.AppendFormat("--------------------</p>");
            body.AppendFormat("<p>Saludos cordiales.</p>");
            body.AppendFormat("<p>Poder Judicial - La Pampa<br>");
            body.AppendFormat("<a href='mailto:soporteonline@juslapampa.gob.ar'>soporteonline@juslapampa.gob.ar</a><br>");

            // Instancio el correo con los datos
            MailMessage mail = new MailMessage("\"Poder Judicial - La Pampa\" soporteonline@juslapampa.gob.ar", usuario.Mail, subject, body.ToString());
            mail.IsBodyHtml = true;

            // Instancio el SMTP
            SmtpClient cliente = new SmtpClient();

            // Envio el correo, puede fallar
            try
            {
                cliente.Send(mail);
                //falloEnvio = false;
                //resultado = true;
            }
            catch (Exception ex)
            {
                //this.GrabarLog(ex, usuario);
                //falloEnvio = true;
            }

        }


        public static string EnviarMailSimple(string emisor,string receptor,string cuerpo)
        {
            // Forma el contenido del correo de activacion de cuenta
            string subject = "Poder Judicial La Pampa - Sistema de Compras";

            StringBuilder body = new StringBuilder();

            body.AppendFormat("<p>Estimado/a </p>");
            body.AppendFormat("<p>"+cuerpo+"</p>");
            body.AppendFormat("<p> Para acceder al sitio entrar al siguiente link:  'http://compras.justicialapampa.gob.ar/'</p>");
            body.AppendFormat("--------------------</p>");
            body.AppendFormat("<p>Saludos cordiales.</p>");
            body.AppendFormat("<p>Poder Judicial - La Pampa<br>");
            body.AppendFormat("<a href='mailto:soporteonline@juslapampa.gob.ar'>soporteonline@juslapampa.gob.ar</a><br>");

            // Instancio el correo con los datos
            MailMessage mail = new MailMessage("\"Poder Judicial - La Pampa\" soporteonline@juslapampa.gob.ar", receptor, subject, body.ToString());
            mail.IsBodyHtml = true;

            // Instancio el SMTP
            SmtpClient cliente = new SmtpClient();

            // Envio el correo, puede fallar
            try
            {
                cliente.Send(mail);
                //falloEnvio = false;
                //resultado = true;
                return ("Enviado");
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }

        }
    }
}
