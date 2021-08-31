
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
	public partial class RolesPersonaRefRN
	{
		RolesPersonaRefAD oRolesPersonaRefAD = new RolesPersonaRefAD();

		public RolesPersonaRef ObtenerPorId(int Id)
		{
			return this.oRolesPersonaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<RolesPersonaRef> ObtenerTodo()
		{
			return this.oRolesPersonaRefAD.ObtenerTodo();
		}


		public DbQuery<RolesPersonaRefView> ObtenerParaGrilla()
		{
			return this.oRolesPersonaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oRolesPersonaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(RolesPersonaRef Objeto)
		{
			try
			{
			this.oRolesPersonaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesPersonaRef Objeto)
		{
			try
			{
			this.oRolesPersonaRefAD.Actualizar(Objeto);
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
			this.oRolesPersonaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oRolesPersonaRefAD.Dispose();
		}
		public DbQuery<RolesPersonaRefViewT> JsonT(string term)
		{
			return (DbQuery<RolesPersonaRefViewT>)this.oRolesPersonaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
