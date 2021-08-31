using System.Collections.Generic;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.ReglasDeNegocio;
using WebMatrix.WebData;
using SSO.SGP.Web.Filters;
using SSO.SGP.AccesoADatos;
using System.Linq;

namespace SSO.SGP.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class MenuesController : Controller
    {
        MenusRN oMenu = new MenusRN();
        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private OrganismosRefAD oOrganismo = new OrganismosRefAD();
        private AgentesAD oAgentes = new AgentesAD();

        protected override void Dispose(bool disposing)
        {
            oMenu.Dispose();
            base.Dispose(disposing);
        }

        public void iniciarValoresSesion()
        {
            if (SessionHelper.IdUsuario == null || SessionHelper.IdUsuario != WebSecurity.CurrentUserId)
            {
                SessionHelper.IdUsuario = WebSecurity.CurrentUserId;
                //SessionHelper.u = WebSecurity.CurrentUserName;
            }
        }

        public ActionResult GenerarNotificaciones(string Titulo, List<Notificaciones> lista)
        {
            iniciarValoresSesion();
            List<Notificacionesadm> listaNotif = new List<Notificacionesadm>();


            //for (int i = 0; i < 4; i++)
            //{
            //    oNotif.Tipo = eNotificaciones.warning;
            //    oNotif.Descripcion = "Notificacion N� " + i.ToString();
            //    listaNotif.Add(oNotif);
            //}

            Titulo = "Notificaciones";

            ViewBag.Titulo = Titulo;
            return View(listaNotif);
        }

        public ActionResult MenuHorizontal()
        {
            if (SessionHelper.IdUsuario == null || SessionHelper.IdUsuario != WebSecurity.CurrentUserId)
            {
                SessionHelper.IdUsuario = WebSecurity.CurrentUserId;
                SessionHelper.NombrePersona = WebSecurity.CurrentUserName;
            }

            ViewBag.Usuario = SessionHelper.NombrePersona;
            UsuariosRN oUsuariosRN = new UsuariosRN();
            Usuarios oUsu = oUsuariosRN.ObtenerPorId(SessionHelper.IdUsuario.Value);

            SessionHelper.AmbitoActual = oUsu.SubAmbito;
            SessionHelper.FueroActual = oUsu.SubAmbitos.Fuero;

            List<Menus> lista = new List<Menus>();

            foreach (var rol in oUsu.webpages_Roles)
            {
                SessionHelper.MenuDefault = rol.ItemMenuDefault;
                foreach (var menu in rol.Menus)
                {
                    if (!lista.Contains(menu))
                        lista.Add(menu);
                }
            }

            return View(lista);
        }

        [HttpPost]
        public JsonResult mantenerSesion()
        {
            if (WebSecurity.CurrentUserId != -1)
            {
                if (SessionHelper.IdUsuario == null || (SessionHelper.IdUsuario != WebSecurity.CurrentUserId && !SessionHelper.AppExterna))
                {
                    SessionHelper.IdUsuario = WebSecurity.CurrentUserId;
                    SessionHelper.NombrePersona = WebSecurity.CurrentUserName;

                    Usuarios oUsu = oUsuariosRN.ObtenerPorId(SessionHelper.IdUsuario.Value);
                    OrganismosRef organismo = oOrganismo.ObtenerPorId(oUsu.OrganismoUltimoIngreso.Value);

                    SessionHelper.AmbitoActual = oUsu.SubAmbito;
                    SessionHelper.FueroActual = oUsu.SubAmbitos.Fuero;
                    SessionHelper.OficinaActual = oUsu.OrganismoUltimoIngreso;
                    SessionHelper.UnidadDeOrganizacion = organismo.UnidadOrganizacionRRHH;
                    SessionHelper.OficinaActualDescripcion = organismo.Descripcion;
                }
                return Json(new object[] { true });
            }
            else
            {
                return Json(new object[] { false });
            }
        }

        public ActionResult GenerarItemsMenus()
        {
            if (SessionHelper.IdUsuario == null || (SessionHelper.IdUsuario != WebSecurity.CurrentUserId && !SessionHelper.AppExterna))
            {
                SessionHelper.IdUsuario = WebSecurity.CurrentUserId;
                SessionHelper.NombrePersona = WebSecurity.CurrentUserName;
            }

            ViewBag.Usuario = SessionHelper.NombrePersona;
            UsuariosRN oUsuariosRN = new UsuariosRN();
            Usuarios oUsu = oUsuariosRN.ObtenerPorId(SessionHelper.AppExterna ? WebSecurity.CurrentUserId : SessionHelper.IdUsuario.Value);
            //OrganismosRef organismo = oOrganismo.ObtenerPorId(oUsu.OrganismoUltimoIngreso.Value);

            var agente = oAgentes.ObtenerPorPesona(oUsu.Persona);
            var organismo = agente.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Organismos;

            //var nombramiento = agente.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault();

            if (!SessionHelper.OficinaActual.HasValue)
            {
                SessionHelper.AmbitoActual = oUsu.SubAmbito;
                SessionHelper.FueroActual = oUsu.SubAmbito.HasValue ? oUsu.SubAmbitos.Fuero : default(int?);
                SessionHelper.OficinaActual = oUsu.OrganismoUltimoIngreso;
                SessionHelper.UnidadDeOrganizacion = organismo.UnidadOrganizacionRRHH;
                SessionHelper.OficinaActualDescripcion = organismo.Descripcion;
            }

            List<Menus> lista = new List<Menus>();

            foreach (var rol in oUsu.webpages_Roles)
            {

                SessionHelper.MenuDefault = rol.ItemMenuDefault;
                foreach (var menu in rol.Menus)
                {
                    if (!lista.Contains(menu))
                        lista.Add(menu);
                }
            }

            return View(lista);
        }
    }
}