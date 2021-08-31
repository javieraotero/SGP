
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
	public partial class PeritosSorteoRN
	{
		PeritosSorteoAD oPeritosSorteoAD = new PeritosSorteoAD();

		public PeritosSorteo ObtenerPorId(int Id)
		{
			return this.oPeritosSorteoAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosSorteo> ObtenerTodo()
		{
			return this.oPeritosSorteoAD.ObtenerTodo();
		}


		public DbQuery<PeritosSorteoView> ObtenerParaGrilla()
		{
			return this.oPeritosSorteoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosSorteoAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosSorteo Objeto)
		{
			try
			{
			this.oPeritosSorteoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosSorteo Objeto)
		{
			try
			{
			this.oPeritosSorteoAD.Actualizar(Objeto);
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
			this.oPeritosSorteoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosSorteoAD.Dispose();
		}
		public DbQuery<PeritosSorteoViewT> JsonT(string term)
		{
			return (DbQuery<PeritosSorteoViewT>)this.oPeritosSorteoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
