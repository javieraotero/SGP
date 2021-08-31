
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
	public partial class TiposOrganismoRefRN
	{
		TiposOrganismoRefAD oTiposOrganismoRefAD = new TiposOrganismoRefAD();

		public TiposOrganismoRef ObtenerPorId(int Id)
		{
			return this.oTiposOrganismoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposOrganismoRef> ObtenerTodo()
		{
			return this.oTiposOrganismoRefAD.ObtenerTodo();
		}


		public DbQuery<TiposOrganismoRefView> ObtenerParaGrilla()
		{
			return this.oTiposOrganismoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposOrganismoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposOrganismoRef Objeto)
		{
			try
			{
			this.oTiposOrganismoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOrganismoRef Objeto)
		{
			try
			{
			this.oTiposOrganismoRefAD.Actualizar(Objeto);
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
			this.oTiposOrganismoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposOrganismoRefAD.Dispose();
		}
		public DbQuery<TiposOrganismoRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposOrganismoRefViewT>)this.oTiposOrganismoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
