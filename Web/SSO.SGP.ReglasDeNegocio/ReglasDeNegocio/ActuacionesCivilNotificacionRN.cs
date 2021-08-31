
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
	public partial class ActuacionesCivilNotificacionRN
	{
		ActuacionesCivilNotificacionAD oActuacionesCivilNotificacionAD = new ActuacionesCivilNotificacionAD();

		public ActuacionesCivilNotificacion ObtenerPorId(int Id)
		{
			return this.oActuacionesCivilNotificacionAD.ObtenerPorId(Id);
		}

		public DbQuery<ActuacionesCivilNotificacion> ObtenerTodo()
		{
			return this.oActuacionesCivilNotificacionAD.ObtenerTodo();
		}


		public DbQuery<ActuacionesCivilNotificacionView> ObtenerParaGrilla()
		{
			return this.oActuacionesCivilNotificacionAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oActuacionesCivilNotificacionAD.ObtenerOptions(filtro);
		}

		public void Guardar(ActuacionesCivilNotificacion Objeto)
		{
			try
			{
			this.oActuacionesCivilNotificacionAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesCivilNotificacion Objeto)
		{
			try
			{
			this.oActuacionesCivilNotificacionAD.Actualizar(Objeto);
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
			this.oActuacionesCivilNotificacionAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oActuacionesCivilNotificacionAD.Dispose();
		}
		public DbQuery<ActuacionesCivilNotificacionViewT> JsonT(string term)
		{
			return (DbQuery<ActuacionesCivilNotificacionViewT>)this.oActuacionesCivilNotificacionAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
