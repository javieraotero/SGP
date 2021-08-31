
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
	public partial class NotificacionesCivilAD
	{
		private BDEntities db = new BDEntities();

		public NotificacionesCivil ObtenerPorId(int Id)
		{
			return db.NotificacionesCivil.Single(c => c.Id == Id);
		}

		public DbQuery<NotificacionesCivil> ObtenerTodo()
		{
			return (DbQuery<NotificacionesCivil>)db.NotificacionesCivil;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.NotificacionesCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<NotificacionesCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.NotificacionesCivil
					select new NotificacionesCivilView
					{
						 Id = c.Id,
						 Causa = c.Causa,
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
						 IdCausa = c.IdCausa,
					};
			return (DbQuery<NotificacionesCivilView>)x;
		}

		public void Guardar(NotificacionesCivil Objeto)
		{
			try
			{
				db.NotificacionesCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(NotificacionesCivil Objeto)
		{
			try
			{
				db.NotificacionesCivil.Attach(Objeto);
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
				NotificacionesCivil Objeto = this.ObtenerPorId(IdObjeto);
				db.NotificacionesCivil.Remove(Objeto);
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

		public DbQuery<NotificacionesCivilViewT> JsonT(string term)
		{
			var x = from c in db.NotificacionesCivil
					select new NotificacionesCivilViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
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
						 IdCausa = c.IdCausa,
					};
			return (DbQuery<NotificacionesCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
