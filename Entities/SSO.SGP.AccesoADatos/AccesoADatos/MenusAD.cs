
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.AccesoADatos
{
    /// <summary>
    /// Acceso a Datos Generada por el Generador de codigo.
    /// </summary>
    public partial class MenusAD
    {
        private BDEntities db = new BDEntities();

        public Menus ObtenerPorId(int Id)
        {
            return db.Menus.Single(c => c.Id == Id);
        }

        public DbQuery<Menus> ObtenerTodo()
        {
            return (DbQuery<Menus>)db.Menus;
        }

        /*********************************************
        public DbQuery<MenusView> ObtenerParaGrilla()
        {
            var x = from c in db.Menus
                select new MenusView
                {
                         Id = c. Id,
                         Label = c. Label,
                         Accion = c. Accion,
                         Controlador = c. Controlador,
                         Padre = c. Padre,
                         IconClass = c. IconClass,
                         ToolTip = c. ToolTip,
                         Orden = c. Orden,
                         TabIndex = c. TabIndex,
                         Tabs = c. Tabs,
                         TituloDePagina = c. TituloDePagina,
                         Descripcion = c. Descripcion,
                };
            return (DbQuery<MenusView>)x;
        }
        * *******************************************/

        public void Guardar(Menus Objeto)
        {
            try
            {
                db.Menus.Add(Objeto);
                db.SaveChanges();
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Actualizar(Menus Objeto)
        {
            try
            {
                db.Menus.Attach(Objeto);
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
                Menus Objeto = this.ObtenerPorId(IdObjeto);
                db.Menus.Remove(Objeto);
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


    }
}
