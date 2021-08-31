
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
	public partial class RolesPersonaadmRefRN
	{
		RolesPersonaadmRefAD oRolesPersonaadmRefAD = new RolesPersonaadmRefAD();

		public RolesPersonaadmRef ObtenerPorId(int Id)
		{
			return this.oRolesPersonaadmRefAD.ObtenerPorId(Id);
		}

		public DbQuery<RolesPersonaadmRef> ObtenerTodo()
		{
			return this.oRolesPersonaadmRefAD.ObtenerTodo();
		}


		public DbQuery<RolesPersonaadmRefView> ObtenerParaGrilla()
		{
			return this.oRolesPersonaadmRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oRolesPersonaadmRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(RolesPersonaadmRef Objeto)
		{
			try
			{
			this.oRolesPersonaadmRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesPersonaadmRef Objeto)
		{
			try
			{
			this.oRolesPersonaadmRefAD.Actualizar(Objeto);
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
			this.oRolesPersonaadmRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oRolesPersonaadmRefAD.Dispose();
		}
		public DbQuery<RolesPersonaadmRefViewT> JsonT(string term)
		{
			return (DbQuery<RolesPersonaadmRefViewT>)this.oRolesPersonaadmRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
