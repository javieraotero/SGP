
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
	public partial class CambiosRadicacionRN
	{
		CambiosRadicacionAD oCambiosRadicacionAD = new CambiosRadicacionAD();

		public CambiosRadicacion ObtenerPorId(int Id)
		{
			return this.oCambiosRadicacionAD.ObtenerPorId(Id);
		}

		public DbQuery<CambiosRadicacion> ObtenerTodo()
		{
			return this.oCambiosRadicacionAD.ObtenerTodo();
		}


		public DbQuery<CambiosRadicacionView> ObtenerParaGrilla()
		{
			return this.oCambiosRadicacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oCambiosRadicacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(CambiosRadicacion Objeto)
		{
			try
			{
			this.oCambiosRadicacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CambiosRadicacion Objeto)
		{
			try
			{
			this.oCambiosRadicacionAD.Actualizar(Objeto);
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
			this.oCambiosRadicacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oCambiosRadicacionAD.Dispose();
		}
		public DbQuery<CambiosRadicacionViewT> JsonT(string term)
		{
			return (DbQuery<CambiosRadicacionViewT>)this.oCambiosRadicacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
