using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;
using Syncrosoft.Framework.Utils.Logs;
using Newtonsoft.Json;

namespace SSO.SGP.Web
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            BundleTable.EnableOptimizations = true;

            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

        }

        protected void Application_Error()
        {
            Exception ex = Server.GetLastError().GetBaseException();


            if (!IsSessionTimedOut())
            {
                Logger.GrabarExcepcion(ex, false);
                Session["App_Error"] = ex.Message;
                Server.ClearError();
                //Response.Redirect("~/Page_Error.aspx");
            }
            else
            {
                Logger.GrabarExcepcion(ex, false);
                Server.ClearError();
                //Response.Redirect("~/Autenticacion.aspx");
            }
        }

        bool IsSessionTimedOut()
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
                throw new Exception("Este método sólo se puede usar en una aplicación Web");

            //Comprobamos que haya sesión en primer lugar 
            //(por ejemplo si por ejemplo EnableSessionState=false)
            if (ctx.Session == null)
                return false;   //Si no hay sesión, no puede caducar
            //Se comprueba si se ha generado una nueva sesión en esta petición
            if (!ctx.Session.IsNewSession)
                return false;   //Si no es una nueva sesión es que no ha caducado

            HttpCookie objCookie = ctx.Request.Cookies["ASP.NET_SessionId"];
            //Esto en teoría es imposible que pase porque si hay una 
            //nueva sesión debería existir la cookie, pero lo compruebo porque
            //IsNewSession puede dar True sin ser cierto (más en el post)
            if (objCookie == null)
                return false;

            //Si hay un valor en la cookie es que hay un valor de sesión previo, pero como la sesión 
            //es nueva no debería estar, por lo que deducimos que la sesión anterior ha caducado
            if (!string.IsNullOrEmpty(objCookie.Value))
                return true;
            else
                return false;
        }
    }
}