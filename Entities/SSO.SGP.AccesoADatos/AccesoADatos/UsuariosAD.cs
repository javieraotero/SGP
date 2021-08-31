
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using SSO.SGP.EntidadesDeNegocio.Results;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
    /// <summary>
    /// Acceso a Datos Generada por el Generador de codigo.
    /// </summary>
    public partial class UsuariosAD
    {
        private BDEntities db = new BDEntities();

        public Usuarios ObtenerPorId(int Id)
        {
            return db.Usuarios.Single(c => c.Id == Id);
        }

        public Usuarios ObtenerPorUsuario(string usuario)
        {
            return db.Usuarios.Single(c => c.Usuario == usuario);
        }

        public DbQuery<Usuarios> ObtenerTodo()
        {
            return (DbQuery<Usuarios>)db.Usuarios.Where(c => c.FechaEliminacion == null);
        }

        public DbQuery<Usuarios> LoginExternal(string user, string password)
        {
            return (DbQuery<Usuarios>)db.Usuarios.Where(c => c.Usuario == user && c.Clave == password && c.Estado == 1);
        }

        public LoginResult LoginPartial(string user)
        {
            var login = new LoginResult() {
                usuario = user
            };

            var usuarios = db.Usuarios.Where(c => c.Usuario == user && c.Estado != 5);

            if (usuarios.Count() > 0) {

                var usuario = usuarios.FirstOrDefault();

                var agente = db.Agentes.Where(x => x.Persona == usuario.Persona).FirstOrDefault();
                var nombramiento = agente.Nombramientos.Where(x => !x.FechaDeBaja.HasValue).OrderByDescending(n=>n.FechaDeAlta).FirstOrDefault();

                var organismo = nombramiento.Organismo;
                var organismo_descripcion = nombramiento.Organismos.Descripcion;

                //var o = db.OrganismosRef.Where(x => x.Id == usuario.Persona).FirstOrDefault();

                var es_funcionario = nombramiento.Cargos.Grupo == 1;
                if (es_funcionario && !agente.RequiereSubrogante)
                    es_funcionario = false;

                if (nombramiento.Cargos.Grupo == 5)
                    es_funcionario = true;

                login.usuario_id = usuario.Id;
                login.organismo = organismo;
                login.organismo_descripcion = organismo_descripcion;
                login.cargo = nombramiento.Cargo;
                login.es_funcionario = es_funcionario;
                login.email_agente = agente.Email;
                login.mp = nombramiento.Organismos.UnidadOrganizacionRRHH == 2;
                login.habilita_aprobar_licencia = true;

                if (login.mp)
                    if (login.cargo != 5)
                        login.habilita_aprobar_licencia = false;

            }

            return login;
        }

        public DbQuery<UsuariosView> BuscarParaGrilla(bool SoloActivos)
        {
            var result = from u in db.Usuarios
                         where (!SoloActivos || u.FechaEliminacion == null)
                         select new UsuariosView
                         {
                             Id = u.Id,
                             Nombre = u.ApellidoYNombre,
                             Login = u.Usuario,                            
                             //Domicilio = u.Domicilio,
                             //Telefono = u.Telefono,
                             //Celular = u.Celular,
                             Activo = (u.FechaEliminacion == null ? "Si" : "No"),
                         };


            return (DbQuery<UsuariosView>)result;
        }

        public void Guardar(Usuarios Objeto)
        {
            try
            {
                db.Usuarios.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(Usuarios Objeto)
        {
            try
            {
                db.Usuarios.Attach(Objeto);
                db.Entry(Objeto).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Eliminar(int IdObjeto)
        {
            try
            {
                Usuarios Objeto = this.ObtenerPorId(IdObjeto);
                //Objeto.Activo = false;
                Objeto.FechaEliminacion = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

        /*********************************************
        * Seccion Particular
        * *******************************************/

        public DbQuery<Usuarios> ObtenerPorRol(int IdRol)
        {
            var result = from u in db.Usuarios
                         where u.FechaEliminacion == null
                         && u.webpages_Roles.Where(rol => (rol.RoleId == IdRol || rol.RoleId == 1)).Count() > 0
                         select u;

            return (DbQuery<Usuarios>)result;
        }

        //public List<int> ObtenerRoles(int IdUsuario)
        //{
        //    var result = (from r in db.webpages_UsersInRoles
        //                  where r.UserId == IdUsuario
        //                  select r.RoleId).ToList();
        //    return (List<int>)result;
        //}

        //todas las oficinas del usuario
        public DbQuery<OrganismosRef> ObtenerOficinas(int usuario) {

            var result = (from u in db.Usuarios
                          join o in db.UsuariosOrganismosGrupos on u.Id equals o.Usuario
                          select o.Organismos).Distinct();

            return (DbQuery<OrganismosRef>)result;

        }

        public Query ObtenerConsulta(string query)
        {
            var x = this.db.ExecuteQueryForExcel(query);
            return x;
        }

        public int ActivarUsuario(int IdUsuario, bool Activar)
        {
            return db.ActivarUsuario(IdUsuario, Activar);
        }
    }
}
