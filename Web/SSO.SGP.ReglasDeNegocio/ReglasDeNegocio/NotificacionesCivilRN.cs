
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
	public partial class NotificacionesCivilRN
	{
		NotificacionesCivilAD oNotificacionesCivilAD = new NotificacionesCivilAD();

		public NotificacionesCivil ObtenerPorId(int Id)
		{
			return this.oNotificacionesCivilAD.ObtenerPorId(Id);
		}

		public DbQuery<NotificacionesCivil> ObtenerTodo()
		{
			return this.oNotificacionesCivilAD.ObtenerTodo();
		}


		public DbQuery<NotificacionesCivilView> ObtenerParaGrilla()
		{
			return this.oNotificacionesCivilAD.ObtenerParaGrilla();
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(String filtro)
		{
			return this.oNotificacionesCivilAD.ObtenerOptions(filtro);
		}

		public void Guardar(NotificacionesCivil Objeto)
		{
			try
			{
			this.oNotificacionesCivilAD.Guardar(Objeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(NotificacionesCivil Objeto)
		{
			try
			{
			this.oNotificacionesCivilAD.Actualizar(Objeto);
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
			this.oNotificacionesCivilAD.Eliminar(IdObjeto);
			}
			catch (Exception msg)
			{
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			this.oNotificacionesCivilAD.Dispose();
		}
		public DbQuery<NotificacionesCivilViewT> JsonT(string term)
		{
			return (DbQuery<NotificacionesCivilViewT>)this.oNotificacionesCivilAD.JsonT(term);
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
