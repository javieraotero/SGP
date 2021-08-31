
using System;
using System.Data.Entity.Infrastructure;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.AccesoADatos;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using System.Data.Entity;


namespace SSO.SGP.ReglasDeNegocio
{
    public partial class webpages_RolesRN
    {
        webpages_RolesAD owebpages_RolesAD = new webpages_RolesAD();

        public DbSet<webpages_Roles> ObtenerTodo()
        {
            return this.owebpages_RolesAD.ObtenerTodo();
        }

        public string obtenerNombreRolesPor(int u)
        {

            return this.owebpages_RolesAD.obtenerNombreRolesPorUsuario(u);

        }
    }
}
