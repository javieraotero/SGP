using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using SSO.SGP.Web.Filters;
using SSO.SGP.Web.Models;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.ReglasDeNegocio;
using Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using SSO.Common.Utils;
using SSO.SGP.AccesoADatos;

namespace SSO.SGP.Web.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        private AgentesAD oAgentes = new AgentesAD();


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login 

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                SessionHelper.NombrePersona = model.UserName;

                var roles = Roles.GetRolesForUser(model.UserName);

                var u = oUsuarios.ObtenerPorUsuario(model.UserName);
                // var roles = oUsuarios.ObtenerRoles(u.Id);
                var agente = oAgentes.ObtenerPorPesona(u.Persona);

                var nombramiento = agente.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).FirstOrDefault();

                var organismo = nombramiento.Organismo;
                var organismo_descripcion = nombramiento.Organismos.Descripcion;

                var mp = nombramiento.Organismos.UnidadOrganizacionRRHH == 2;

                var requiere_subrogante = nombramiento.Cargos.Grupo == 1 ? true : false;
                if (!requiere_subrogante && agente.RequiereSubrogante)
                    requiere_subrogante = true;

                if (nombramiento.Cargos.Grupo == 5)
                    requiere_subrogante = true;

                SessionHelper.CambiarClave = model.Password == "aaa123";
                SessionHelper.NombrePersona = u.Usuario;
                SessionHelper.OficinaActual = organismo;
                SessionHelper.OficinaActualDescripcion = organismo_descripcion;
                SessionHelper.AppExterna = false;
                SessionHelper.EmailAgente = agente.Email;
                SessionHelper.Es_Funcionario = requiere_subrogante;
                SessionHelper.habilita_aprobar_licencia = true;
                SessionHelper.es_MP = mp;
                SessionHelper.Roles = roles.ToList();

                if (mp && nombramiento.Cargo != 5) {
                    SessionHelper.habilita_aprobar_licencia = false;
                }

                //u.OrganismoUltimoIngreso = 829;
                //oUsuarios.Actualizar(u);

                return RedirectToLocal("/");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
            return View(model);
        }
        
        [AllowAnonymous]
        public JsonResult encrypt(string user)
        {

            return this.Json(EncriptacionSHA1.Encriptar(user), JsonRequestBehavior.AllowGet); 
            
        }

        [HttpPost]
        public ActionResult ValidarUsuarioExterno(string password)
        {
            if (SessionHelper.AppExterna)
            {
                var clave = EncriptacionSHA1.Encriptar(password);
                var oUsuario = new UsuariosAD();
                var x = oUsuario.LoginExternal(SessionHelper.NombrePersona, clave).ToList();
                if (x.Count > 0)
                {
                    return this.Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return this.Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginInternal(string user, string returnUrl, int operation)
        {
            if (ModelState.IsValid && WebSecurity.Login("viaticos", "aaa123", persistCookie: false))
            {
                var x = user;//"mdietrich";//EncriptacionSHA1.Decrypt(user);
                var usuario = oUsuarios.LoginPartial(x);

                SessionHelper.IdUsuario = usuario.usuario_id;
                SessionHelper.NombrePersona = usuario.usuario;
                SessionHelper.OficinaActual = usuario.organismo;
                SessionHelper.OficinaActualDescripcion = usuario.organismo_descripcion;
                SessionHelper.AppExterna = true;
                SessionHelper.IdUsuarioAppExterna = WebSecurity.CurrentUserId;
                SessionHelper.Es_Funcionario = usuario.es_funcionario;
                SessionHelper.Operacion_Default = operation;
                SessionHelper.EmailAgente = usuario.email_agente;
                SessionHelper.es_MP = usuario.mp;
                SessionHelper.habilita_aprobar_licencia = usuario.habilita_aprobar_licencia;

                //u.OrganismoUltimoIngreso = 829;
                //oUsuarios.Actualizar(u);

                return RedirectToLocal("/");
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
            return View();
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordRecovery()
        {
            string mailUsuario = Request.Form["Email"];
            //Mandar mail con el password
            return View();
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginExternal(string user, string password)
        {
            var clave = EncriptacionSHA1.Encriptar(password);
            var oUsuario = new UsuariosAD();
            var x = oUsuario.LoginExternal(user, clave).ToList();

            if (x.Count > 0)
            {
                var u = x.FirstOrDefault();
                SessionHelper.OficinaActual = u.OrganismoUltimoIngreso;
                return this.Json(new { Id = u.Id, ApellidoYNombre = u.ApellidoYNombre, Estado = u.Estado, Correo = u.Correo}, JsonRequestBehavior.AllowGet);
            } else
                return this.Json(new { Id = 0 }, JsonRequestBehavior.AllowGet);
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Intento de registrar al usuario
                try
                {
                    string confirmationToken = WebSecurity.CreateUserAndAccount(model.UserName, model.Password, null, true);

                    Usuarios oUsu = new Usuarios
                    {
                        Usuario = model.UserName.ToString(),
                        Correo = "mauricio@mail.com.ar"
                    };

                    new MailController().VerificationEmail(oUsu, confirmationToken).Deliver();

                    //WebSecurity.Login(model.UserName, model.Password);
                    //return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/Verify

        [AllowAnonymous]
        public ActionResult ValidarRegistro(string code)
        {
            if (WebSecurity.ConfirmAccount(code))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Account", "Login");
            }
        }

        //
        // POST: /Account/Disassociate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Desasociar la cuenta solo si el usuario que ha iniciado sesión es el propietario
            if (ownerAccount == User.Identity.Name)
            {
                // Usar una transacción para evitar que el usuario elimine su última credencial de inicio de sesión
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "La contraseña se ha cambiado."
                : message == ManageMessageId.SetPasswordSuccess ? "Su contraseña se ha establecido."
                : message == ManageMessageId.RemoveLoginSuccess ? "El inicio de sesión externo se ha quitado."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword iniciará una excepción en lugar de devolver false en determinados escenarios de error.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "La contraseña actual es incorrecta o la nueva contraseña no es válida.");
                    }
                }
            }
            else
            {
                // El usuario no dispone de contraseña local, por lo que debe quitar todos los errores de validación generados por un
                // campo OldPassword
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", String.Format("No se puede crear una cuenta local. Es posible que ya exista una cuenta con el nombre \"{0}\".", User.Identity.Name));
                    }
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // Si el usuario actual ha iniciado sesión, agregue la cuenta nueva
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // El usuario es nuevo, solicitar nombres de pertenencia deseados
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insertar un nuevo usuario en la base de datos
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Comprobar si el usuario ya existe
                    if (user == null)
                    {
                        // Insertar el nombre en la tabla de perfiles
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        #region Aplicaciones auxiliares
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de códigos de estado.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un nombre de usuario para esa dirección de correo electrónico. Escriba una dirección de correo electrónico diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña especificada no es válida. Escriba un valor de contraseña válido.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La dirección de correo electrónico especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario especificado no es válido. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.ProviderError:
                    return "El proveedor de autenticación devolvió un error. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "La solicitud de creación de usuario se ha cancelado. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                default:
                    return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";
            }
        }
        #endregion

        #region Gestion de Usuarios

        private UsuariosRN oUsuariosRN = new UsuariosRN();
        private webpages_RolesRN oWebpages_RolesRN = new webpages_RolesRN();
        private UsuariosAD oUsuarios = new UsuariosAD();

        //
        // GET: /Account/Default
        public ActionResult Default()
        {
            return View();
        }

        //
        // GET: /Account/IndexUsuarios
        [Authorize(Roles = "Administrador")]
        public ActionResult IndexUsuarios()
        {
            return View(oUsuariosRN.ObtenerTodo());
        }

        [Authorize(Roles = "Administrador")]
        public DataTablesResult<UsuariosView> getUsuarios(DataTablesParam dataTableParam)
        {

            return DataTablesResult.Create(this.oUsuariosRN.ObtenerParaGrilla(false), dataTableParam, user => new UsuariosView()
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Login = user.Login,
                Activo = user.Activo
                //Roles = obtenerRoles(user.Id)
            });
        }

        private string obtenerRoles(int u)
        {
            return oWebpages_RolesRN.obtenerNombreRolesPor(u);
        }

        //
        // GET: /Account/CreateUsuario
        [Authorize(Roles = "Administrador")]
        public ActionResult CreateUsuario()
        {
            return View();
        }

        //
        // POST: /Account/CreateUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult CreateUsuario(RegisterModel usuario)
        {
            if (!ModelState.IsValid)
            {
                return Json(new object[] { false, "No se pudo guardar" });
            }
            else
            {
                // Intento de registrar al usuario
                try
                {
                    WebSecurity.CreateUserAndAccount(usuario.UserName, usuario.Password, new
                    {
                        NombrePersona = usuario.NombrePersona,
                        Domicilio = Request.Form["Domicilio"],
                        Telefono = Request.Form["Telefono"],
                        Celular = Request.Form["Celular"],
                        Email = Request.Form["Email"],
                        FechaAlta = DateTime.Now
                    });
                    return Json(new object[] { true, "Usuario guardado" });
                }
                catch (MembershipCreateUserException e)
                {
                    return Json(new object[] { false, ErrorCodeToString(e.StatusCode) });
                }
            }
        }

        //
        // GET: /Account/EditUsuario/5
        [Authorize(Roles = "Administrador")]
        public ActionResult EditUsuario(int id = 0)
        {
            Usuarios oUsuario = this.oUsuariosRN.ObtenerPorId(id);
            ViewBag.Usuario = oUsuario.Usuario;

            UsuariosPassword userPsw = new UsuariosPassword(oUsuario);
            if (oUsuario == null)
            {
                return HttpNotFound();
            }

            return View(userPsw);
        }

        //
        // POST: /Account/EditUsuario/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult EditUsuario(UsuariosPassword usuarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuarios oUsuario = oUsuariosRN.ObtenerPorId(usuarios.Id);
                    oUsuario.Usuario = usuarios.Usuario;
                    //oUsuario.Domicilio = usuarios.Domicilio;
                    //oUsuario.Telefono = usuarios.Telefono;
                    //oUsuario.Celular = usuarios.Celular;
                    oUsuario.Correo = usuarios.Correo;

                    oUsuariosRN.Actualizar(oUsuario);

                    bool cambiarPass = true;
                    if (!string.IsNullOrEmpty(usuarios.NewPassword) && !string.IsNullOrWhiteSpace(usuarios.NewPassword))
                        cambiarPass = WebSecurity.ResetPassword(WebSecurity.GeneratePasswordResetToken(oUsuario.Usuario, 60), usuarios.NewPassword);

                    if (cambiarPass)
                        return Json(new object[] { true, String.Format("El usuario {0} se guardó satisfactoriamente", usuarios.Usuario) });
                    else
                        return Json(new object[] { true, String.Format("No se pudo cambiar el password", usuarios.Usuario) });
                }
                catch (Exception)
                {
                    return Json(new object[] { false, String.Format("El usuario {0} no ha podido guardarse", usuarios.Usuario) });
                }
            }
            else
            {
                return Json(new object[] { false, String.Format("Ocurrió un error al guardar el usuario {0}", usuarios.Usuario) });
            }
        }

        //
        // GET: /Account/DeleteUsuario/5
        public ActionResult DeleteUsuario(int id = 0)
        {
            Usuarios usuarios = this.oUsuariosRN.ObtenerPorId(id);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            return View(usuarios);
        }

        //
        // POST: /Account/DeleteUsuario/5
        [HttpPost, ActionName("DeleteUsuario")]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Usuarios oUsuario = this.oUsuariosRN.ObtenerPorId(id);

                string Mensaje = "";

                if (oUsuario.FechaEliminacion == null)
                {
                    oUsuario.FechaEliminacion = DateTime.Now;
                    int y = oUsuariosRN.ActivarUsuario(id, false);
                    Mensaje = "El Usuario fue desactivado";
                }
                else
                {
                    oUsuario.FechaEliminacion = null;
                    int y = oUsuariosRN.ActivarUsuario(id, true);
                    Mensaje = "El Usuario fue Activado nuevamente";
                }

                //if (oUsuario.webpages_Roles.Count > 0)
                //    Roles.RemoveUserFromRoles(oUsuario.Login, oUsuario.webpages_Roles.Select(u => u.RoleName).ToArray());


                //((SimpleMembershipProvider)Membership.Provider).DeleteUser(oUsuario.Usuario, true);
                //((SimpleMembershipProvider)Membership.Provider).DeleteAccount(oUsuario.Login);

                //MembershipUser A = Membership.GetUser(oUsuario.Login);
                //A.IsApproved = false;
                //((SimpleMembershipProvider)Membership.Provider).UpdateUser(A);


                this.oUsuariosRN.Actualizar(oUsuario);

                return Json(new object[] { true, Mensaje });
            }
            catch (Exception ex)
            {
                return Json(new object[] { false, "El usuario no pudo ser eliminado" });
            }
        }

        //
        // GET: /Account/EditRoles/5
        [Authorize(Roles = "Administrador")]
        public ActionResult EditRoles(int id = 0)
        {
            Usuarios oUsuario = this.oUsuariosRN.ObtenerPorId(id);
            ViewBag.IdUsuarioSel = id;
            ViewBag.webpages_Roles = new SelectList(oWebpages_RolesRN.ObtenerTodo(), "RoleId", "RoleName");

            if (oUsuario == null)
            {
                return HttpNotFound();
            }

            return View(oUsuario);
        }

        //
        // POST: /Account/EditRoles/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult EditRoles(int idUsuario, string nombreRol)
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
                //Mostrar excepcion en Divs Coloreados

                //Vuelvo a cargar la vista
                //return View();
                return Json(new object[] { false, "No se pudo guardar" });
            }
        }

        //
        // POST: /Account/DeleteRol/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteRol(int idUsuario, string nombreRol)
        {
            try
            {
                //Uso un procedimiento almacenado para eliminar el registro de la BD
                //oWebpages_RolesRN.EliminarRol(idUsuario, idRol);

                Usuarios user = this.oUsuariosRN.ObtenerPorId(idUsuario);
                Roles.RemoveUserFromRole(user.Usuario, nombreRol);

                return Json(new object[] { true, "El rol fue quitado" });
            }
            catch (Exception ex)
            {
                return Json(new object[] { false, "El rol no pudo ser quitado" });
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.oUsuariosRN.Dispose();
            base.Dispose(disposing);
        }

        //
        // POST: /Account/ResetPassword/5
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult ResetPassword(int idUsuario, string newPass)
        {
            try
            {
                Usuarios oUsuario = this.oUsuariosRN.ObtenerPorId(idUsuario);
                // WebSecurity.ResetPassword(WebSecurity.GeneratePasswordResetToken(oUsuario.Usuario), newPass);

                return Json(new object[] { true, "La contraseña fue actualizada con exito." });
            }
            catch (Exception ex)
            {
                return Json(new object[] { false, "La contraseña no pudo ser actualizada." });
            }
        }

        #endregion

    }
}
