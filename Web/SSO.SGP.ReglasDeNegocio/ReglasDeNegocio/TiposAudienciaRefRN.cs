
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
	public partial class TiposAudienciaRefRN
	{
		TiposAudienciaRefAD oTiposAudienciaRefAD = new TiposAudienciaRefAD();

		public TiposAudienciaRef ObtenerPorId(int Id)
		{
			return this.oTiposAudienciaRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposAudienciaRef> ObtenerTodo()
		{
			return this.oTiposAudienciaRefAD.ObtenerTodo();
		}


		public DbQuery<TiposAudienciaRefView> ObtenerParaGrilla()
		{
			return this.oTiposAudienciaRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposAudienciaRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposAudienciaRef Objeto)
		{
			try
			{
			this.oTiposAudienciaRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposAudienciaRef Objeto)
		{
			try
			{
			this.oTiposAudienciaRefAD.Actualizar(Objeto);
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
			this.oTiposAudienciaRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposAudienciaRefAD.Dispose();
		}
		public DbQuery<TiposAudienciaRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposAudienciaRefViewT>)this.oTiposAudienciaRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
