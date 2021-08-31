
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
	public partial class RolesElementoRefRN
	{
		RolesElementoRefAD oRolesElementoRefAD = new RolesElementoRefAD();

		public RolesElementoRef ObtenerPorId(int Id)
		{
			return this.oRolesElementoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<RolesElementoRef> ObtenerTodo()
		{
			return this.oRolesElementoRefAD.ObtenerTodo();
		}


		public DbQuery<RolesElementoRefView> ObtenerParaGrilla()
		{
			return this.oRolesElementoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oRolesElementoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(RolesElementoRef Objeto)
		{
			try
			{
			this.oRolesElementoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(RolesElementoRef Objeto)
		{
			try
			{
			this.oRolesElementoRefAD.Actualizar(Objeto);
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
			this.oRolesElementoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oRolesElementoRefAD.Dispose();
		}
		public DbQuery<RolesElementoRefViewT> JsonT(string term)
		{
			return (DbQuery<RolesElementoRefViewT>)this.oRolesElementoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
