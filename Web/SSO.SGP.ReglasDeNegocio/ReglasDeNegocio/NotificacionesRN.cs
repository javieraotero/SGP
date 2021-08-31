
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
	public partial class NotificacionesRN
	{
		NotificacionesAD oNotificacionesAD = new NotificacionesAD();

		public Notificaciones ObtenerPorId(int Id)
		{
			return this.oNotificacionesAD.ObtenerPorId(Id);
		}

		public DbQuery<Notificaciones> ObtenerTodo()
		{
			return this.oNotificacionesAD.ObtenerTodo();
		}


		public DbQuery<NotificacionesView> ObtenerParaGrilla()
		{
			return this.oNotificacionesAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oNotificacionesAD.ObtenerOptions(filtro);
		}

		public void Guardar(Notificaciones Objeto)
		{
			try
			{
			this.oNotificacionesAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Notificaciones Objeto)
		{
			try
			{
			this.oNotificacionesAD.Actualizar(Objeto);
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
			this.oNotificacionesAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oNotificacionesAD.Dispose();
		}
		public DbQuery<NotificacionesViewT> JsonT(string term)
		{
			return (DbQuery<NotificacionesViewT>)this.oNotificacionesAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
