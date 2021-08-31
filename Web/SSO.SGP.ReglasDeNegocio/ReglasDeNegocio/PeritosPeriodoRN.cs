
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
	public partial class PeritosPeriodoRN
	{
		PeritosPeriodoAD oPeritosPeriodoAD = new PeritosPeriodoAD();

		public PeritosPeriodo ObtenerPorId(int Id)
		{
			return this.oPeritosPeriodoAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosPeriodo> ObtenerTodo()
		{
			return this.oPeritosPeriodoAD.ObtenerTodo();
		}


		public DbQuery<PeritosPeriodoView> ObtenerParaGrilla()
		{
			return this.oPeritosPeriodoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosPeriodoAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosPeriodo Objeto)
		{
			try
			{
			this.oPeritosPeriodoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosPeriodo Objeto)
		{
			try
			{
			this.oPeritosPeriodoAD.Actualizar(Objeto);
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
			this.oPeritosPeriodoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosPeriodoAD.Dispose();
		}
		public DbQuery<PeritosPeriodoViewT> JsonT(string term)
		{
			return (DbQuery<PeritosPeriodoViewT>)this.oPeritosPeriodoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
