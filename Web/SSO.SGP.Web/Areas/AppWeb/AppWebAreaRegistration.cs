using System.Web.Mvc;

namespace SSO.SGP.Web.Areas.AppWeb
{
    public class AppWebAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AppWeb";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AppWeb_default",
                "AppWeb/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
