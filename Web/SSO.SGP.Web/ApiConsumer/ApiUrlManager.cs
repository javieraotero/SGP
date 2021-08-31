using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.Linq;
using System.Text;


namespace SSO.SGP.Web.BasicConsumer
{
    public static class ApiUrlManager
    {
        static ApiUrlManager()
        {
            _baseUrl = System.Configuration.ConfigurationManager.AppSettings["UrlWebApi"].ToString();
        }
        //Base url of service
        private static string _baseUrl;
        public static string BaseUrl { get { return _baseUrl; } }
    }
}
