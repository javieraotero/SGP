
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
	public partial class UnidadesDeOrganizacionRefRN
	{
		UnidadesDeOrganizacionRefAD oUnidadesDeOrganizacionRefAD = new UnidadesDeOrganizacionRefAD();

		public UnidadesDeOrganizacionRef ObtenerPorId(int Id)
		{
			return this.oUnidadesDeOrganizacionRefAD.ObtenerPorId(Id);
		}

		public DbQuery<UnidadesDeOrganizacionRef> ObtenerTodo()
		{
			return this.oUnidadesDeOrganizacionRefAD.ObtenerTodo();
		}


		public DbQuery<UnidadesDeOrganizacionRefView> ObtenerParaGrilla()
		{
			return this.oUnidadesDeOrganizacionRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oUnidadesDeOrganizacionRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(UnidadesDeOrganizacionRef Objeto)
		{
			try
			{
			this.oUnidadesDeOrganizacionRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UnidadesDeOrganizacionRef Objeto)
		{
			try
			{
			this.oUnidadesDeOrganizacionRefAD.Actualizar(Objeto);
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
			this.oUnidadesDeOrganizacionRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oUnidadesDeOrganizacionRefAD.Dispose();
		}
		public DbQuery<UnidadesDeOrganizacionRefViewT> JsonT(string term)
		{
			return (DbQuery<UnidadesDeOrganizacionRefViewT>)this.oUnidadesDeOrganizacionRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
