
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
	public partial class TiposAudienciaCivilRefRN
	{
		TiposAudienciaCivilRefAD oTiposAudienciaCivilRefAD = new TiposAudienciaCivilRefAD();

		public TiposAudienciaCivilRef ObtenerPorId(int Id)
		{
			return this.oTiposAudienciaCivilRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposAudienciaCivilRef> ObtenerTodo()
		{
			return this.oTiposAudienciaCivilRefAD.ObtenerTodo();
		}


		public DbQuery<TiposAudienciaCivilRefView> ObtenerParaGrilla()
		{
			return this.oTiposAudienciaCivilRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposAudienciaCivilRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposAudienciaCivilRef Objeto)
		{
			try
			{
			this.oTiposAudienciaCivilRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposAudienciaCivilRef Objeto)
		{
			try
			{
			this.oTiposAudienciaCivilRefAD.Actualizar(Objeto);
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
			this.oTiposAudienciaCivilRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposAudienciaCivilRefAD.Dispose();
		}
		public DbQuery<TiposAudienciaCivilRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposAudienciaCivilRefViewT>)this.oTiposAudienciaCivilRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
