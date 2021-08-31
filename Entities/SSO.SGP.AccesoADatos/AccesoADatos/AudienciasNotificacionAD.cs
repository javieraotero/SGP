
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
	public partial class AudienciasNotificacionAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasNotificacion ObtenerPorId(int Id)
		{
			return db.AudienciasNotificacion.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasNotificacion> ObtenerTodo()
		{
			return (DbQuery<AudienciasNotificacion>)db.AudienciasNotificacion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasNotificacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasNotificacionView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasNotificacion
					where c.Activo == true
					select new AudienciasNotificacionView
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Parte = c.Parte,
						 Juez_TIP_STJ_FyM = c.Juez_TIP_STJ_FyM,
						 FechaNotificacion = c.FechaNotificacion,
						 FueNotificado = c.FueNotificado,
						 UsuarioNotificado = c.UsuarioNotificado,
						 FechaAviso = c.FechaAviso,
						 FueAvisado = c.FueAvisado,
						 UsuarioAvisado = c.UsuarioAvisado,
						 Observaciones = c.Observaciones,
						 AudienciaEstado = c.AudienciaEstado,
						 Asistio = c.Asistio,
						 FechaHoraCitacion = c.FechaHoraCitacion,
						 FechaImpresion = c.FechaImpresion,
						 Numerador = c.Numerador,
						 AutomaticamenteNotificado = c.AutomaticamenteNotificado,
						 Activo = c.Activo,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioElimina = c.UsuarioElimina,
						 MotivoElimina = c.MotivoElimina,
						 NotificaMandamientos = c.NotificaMandamientos,
						 NotificacionDestino = c.NotificacionDestino,
						 OficinaOrigen = c.OficinaOrigen,
						 Rechazada = c.Rechazada,
						 UsuarioRechazo = c.UsuarioRechazo,
						 Urgente = c.Urgente,
						 Visado = c.Visado,
						 UsuarioVisado = c.UsuarioVisado,
						 NotificaPolicia = c.NotificaPolicia,
						 DependenciaPolicialDestinoId = c.DependenciaPolicialDestinoId,
						 ModeloImpresion = c.ModeloImpresion,
						 DependenciaPolicialDestino = c.DependenciaPolicialDestino,
						 FechaAlta = c.FechaAlta,
					};
			return (DbQuery<AudienciasNotificacionView>)x;
		}

		public void Guardar(AudienciasNotificacion Objeto)
		{
			try
			{
				db.AudienciasNotificacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasNotificacion Objeto)
		{
			try
			{
				db.AudienciasNotificacion.Attach(Objeto);
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
				AudienciasNotificacion Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<AudienciasNotificacionViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasNotificacion
					where c.Activo == true
					select new AudienciasNotificacionViewT
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Parte = c.Parte,
						 Juez_TIP_STJ_FyM = c.Juez_TIP_STJ_FyM,
						 FechaNotificacion = c.FechaNotificacion,
						 FueNotificado = c.FueNotificado,
						 UsuarioNotificado = c.UsuarioNotificado,
						 FechaAviso = c.FechaAviso,
						 FueAvisado = c.FueAvisado,
						 UsuarioAvisado = c.UsuarioAvisado,
						 Observaciones = c.Observaciones,
						 AudienciaEstado = c.AudienciaEstado,
						 Asistio = c.Asistio,
						 FechaHoraCitacion = c.FechaHoraCitacion,
						 FechaImpresion = c.FechaImpresion,
						 Numerador = c.Numerador,
						 AutomaticamenteNotificado = c.AutomaticamenteNotificado,
						 Activo = c.Activo,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioElimina = c.UsuarioElimina,
						 MotivoElimina = c.MotivoElimina,
						 NotificaMandamientos = c.NotificaMandamientos,
						 NotificacionDestino = c.NotificacionDestino,
						 OficinaOrigen = c.OficinaOrigen,
						 Rechazada = c.Rechazada,
						 UsuarioRechazo = c.UsuarioRechazo,
						 Urgente = c.Urgente,
						 Visado = c.Visado,
						 UsuarioVisado = c.UsuarioVisado,
						 NotificaPolicia = c.NotificaPolicia,
						 DependenciaPolicialDestinoId = c.DependenciaPolicialDestinoId,
						 ModeloImpresion = c.ModeloImpresion,
						 DependenciaPolicialDestino = c.DependenciaPolicialDestino,
						 FechaAlta = c.FechaAlta,
					};
			return (DbQuery<AudienciasNotificacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
