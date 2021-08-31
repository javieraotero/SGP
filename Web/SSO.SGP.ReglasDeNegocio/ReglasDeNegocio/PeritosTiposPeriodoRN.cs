
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
	public partial class PeritosTiposPeriodoRN
	{
		PeritosTiposPeriodoAD oPeritosTiposPeriodoAD = new PeritosTiposPeriodoAD();

		public PeritosTiposPeriodo ObtenerPorId(int Id)
		{
			return this.oPeritosTiposPeriodoAD.ObtenerPorId(Id);
		}

		public DbQuery<PeritosTiposPeriodo> ObtenerTodo()
		{
			return this.oPeritosTiposPeriodoAD.ObtenerTodo();
		}


		public DbQuery<PeritosTiposPeriodoView> ObtenerParaGrilla()
		{
			return this.oPeritosTiposPeriodoAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oPeritosTiposPeriodoAD.ObtenerOptions(filtro);
		}

		public void Guardar(PeritosTiposPeriodo Objeto)
		{
			try
			{
			this.oPeritosTiposPeriodoAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosTiposPeriodo Objeto)
		{
			try
			{
			this.oPeritosTiposPeriodoAD.Actualizar(Objeto);
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
			this.oPeritosTiposPeriodoAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oPeritosTiposPeriodoAD.Dispose();
		}
		public DbQuery<PeritosTiposPeriodoViewT> JsonT(string term)
		{
			return (DbQuery<PeritosTiposPeriodoViewT>)this.oPeritosTiposPeriodoAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
