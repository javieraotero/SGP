using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Syncrosoft.Framework.Utils.Encriptacion
{
    class Encriptacion
    {
        public static string generarClaveSHA1(string nombre)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(nombre);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString().Trim();
        }
    }
}
