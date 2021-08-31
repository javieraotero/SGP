
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.ReglasDeNegocio
{
    /// <summary>
    /// Reglas De Negocio Generada por el Generador de codigo.
    /// </summary>
    public partial class MenusRN
    {
        MenusAD oMenusAD = new MenusAD();

        public Menus ObtenerPorId(int Id)
        {
            return this.oMenusAD.ObtenerPorId(Id);
        }

        public DbQuery<Menus> ObtenerTodo()
        {
            return this.oMenusAD.ObtenerTodo();
        }


        /*********************************************
        public DbQuery<MenusView> ObtenerParaGrilla()
        {
            return this.oMenusAD.ObtenerParaGrilla();
        }
        * *******************************************/

        public void Guardar(Menus Objeto)
        {
            try
            {
                this.oMenusAD.Guardar(Objeto);
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
                this.oMenusAD.Actualizar(Objeto);
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
                this.oMenusAD.Eliminar(IdObjeto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Dispose()
        {
            this.oMenusAD.Dispose();
        }
        /*********************************************
        * Seccion Particular
        * *******************************************/


    }
}
