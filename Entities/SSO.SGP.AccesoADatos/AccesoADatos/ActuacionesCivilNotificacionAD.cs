
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class ActuacionesCivilNotificacionAD
	{
		private BDEntities db = new BDEntities();

		public ActuacionesCivilNotificacion ObtenerPorId(int Id)
		{
			return db.ActuacionesCivilNotificacion.Single(c => c.Id == Id);
		}

		public DbQuery<ActuacionesCivilNotificacion> ObtenerTodo()
		{
			return (DbQuery<ActuacionesCivilNotificacion>)db.ActuacionesCivilNotificacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActuacionesCivilNotificacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesCivilNotificacionView> ObtenerParaGrilla()
		{
			var x = from c in db.ActuacionesCivilNotificacion
					select new ActuacionesCivilNotificacionView
					{
						 Id = c.Id,
						 Actuacion = c.Actuacion,
						 Parte = c.Parte,
						 FechaNotificacion = c.FechaNotificacion,
						 FueNotificado = c.FueNotificado,
						 FechaAviso = c.FechaAviso,
						 FueAvisado = c.FueAvisado,
						 Observaciones = c.Observaciones,
						 FechaImpresion = c.FechaImpresion,
						 AutomaticamenteNotificado = c.AutomaticamenteNotificado,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 UsuarioNotificado = c.UsuarioNotificado,
						 UsuarioAvisado = c.UsuarioAvisado,
						 NotificaMandamientos = c.NotificaMandamientos,
						 NotificacionDestino = c.NotificacionDestino,
						 OficinaOrigen = c.OficinaOrigen,
						 Rechazada = c.Rechazada,
						 UsuarioRechazo = c.UsuarioRechazo,
						 Urgente = c.Urgente,
						 IdActuacionAdjunta = c.IdActuacionAdjunta,
						 Visado = c.Visado,
						 UsuarioVisado = c.UsuarioVisado,
						 ParteRepresentada = c.ParteRepresentada,
						 CircunscripcionRecibe = c.CircunscripcionRecibe,
					};
			return (DbQuery<ActuacionesCivilNotificacionView>)x;
		}

		public void Guardar(ActuacionesCivilNotificacion Objeto)
		{
			try
			{
				db.ActuacionesCivilNotificacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesCivilNotificacion Objeto)
		{
			try
			{
				db.ActuacionesCivilNotificacion.Attach(Objeto);
				db.Entry(Objeto).State = EntityState.Modified;
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Eliminar(int IdObjeto)
		{
			try
			{
				ActuacionesCivilNotificacion Objeto = this.ObtenerPorId(IdObjeto);
				db.ActuacionesCivilNotificacion.Remove(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Dispose()
		{
			db.Dispose();
		}

		public DbQuery<ActuacionesCivilNotificacionViewT> JsonT(string term)
		{
			var x = from c in db.ActuacionesCivilNotificacion
					select new ActuacionesCivilNotificacionViewT
					{
						 Id = c.Id,
						 Actuacion = c.Actuacion,
						 Parte = c.Parte,
						 FechaNotificacion = c.FechaNotificacion,
						 FueNotificado = c.FueNotificado,
						 FechaAviso = c.FechaAviso,
						 FueAvisado = c.FueAvisado,
						 Observaciones = c.Observaciones,
						 FechaImpresion = c.FechaImpresion,
						 AutomaticamenteNotificado = c.AutomaticamenteNotificado,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 UsuarioNotificado = c.UsuarioNotificado,
						 UsuarioAvisado = c.UsuarioAvisado,
						 NotificaMandamientos = c.NotificaMandamientos,
						 NotificacionDestino = c.NotificacionDestino,
						 OficinaOrigen = c.OficinaOrigen,
						 Rechazada = c.Rechazada,
						 UsuarioRechazo = c.UsuarioRechazo,
						 Urgente = c.Urgente,
						 IdActuacionAdjunta = c.IdActuacionAdjunta,
						 Visado = c.Visado,
						 UsuarioVisado = c.UsuarioVisado,
						 ParteRepresentada = c.ParteRepresentada,
						 CircunscripcionRecibe = c.CircunscripcionRecibe,
					};
			return (DbQuery<ActuacionesCivilNotificacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
