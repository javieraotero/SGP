
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
	public partial class ActuacionesNotificacionAD
	{
		private BDEntities db = new BDEntities();

		public ActuacionesNotificacion ObtenerPorId(int Id)
		{
			return db.ActuacionesNotificacion.Single(c => c.Id == Id);
		}

		public DbQuery<ActuacionesNotificacion> ObtenerTodo()
		{
			return (DbQuery<ActuacionesNotificacion>)db.ActuacionesNotificacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActuacionesNotificacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesNotificacionView> ObtenerParaGrilla()
		{
			var x = from c in db.ActuacionesNotificacion
					select new ActuacionesNotificacionView
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
						 NotificaPolicia = c.NotificaPolicia,
						 DependenciaPolicialDestinoId = c.DependenciaPolicialDestinoId,
						 DependenciaPolicialDestino = c.DependenciaPolicialDestino,
						 ParteRepresentada = c.ParteRepresentada,
						 CircunscripcionRecibe = c.CircunscripcionRecibe,
					};
			return (DbQuery<ActuacionesNotificacionView>)x;
		}

		public void Guardar(ActuacionesNotificacion Objeto)
		{
			try
			{
				db.ActuacionesNotificacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesNotificacion Objeto)
		{
			try
			{
				db.ActuacionesNotificacion.Attach(Objeto);
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
				ActuacionesNotificacion Objeto = this.ObtenerPorId(IdObjeto);
				db.ActuacionesNotificacion.Remove(Objeto);
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

		public DbQuery<ActuacionesNotificacionViewT> JsonT(string term)
		{
			var x = from c in db.ActuacionesNotificacion
					select new ActuacionesNotificacionViewT
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
						 NotificaPolicia = c.NotificaPolicia,
						 DependenciaPolicialDestinoId = c.DependenciaPolicialDestinoId,
						 DependenciaPolicialDestino = c.DependenciaPolicialDestino,
						 ParteRepresentada = c.ParteRepresentada,
						 CircunscripcionRecibe = c.CircunscripcionRecibe,
					};
			return (DbQuery<ActuacionesNotificacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
