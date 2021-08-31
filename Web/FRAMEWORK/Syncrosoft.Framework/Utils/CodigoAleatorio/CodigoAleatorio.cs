using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace Syncrosoft.Framework.Utils.CodigoAleatorio
{

    public class CodigoAleatorio
    {
        public string GenerarCodigoAleatorio(int longitud)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Byte[] randomBytes = new Byte[longitud];
            char[] chars = new char[longitud];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < longitud; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }
    }

}
