using System.Web.Mvc;

namespace SSO.SGP.Web.Areas.Sistemas
{
    public class SistemasAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sistemas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Sistemas_default",
                "Sistemas/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
