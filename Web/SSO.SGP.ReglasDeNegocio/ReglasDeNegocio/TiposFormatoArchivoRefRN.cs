
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
	public partial class TiposFormatoArchivoRefRN
	{
		TiposFormatoArchivoRefAD oTiposFormatoArchivoRefAD = new TiposFormatoArchivoRefAD();

		public TiposFormatoArchivoRef ObtenerPorId(int Id)
		{
			return this.oTiposFormatoArchivoRefAD.ObtenerPorId(Id);
		}

		public DbQuery<TiposFormatoArchivoRef> ObtenerTodo()
		{
			return this.oTiposFormatoArchivoRefAD.ObtenerTodo();
		}


		public DbQuery<TiposFormatoArchivoRefView> ObtenerParaGrilla()
		{
			return this.oTiposFormatoArchivoRefAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTiposFormatoArchivoRefAD.ObtenerOptions(filtro);
		}

		public void Guardar(TiposFormatoArchivoRef Objeto)
		{
			try
			{
			this.oTiposFormatoArchivoRefAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposFormatoArchivoRef Objeto)
		{
			try
			{
			this.oTiposFormatoArchivoRefAD.Actualizar(Objeto);
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
			this.oTiposFormatoArchivoRefAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTiposFormatoArchivoRefAD.Dispose();
		}
		public DbQuery<TiposFormatoArchivoRefViewT> JsonT(string term)
		{
			return (DbQuery<TiposFormatoArchivoRefViewT>)this.oTiposFormatoArchivoRefAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
