using Microsoft.Owin;
using Owin;
using SSO.SGP.Web;

namespace SSO.SGP.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}