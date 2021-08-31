
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System.Data.Entity;
using Syncrosoft.Framework.Utils.Logs;

namespace SSO.SGP.AccesoADatos
{

    public partial class webpages_RolesAD
    {
        private BDEntities db = new BDEntities();

        public DbSet<webpages_Roles> ObtenerTodo()
        {
            return db.webpages_Roles;
        }

        public DbQuery<webpages_RolesView> ObtenerParaGrilla()
        {
            var x = from c in db.webpages_Roles
                        //join m in db.Menus on c.ItemMenuDefault.Substring(c.ItemMenuDefault.IndexOf("_") + 1, 2) equals SqlFunctions.StringConvert((double)m.Id) into g
                        //from mg in g.DefaultIfEmpty()
                    select new webpages_RolesView
                    {
                        Id = c.RoleId,
                        RoleName = c.RoleName
                        //MenuIcial = mg.Label
                    };
            return (DbQuery<webpages_RolesView>)x;
        }

        public DbQuery<webpages_Roles> ObtenerAutocomplete(string filtro)
        {
            var x = from c in db.webpages_Roles
                        //			where c.Descripcion.Contains(filtro)
                    select c;
            return (DbQuery<webpages_Roles>)x;
        }

        public DbQuery<SelectOptionsView> ObtenerOptions()
        {
            var x = from c in db.webpages_Roles
                    orderby c.RoleName
                    select new SelectOptionsView { text = c.RoleName, value = c.RoleId };
            return (DbQuery<SelectOptionsView>)x;
        }

        public DbQuery<webpages_RolesViewT> JsonT(string term)
        {
            var x = from c in db.webpages_Roles
                    select new webpages_RolesViewT
                    {
                        Id = c.RoleId,
                        RoleName = c.RoleName,
                        MenuIcial = c.ItemMenuDefault
                    };
            return (DbQuery<webpages_RolesViewT>)x;
        }

        public webpages_Roles ObtenerPorId(int Id)
        {
            return db.webpages_Roles.Single(c => c.RoleId == Id);
        }

        public void Guardar(webpages_Roles Objeto)
        {
            try
            {
                db.webpages_Roles.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(webpages_Roles Objeto)
        {
            try
            {
                db.webpages_Roles.Attach(Objeto);
                db.Entry(Objeto).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                Logger.GrabarExcepcion(msg, false);
                throw new Exception(msg.Message);
            }
        }

        public string obtenerNombreRolesPorUsuario(int u)
        {

            string res = "";

            var resultado = from r in db.webpages_Roles
                            where r.Usuarios.Contains(db.Usuarios.Where(us => us.Id == u).Select(us => us).FirstOrDefault())
                            select new { rol = r.RoleName };

            foreach (var x in resultado)
                res += ((res.Length > 0) ? ", " : "") + x.rol;

            return res;
        }

        public void GestionarRolesItemsMenu(int idRol, int idItem, bool agregar)
        {
            db.GestionarRolesItemsMenu(idRol, idItem, agregar);
        }


    }
}
