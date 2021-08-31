
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
    public partial class UsuariosRN
    {
        UsuariosAD oUsuariosAD = new UsuariosAD();

        public Usuarios ObtenerPorId(int Id)
        {
            return this.oUsuariosAD.ObtenerPorId(Id);
        }

        public Usuarios ObtenerPorUsuario(string usuario)
        {
            return this.oUsuariosAD.ObtenerPorUsuario(usuario);
        }

        public DbQuery<Usuarios> ObtenerTodo()
        {
            return this.oUsuariosAD.ObtenerTodo();
        }

        public DbQuery<UsuariosView> ObtenerParaGrilla(bool SoloActivos)
        {
            return oUsuariosAD.BuscarParaGrilla(SoloActivos);
        }

        public void Guardar(Usuarios Objeto)
        {
            try
            {
                this.oUsuariosAD.Guardar(Objeto);
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
                this.oUsuariosAD.Actualizar(Objeto);
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
                this.oUsuariosAD.Eliminar(IdObjeto);
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }
        }

        public void Dispose()
        {
            this.oUsuariosAD.Dispose();
        }
        /*********************************************
        * Seccion Particular
        * *******************************************/

        public DbQuery<Usuarios> ObtenerPorRol(int IdRol)
        {
            UsuariosAD oUsuariosAD = new UsuariosAD();

            return oUsuariosAD.ObtenerPorRol(IdRol);
        }

        public DbQuery<OrganismosRef> OficinasDeUsuario(int usuario)
        {
            return oUsuariosAD.ObtenerOficinas(usuario);
        }

        public int ActivarUsuario(int IdUsuario, bool Activar)
        {
            return oUsuariosAD.ActivarUsuario(IdUsuario, Activar);
        }
    }
}
