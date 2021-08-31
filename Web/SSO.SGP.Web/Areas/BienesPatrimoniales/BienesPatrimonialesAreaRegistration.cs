using System.Web.Mvc;

namespace SSO.SGP.Web.Areas.BienesPatrimoniales
{
    public class BienesPatrimonialesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BienesPatrimoniales";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BienesPatrimoniales_default",
                "BienesPatrimoniales/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
