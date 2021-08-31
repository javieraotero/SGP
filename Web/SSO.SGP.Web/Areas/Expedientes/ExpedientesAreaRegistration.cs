using System.Web.Mvc;

namespace SSO.SGP.Web.Areas.Expedientes
{
    public class ExpedientesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Expedientes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Expedientes_default",
                "Expedientes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
