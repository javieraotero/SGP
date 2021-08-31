using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
//using System.Web.Extensions;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace SSO.SGP.Web.BasicConsumer
{
    public static class TokenManager
    {
        private static AuthenticationToken _authenticationToken;

        public static WebHeaderCollection GetAuthenticationHeader(string URL,string user,string password)
        {
            GenerateToken(URL,user,password);
            var webHeader = new WebHeaderCollection();
            webHeader.Add("Authorization", "Bearer " + _authenticationToken.access_token);
            return webHeader;

        }
        /// <summary>
        /// Used to generate token
        /// </summary>
        /// <returns></returns>
        private static string GenerateToken(string URL,string user,string password)
        {

            var client = new System.Net.WebClient();
            var parameters = new NameValueCollection();
            if (_authenticationToken != null)
            {
                try
                {
                    client.Headers[HttpRequestHeader.Authorization] = "Bearer " + _authenticationToken.access_token;
                    var resultAuthByte = client.DownloadString(URL + "/api/Token/RefeshTokenMain");
                    return _authenticationToken.access_token;
                }
                catch (Exception ex)
                {

                }
            }

            parameters = new NameValueCollection();
            parameters.Add("grant_type", "password");
            parameters.Add("username", user);
            parameters.Add("password", password);

            var resultByte = client.UploadValues(URL + "/oauth/token", "POST", parameters);
            _authenticationToken = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticationToken>(Encoding.Default.GetString(resultByte));
            return _authenticationToken.access_token;

        }



    }
}