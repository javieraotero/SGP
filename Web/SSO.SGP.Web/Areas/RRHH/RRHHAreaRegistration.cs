﻿using System.Web.Mvc;

namespace SSO.SGP.Web.Areas.RRHH
{
    public class RRHHAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "RRHH";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "RRHH_default",
                "RRHH/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
