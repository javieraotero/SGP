
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
	public partial class NotificacionesAD
	{
		private BDEntities db = new BDEntities();

		public Notificaciones ObtenerPorId(int Id)
		{
			return db.Notificaciones.Single(c => c.Id == Id);
		}

		public DbQuery<Notificaciones> ObtenerTodo()
		{
			return (DbQuery<Notificaciones>)db.Notificaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Notificaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<NotificacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.Notificaciones
					select new NotificacionesView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Caratula = c.Caratula,
						 JuzgadoOriginante = c.JuzgadoOriginante,
						 Destinatario = c.Destinatario,
						 Firmante = c.Firmante,
						 Sector = c.Sector,
						 TipoNotificacion = c.TipoNotificacion,
						 OficialNotificador = c.OficialNotificador,
						 Notificado = c.Notificado,
						 Resultado = c.Resultado,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaNotificado = c.FechaNotificado,
						 UsuarioTildoNotificacion = c.UsuarioTildoNotificacion,
						 IDActuacionNotificacion = c.IDActuacionNotificacion,
						 Numero = c.Numero,
						 OficialNotifico = c.OficialNotifico,
						 DestinatarioDesdeMyN = c.DestinatarioDesdeMyN,
						 DomicilioDestinatarioDesdeMyN = c.DomicilioDestinatarioDesdeMyN,
						 Motivo = c.Motivo,
						 FechaBaja = c.FechaBaja,
						 Copias = c.Copias,
						 FirmaNotificacion = c.FirmaNotificacion,
						 Circunscripcion = c.Circunscripcion,
						 IdExpediente = c.IdExpediente,
						 IdActuacionAdjunta = c.IdActuacionAdjunta,
						 DomicilioDestinatario = c.DomicilioDestinatario,
						 IDAudienciaNotificacion = c.IDAudienciaNotificacion,
					};
			return (DbQuery<NotificacionesView>)x;
		}

		public void Guardar(Notificaciones Objeto)
		{
			try
			{
				db.Notificaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Notificaciones Objeto)
		{
			try
			{
				db.Notificaciones.Attach(Objeto);
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
				Notificaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.Notificaciones.Remove(Objeto);
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

		public DbQuery<NotificacionesViewT> JsonT(string term)
		{
			var x = from c in db.Notificaciones
					select new NotificacionesViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Caratula = c.Caratula,
						 JuzgadoOriginante = c.JuzgadoOriginante,
						 Destinatario = c.Destinatario,
						 Firmante = c.Firmante,
						 Sector = c.Sector,
						 TipoNotificacion = c.TipoNotificacion,
						 OficialNotificador = c.OficialNotificador,
						 Notificado = c.Notificado,
						 Resultado = c.Resultado,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaNotificado = c.FechaNotificado,
						 UsuarioTildoNotificacion = c.UsuarioTildoNotificacion,
						 IDActuacionNotificacion = c.IDActuacionNotificacion,
						 Numero = c.Numero,
						 OficialNotifico = c.OficialNotifico,
						 DestinatarioDesdeMyN = c.DestinatarioDesdeMyN,
						 DomicilioDestinatarioDesdeMyN = c.DomicilioDestinatarioDesdeMyN,
						 Motivo = c.Motivo,
						 FechaBaja = c.FechaBaja,
						 Copias = c.Copias,
						 FirmaNotificacion = c.FirmaNotificacion,
						 Circunscripcion = c.Circunscripcion,
						 IdExpediente = c.IdExpediente,
						 IdActuacionAdjunta = c.IdActuacionAdjunta,
						 DomicilioDestinatario = c.DomicilioDestinatario,
						 IDAudienciaNotificacion = c.IDAudienciaNotificacion,
					};
			return (DbQuery<NotificacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
