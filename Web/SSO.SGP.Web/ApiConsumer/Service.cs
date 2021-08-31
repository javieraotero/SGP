using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using SSO.SGP.Web.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace SSO.SGP.Web.BasicConsumer
{
    public static class ServiceWithOAuth
    {

        public static dynamic post<T>(T objeto, string WebApi)
        {
            var client = new System.Net.WebClient();
            client.Headers = TokenManager.GetAuthenticationHeader(ApiUrlManager.BaseUrl, System.Configuration.ConfigurationManager.AppSettings["UserWebApi"].ToString(), System.Configuration.ConfigurationManager.AppSettings["PasswordWebApi"].ToString());
            client.Headers["Content-Type"] = "application/json";
            var dataString = JsonConvert.SerializeObject(objeto);
            client.Encoding = Encoding.ASCII;
            var result = client.UploadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi), "POST", dataString);
            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        public static dynamic put<T>(T objeto, string WebApi)
        {
            var client = new System.Net.WebClient();
            client.Headers = TokenManager.GetAuthenticationHeader(ApiUrlManager.BaseUrl, System.Configuration.ConfigurationManager.AppSettings["UserWebApi"].ToString(), System.Configuration.ConfigurationManager.AppSettings["PasswordWebApi"].ToString());
            client.Headers["Content-Type"] = "application/json";
            var dataString = JsonConvert.SerializeObject(objeto);
            client.Encoding = Encoding.ASCII;
            var result = client.UploadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi), "PUT", dataString);
            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        public static T get<T>(object objeto, string WebApi)
        {
            //Response.Charset = "utf-8";
            var client = new System.Net.WebClient();
            client.Headers = TokenManager.GetAuthenticationHeader(ApiUrlManager.BaseUrl, System.Configuration.ConfigurationManager.AppSettings["UserWebApi"].ToString(), System.Configuration.ConfigurationManager.AppSettings["PasswordWebApi"].ToString());
            client.Encoding = Encoding.UTF8;
            client.Headers["Content-Type"] = "application/json";            
            string parameters = objectToUrl(objeto);
            var result = client.DownloadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi + "/?" + parameters));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);

        }

        public static List<T> getList<T>(object objeto, string WebApi)
        {
            var client = new System.Net.WebClient();
            client.Headers = TokenManager.GetAuthenticationHeader(ApiUrlManager.BaseUrl, System.Configuration.ConfigurationManager.AppSettings["UserWebApi"].ToString(), System.Configuration.ConfigurationManager.AppSettings["PasswordWebApi"].ToString());
            client.Headers["Content-Type"] = "application/json";            
            string parameters = objectToUrl(objeto);
            var result = client.DownloadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi + "/?" + parameters));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result);

        }

        private static string objectToUrl(dynamic obj) {

            var result = new List<string>();
            foreach (var property in TypeDescriptor.GetProperties(obj))
            {
                result.Add(property.Name + "=" + property.GetValue(obj));
            }

            return string.Join("&", result);

        }

    }

    public static class Service
    {

        public static dynamic post<T>(T objeto, string WebApi)
        {
            Dictionary<string, object> dict =
            objeto.GetType()
            .GetProperties()
            .ToDictionary(pi => pi.Name, pi => pi.GetValue(objeto, null));

            NameValueCollection formFields = new NameValueCollection();

            foreach (KeyValuePair<string, object> item in dict)
            {
                formFields.Add(item.Key, item.Value.ToString());
            }

            var client = new System.Net.WebClient();
            var dataString = JsonConvert.SerializeObject(objeto);
            client.Encoding = Encoding.ASCII;
            var p = objectToParameter(objeto);

            byte[] response = client.UploadValues(new Uri(WebApi), formFields);

            var result = System.Text.Encoding.UTF8.GetString(response);

            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        public static dynamic put<T>(T objeto, string WebApi)
        {
            var client = new System.Net.WebClient();           
            client.Headers["Content-Type"] = "application/json";
            var dataString = JsonConvert.SerializeObject(objeto);
            client.Encoding = Encoding.ASCII;
            var result = client.UploadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi), "PUT", objectToParameter(objeto));
            return JsonConvert.DeserializeObject<dynamic>(result);
        }

        public static T get<T>(object objeto, string WebApi)
        {
            //Response.Charset = "utf-8";
            var client = new System.Net.WebClient();          
            client.Encoding = Encoding.UTF8;
            client.Headers["Content-Type"] = "application/json";         
            string parameters = objectToUrl(objeto);
            var result = client.DownloadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi + "/?" + parameters));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(result);

        }

        public static List<T> getList<T>(object objeto, string WebApi)
        {
            var client = new System.Net.WebClient();
            //client.Headers = TokenManager.GetAuthenticationHeader(ApiUrlManager.BaseUrl, System.Configuration.ConfigurationManager.AppSettings["UserWebApi"].ToString(), System.Configuration.ConfigurationManager.AppSettings["PasswordWebApi"].ToString());
            client.Headers["Content-Type"] = "application/json";
            //var result = client.DownloadString(new Uri(ApiUrlManager.BaseUrl + "/api/TTArchivos/GetTunnel?user=" + Convert.ToString(ConfigurationManager.AppSettings["user"]) + "&password=" + Convert.ToString(ConfigurationManager.AppSettings["password"]) + ""));
            string parameters = objectToUrl(objeto);
            var result = client.DownloadString(new Uri(ApiUrlManager.BaseUrl + "api/" + WebApi + "/?" + parameters));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result);

        }

        private static string objectToUrl(dynamic obj)
        {

            var result = new List<string>();
            foreach (var property in TypeDescriptor.GetProperties(obj))
            {
                result.Add(property.Name + "=" + property.GetValue(obj));
            }

            return string.Join("&", result);

        }

        private static string objectToParameter(dynamic obj)
        {           
            var result = new List<string>();
            foreach (var property in TypeDescriptor.GetProperties(obj))
            {
                result.Add(property.Name + "=" + property.GetValue(obj));
            }

            return string.Join("&", result);
        }

    }
}
