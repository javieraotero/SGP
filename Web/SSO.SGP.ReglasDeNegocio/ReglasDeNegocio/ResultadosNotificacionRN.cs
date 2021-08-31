
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
	public partial class ResultadosNotificacionRN
	{
		ResultadosNotificacionAD oResultadosNotificacionAD = new ResultadosNotificacionAD();

		public ResultadosNotificacion ObtenerPorId(int Id)
		{
			return this.oResultadosNotificacionAD.ObtenerPorId(Id);
		}

		public DbQuery<ResultadosNotificacion> ObtenerTodo()
		{
			return this.oResultadosNotificacionAD.ObtenerTodo();
		}


		public DbQuery<ResultadosNotificacionView> ObtenerParaGrilla()
		{
			return this.oResultadosNotificacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oResultadosNotificacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(ResultadosNotificacion Objeto)
		{
			try
			{
			this.oResultadosNotificacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ResultadosNotificacion Objeto)
		{
			try
			{
			this.oResultadosNotificacionAD.Actualizar(Objeto);
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
			this.oResultadosNotificacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oResultadosNotificacionAD.Dispose();
		}
		public DbQuery<ResultadosNotificacionViewT> JsonT(string term)
		{
			return (DbQuery<ResultadosNotificacionViewT>)this.oResultadosNotificacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
