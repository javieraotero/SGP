using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSO.SGP.EntidadesDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.ReglasDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System;
using System.Data;
using WebMatrix.WebData;
using System.Web.Security;
using Manatee.Trello.ManateeJson;
using Manatee.Trello;
using Manatee.Trello.WebApi;
using SSO.Common.Utils;
using System.Collections.Generic;
using System.Net;

namespace SSO.SGP.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private webpages_RolesRN oWebpages_RolesRN = new webpages_RolesRN();
        private NoticiasAD oNoticias = new NoticiasAD();
        private EstadosUsuarioRefAD oEstados = new EstadosUsuarioRefAD();
        private CircunscripcionesRefAD oCircunscripciones = new CircunscripcionesRefAD();
        private CargosFuncionalesRefAD oCargos = new CargosFuncionalesRefAD();
        private OrganismosRefAD oOrganismos = new OrganismosRefAD();
        private AgentesAD oAgentes = new AgentesAD();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult InformarIncidencia()
        {
            return View();
        }

        public ActionResult MisIncidencias()
        {
            System.Net.ServicePointManager.Expect100Continue = true;
            System.Net.ServicePointManager.DefaultConnectionLimit = 4;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
            TrelloAuthorization.Default.AppKey = "acf026e9a41e049b3c1a80fb0b4e4c97";
            //TrelloAuthorization.Default.UserToken = "b6357356ab06bac7fdfd8e6eb966f621f1682ee7f6bd0a2e213ab43fd0b14757";
            TrelloAuthorization.Default.UserToken = "b6357356ab06bac7fdfd8e6eb966f621f1682ee7f6bd0a2e213ab43fd0b14757";

            var board = new Board(System.Configuration.ConfigurationManager.AppSettings["Trello.Board.Incidencias"]);

            var tarjeta = board.Cards.Where(c => c.Labels.Where(la => la.Name == SessionHelper.NombrePersona).Count() > 0).ToList();

            return View(tarjeta);
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        public DataTablesResult<UsuariosView> getUsuariosGrilla(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(this.oUsuariosRN.ObtenerParaGrilla(false), dataTableParam, user => new UsuariosView()
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Login = user.Login,
                Activo = user.Activo,
                //Roles = obtenerRoles(user.Id)
            });
        }

        private string obtenerRoles(int u)
        {
            return oWebpages_RolesRN.obtenerNombreRolesPor(u);
        }

        public ActionResult Crear()
        {
            ViewBag.Estado = new SelectList(oEstados.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Circunscripcion = new SelectList(oCircunscripciones.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Cargo = new SelectList(oCargos.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismoUltimoIngreso = new SelectList(oOrganismos.ObtenerTodo().ToList(), "Id", "Descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Usuarios usuario)
        {
            //if (ModelState.IsValid)
            //{
                try
                {

                    var clave = EncriptacionSHA1.Encriptar("aaa123");

                var u = new
                {
                    FechaAlta = DateTime.Now,
                    UsuarioAlta = SessionHelper.IdUsuario.Value,
                    FechaModificacion = DateTime.Now,
                    UsuarioModifica = SessionHelper.IdUsuario.Value,
                    AceptoTerminosCondiciones = true,
                    Conectado = false,
                    Clave = clave,
                    EsSubrogante = false,
                    TieneFirma = false,
                    OrganismoUltimoIngreso = usuario.OrganismoUltimoIngreso,
                    Cargo = usuario.Cargo,
                    Usuario = usuario.Usuario,
                    Correo = usuario.Correo,
                    Estado = 1,
                    Circunscripcion = usuario.Circunscripcion,
                    Persona = usuario.Persona,
                    ApellidoYNombre = usuario.ApellidoYNombre
                };


                    //oUsuariosRN.Guardar(usuarios);-
                    WebSecurity.CreateUserAndAccount(usuario.Usuario.ToString(), "aaa123", u);
                    //Roles.AddUserToRole(usuario.Usuario, "Consultas");
                    return Json(new object[] { true, String.Format("Se guardo el Usuario satisfactoriamente") });
                }
                catch (Exception e)
                {
                    return Json(new object[] { false, "No se ha podido guardar Usuarios" });
                }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No se ha podido guardar Usuarios" });
            //}
        }

        [HttpPost]
        public ActionResult Crear2(string ApellidoYNombre, string Usuario, string Correo, int Cargo, int Circunscricion, int OrganismoUltimoIngreso, int Persona, int Estado)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                var usuario = new Usuarios();

                var clave = EncriptacionSHA1.Encriptar("aaa123");

                usuario.ApellidoYNombre = ApellidoYNombre;
                usuario.Usuario = Usuario;
                usuario.Correo = Correo;
                usuario.Circunscripcion = Circunscricion;
                usuario.OrganismoUltimoIngreso = OrganismoUltimoIngreso;
                usuario.Persona = Persona;
                usuario.Estado = Estado;
                usuario.FechaAlta = DateTime.Now;
                usuario.UsuarioAlta = SessionHelper.IdUsuario.Value;
                usuario.FechaModificacion = DateTime.Now;
                usuario.UsuarioModifica = SessionHelper.IdUsuario.Value;
                usuario.AceptoTerminosCondiciones = true;
                usuario.Conectado = false;
                usuario.Clave = clave;
                usuario.EsSubrogante = false;
                usuario.TieneFirma = false;


                //oUsuariosRN.Guardar(usuarios);-
                WebSecurity.CreateUserAndAccount(usuario.Usuario.ToString(), "aaa123", usuario);
                //Roles.AddUserToRole(usuario.Usuario, "Consultas");
                return Json(new object[] { true, String.Format("Se guardo el Usuario satisfactoriamente") });
            }
            catch (Exception)
            {
                return Json(new object[] { false, "No se ha podido guardar Usuarios" });
            }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No se ha podido guardar Usuarios" });
            //}
        }

        [HttpPost]
        public ActionResult InformarIncidencia(string titulo, string descripcion, string vista) {

            try
            {

                System.Net.ServicePointManager.Expect100Continue = true;
                System.Net.ServicePointManager.DefaultConnectionLimit = 4;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var serializer = new ManateeSerializer();
                TrelloConfiguration.Serializer = serializer;
                TrelloConfiguration.Deserializer = serializer;
                TrelloConfiguration.JsonFactory = new ManateeFactory();
                TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
                TrelloAuthorization.Default.AppKey = "acf026e9a41e049b3c1a80fb0b4e4c97";
                //TrelloAuthorization.Default.UserToken = "b6357356ab06bac7fdfd8e6eb966f621f1682ee7f6bd0a2e213ab43fd0b14757";
                TrelloAuthorization.Default.UserToken = "b6357356ab06bac7fdfd8e6eb966f621f1682ee7f6bd0a2e213ab43fd0b14757";                

                var board = new Board(System.Configuration.ConfigurationManager.AppSettings["Trello.Board.Incidencias"]);

                Manatee.Trello.Label label;
                var l = board.Lists.First();
                var labels = board.Labels.Where(lab => lab.Name == SessionHelper.NombrePersona);
                if (labels.Count() == 0)
                    label = board.Labels.Add(SessionHelper.NombrePersona, LabelColor.Blue);
                else
                    label = labels.First();

                //string listId = "Reportado por Usuarios";
                //var list = new List(listId);
                var member = l.Board.Members.First();
                var card = l.Cards.Add("new card");
                card.Labels.Add(label);
                card.Members.Add(member);
                card.Name = titulo;
                card.Description = descripcion;
                card.DueDate = DateTime.Now.AddDays(2);

                return Json(new object[] { true, String.Format("La incidecia ha sido informada y el área de desarrollo ha sido notificada") });
            }
            catch (Exception e) {
                return Json(new object[] { false, String.Format("Ooops, ha ocurrido un error al enviar la incidencia") });
            }

        }

        [HttpPost]
        public ActionResult CambiarClave(CustomCambirClave claves)
        {
            if (WebSecurity.CurrentUserName != "viaticos")
            {

                try
                {
                    if (WebSecurity.ChangePassword(WebSecurity.CurrentUserName, claves.ClaveActual, claves.ClaveNueva))
                        return Json(new object[] { true, String.Format("Su clave ha sido modificada satisfactoriamente") });
                    else
                        return Json(new object[] { false, "Su clave no ha podido ser modificada" });
                }
                catch (Exception e)
                {
                    return Json(new object[] { false, "Su clave no ha podido ser modificada" });
                }
            }
            else {
                return Json(new object[] { false, "No puede modificar su clave desde este sistema. Use SIGE o SIGELP." });
            }
        }

        [HttpPost]
        public ActionResult ResetearClave(string usuario)
        {
            try
            {
                if (WebSecurity.UserExists(usuario))
                {
                    var token = WebSecurity.GeneratePasswordResetToken(usuario);
                    var result = WebSecurity.ResetPassword(token, "aaa123");

                    return Json(new object[] { true, "La clave del usuario " + usuario + " ha sido reseteada satisfactoriamente" });
                }
                else {

                    var u = oUsuariosRN.ObtenerPorUsuario(usuario);

                    WebSecurity.CreateUserAndAccount(usuario, "aaa123", u);

                    return Json(new object[] { true, "Se generó la clave SGP para el usuario " + usuario + "." });
                }

            }
            catch (Exception ex) {
                var u = oUsuariosRN.ObtenerPorUsuario(usuario);

                var a = oAgentes.ObtenerPorPesona(u.Persona);
                var organismo = a.Nombramientos.Where(x => !x.FechaDeBaja.HasValue && !x.FechaEliminacion.HasValue).FirstOrDefault().Organismo;

                WebSecurity.CreateAccount(usuario, "aaa123", false);

                return Json(new object[] { true, "Se generó la clave SGP para el usuario " + usuario + "." });

                //return Json(new object[] { false, "La clave del usuario " + usuario + " NO ha podido ser reseteada" }); 
            }
        }

        [HttpPost]
        public ActionResult Editar(Usuarios usuarios)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    usuarios.Usuario = usuarios.Usuario.ToString();
                    usuarios.FechaModificacion = DateTime.Now;
                    usuarios.UsuarioModifica = SessionHelper.IdUsuario.Value;
                    //usuarios.UsuarioModifica = SessionHelper.IdUsuario.Value;
                    //usuarios.FechaModifica = DateTime.Now;

                    oUsuariosRN.Actualizar(usuarios);

                    return Json(new object[] { true, String.Format("Se guardo satisfactoriamente Usuarios") });
                }
                catch (Exception)
                {
                    return Json(new object[] { false, "No pudo guardarse Usuarios" });
                }
            //}
            //else
            //{
            //    return Json(new object[] { false, "No pudo guardarse Usuarios" });
            //}

        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.Estado = new SelectList(oEstados.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Circunscripcion = new SelectList(oCircunscripciones.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.Cargo = new SelectList(oCargos.ObtenerTodo().ToList(), "Id", "Descripcion");
            ViewBag.OrganismoUltimoIngreso = new SelectList(oOrganismos.ObtenerTodo().ToList(), "Id", "Descripcion");

            Usuarios usuarios = oUsuariosRN.ObtenerPorId(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }


        //[HttpPost, ActionName("Eliminar")]
        //public ActionResult EliminarConfirmado(int id)
        //{
        //    try
        //    {
        //        //oUsuariosRN.Eliminar(id);
        //        Usuarios oUsuario = this.oUsuariosRN.ObtenerPorId(id);

        //        string Mensaje = "";

        //        if (oUsuario.FechaBaja == null)
        //        {
        //            oUsuario.Activo = false;
        //            oUsuario.FechaBaja = DateTime.Now;
        //            int y = oUsuariosRN.ActivarUsuario(id, false);
        //            Mensaje = "El Usuario fue desactivado";
        //        }
        //        else
        //        {
        //            oUsuario.Activo = true;
        //            oUsuario.FechaBaja = null;
        //            int y = oUsuariosRN.ActivarUsuario(id, true);
        //            Mensaje = "El Usuario fue Activado nuevamente";
        //        }

        //        this.oUsuariosRN.Actualizar(oUsuario);
        //        return Json(new object[] { true, Mensaje });
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new object[] { false, "No pudo eliminarse el usuarios" });
        //    }
        //}

        //public JsonResult JsonT(string term)
        //{
        //    var res = from x in this.oUsuariosRN.JsonT(term)
        //              select x;
        //    return this.Json(res, JsonRequestBehavior.AllowGet);
        //}

        //--- Utilizar esta acción para Autocomplete
        //public JsonResult JsonOptions(string term)
        //{
        //    var res = from x in this.oUsuariosRN.ObtenerOptions(term)
        //              select x;
        //    return this.Json(res, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult Eliminar(int id = 0)
        {
            Usuarios usuarios = oUsuariosRN.ObtenerPorId(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }



        protected override void Dispose(bool disposing)
        {
            oUsuariosRN.Dispose();

            base.Dispose(disposing);
        }

        //
        // GET: /Account/EditRoles/5
        public ActionResult EditarRoles(int id = 0)
        {
            Usuarios oUsuario = this.oUsuariosRN.ObtenerPorId(id);
            ViewBag.IdUsuarioSel = id;
            ViewBag.NombrePersonaSel = oUsuario.ApellidoYNombre;
            ViewBag.NombreUsuarioSel = oUsuario.Usuario;

            return View(oWebpages_RolesRN.ObtenerTodo().ToList());
        }

        //
        // POST: /Account/EditRoles/5
        [HttpPost]
        public ActionResult AsignarRol(int idUsuario, string nombreRol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new object[] { false, "No se pudo guardar" });
                }
                else
                {
                    if (string.IsNullOrEmpty(nombreRol))
                    {
                        return Json(new object[] { false, "Seleccione un rol a agregar" });

                    }
                    Usuarios user = this.oUsuariosRN.ObtenerPorId(idUsuario);

                    bool YaAsigando = false;

                    foreach (webpages_Roles R in user.webpages_Roles)
                    {
                        if (R.RoleName == nombreRol)
                        {
                            YaAsigando = true;
                            break;
                        }
                    }

                    if (YaAsigando)
                    {
                        return Json(new object[] { false, "El Rol ya esta asignado" });
                    }


                    Roles.AddUserToRole(user.Usuario, nombreRol);

                    return Json(new object[] { true, "Rol asignado correctamente" });
                }
            }
            catch (Exception ex)
            {
                return Json(new object[] { false, "No se pudo guardar" });
            }
        }

        //
        // POST: /Account/DeleteRol/5
        [HttpPost]
        public ActionResult DeleteRol(int idUsuario, string nombreRol)
        {
            try
            {
                Usuarios user = this.oUsuariosRN.ObtenerPorId(idUsuario);
                Roles.RemoveUserFromRole(user.Usuario, nombreRol);

                return Json(new object[] { true, "El rol fue quitado" });
            }
            catch (Exception ex)
            {
                return Json(new object[] { false, "El rol no pudo ser quitado" });
            }
        }

    } //fin de clase
}
