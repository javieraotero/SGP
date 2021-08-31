
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
	public partial class TraceProduccionRN
	{
		TraceProduccionAD oTraceProduccionAD = new TraceProduccionAD();

		public TraceProduccion ObtenerPorId(int Id)
		{
			return this.oTraceProduccionAD.ObtenerPorId(Id);
		}

		public DbQuery<TraceProduccion> ObtenerTodo()
		{
			return this.oTraceProduccionAD.ObtenerTodo();
		}


		public DbQuery<TraceProduccionView> ObtenerParaGrilla()
		{
			return this.oTraceProduccionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oTraceProduccionAD.ObtenerOptions(filtro);
		}

		public void Guardar(TraceProduccion Objeto)
		{
			try
			{
			this.oTraceProduccionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TraceProduccion Objeto)
		{
			try
			{
			this.oTraceProduccionAD.Actualizar(Objeto);
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
			this.oTraceProduccionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oTraceProduccionAD.Dispose();
		}
		public DbQuery<TraceProduccionViewT> JsonT(string term)
		{
			return (DbQuery<TraceProduccionViewT>)this.oTraceProduccionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
