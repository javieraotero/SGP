using System.Web.Mvc;

namespace SSO.SGP.Web.Areas.Suministros
{
    public class SuministrosAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Suministros";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Suministros_default",
                "Suministros/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
