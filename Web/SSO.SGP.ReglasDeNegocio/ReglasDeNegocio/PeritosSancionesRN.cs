
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
	public partial class PeritosSancionesRN
	{
		PeritosSancionesAD oPeritosSancionesAD = new PeritosSancionesAD();

		public PeritosSanciones ObtenerPorId(int Id)
		{
			return this.oPeritosSancionesAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosSanciones> ObtenerTodo()
		{
			return this.oPeritosSancionesAD.ObtenerTodo();
		}


		public DbQuery<PeritosSancionesView> ObtenerParaGrilla()
		{
			return this.oPeritosSancionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosSancionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosSanciones Objeto)
		{
			try
			{
			this.oPeritosSancionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosSanciones Objeto)
		{
			try
			{
			this.oPeritosSancionesAD.Actualizar(Objeto);
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
			this.oPeritosSancionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosSancionesAD.Dispose();
		}
		public DbQuery<PeritosSancionesViewT> JsonT(string term)
		{
			return (DbQuery<PeritosSancionesViewT>)this.oPeritosSancionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
