
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
	public partial class RolesPersonaCivilRefRN
	{
		RolesPersonaCivilRefAD oRolesPersonaCivilRefAD = new RolesPersonaCivilRefAD();

		public RolesPersonaCivilRef ObtenerPorId(int Id)
		{
			return this.oRolesPersonaCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<RolesPersonaCivilRef> ObtenerTodo()
		{
			return this.oRolesPersonaCivilRefAD.ObtenerTodo();
		}


		public DbQuery<RolesPersonaCivilRefView> ObtenerParaGrilla()
		{
			return this.oRolesPersonaCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oRolesPersonaCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(RolesPersonaCivilRef Objeto)
		{
			try
			{
			this.oRolesPersonaCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesPersonaCivilRef Objeto)
		{
			try
			{
			this.oRolesPersonaCivilRefAD.Actualizar(Objeto);
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
			this.oRolesPersonaCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oRolesPersonaCivilRefAD.Dispose();
		}
		public DbQuery<RolesPersonaCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<RolesPersonaCivilRefViewT>)this.oRolesPersonaCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
