
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
	public partial class ActuacionesNotificacionRN
	{
		ActuacionesNotificacionAD oActuacionesNotificacionAD = new ActuacionesNotificacionAD();

		public ActuacionesNotificacion ObtenerPorId(int Id)
		{
			return this.oActuacionesNotificacionAD.ObtenerPorId(Id);
		}

		public DbQuery<ActuacionesNotificacion> ObtenerTodo()
		{
			return this.oActuacionesNotificacionAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesNotificacionView> ObtenerParaGrilla()
		{
			return this.oActuacionesNotificacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesNotificacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActuacionesNotificacion Objeto)
		{
			try
			{
			this.oActuacionesNotificacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesNotificacion Objeto)
		{
			try
			{
			this.oActuacionesNotificacionAD.Actualizar(Objeto);
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
			this.oActuacionesNotificacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesNotificacionAD.Dispose();
		}
		public DbQuery<ActuacionesNotificacionViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesNotificacionViewT>)this.oActuacionesNotificacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
