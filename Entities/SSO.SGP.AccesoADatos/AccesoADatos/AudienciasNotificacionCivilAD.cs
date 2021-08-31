
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
	public partial class AudienciasNotificacionCivilAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasNotificacionCivil ObtenerPorId(int Id)
		{
			return db.AudienciasNotificacionCivil.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasNotificacionCivil> ObtenerTodo()
		{
			return (DbQuery<AudienciasNotificacionCivil>)db.AudienciasNotificacionCivil.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasNotificacionCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasNotificacionCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasNotificacionCivil
					where c.Activo == true
					select new AudienciasNotificacionCivilView
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Parte = c.Parte,
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
					};
			return (DbQuery<AudienciasNotificacionCivilView>)x;
		}

		public void Guardar(AudienciasNotificacionCivil Objeto)
		{
			try
			{
				db.AudienciasNotificacionCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasNotificacionCivil Objeto)
		{
			try
			{
				db.AudienciasNotificacionCivil.Attach(Objeto);
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
				AudienciasNotificacionCivil Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<AudienciasNotificacionCivilViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasNotificacionCivil
					where c.Activo == true
					select new AudienciasNotificacionCivilViewT
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Parte = c.Parte,
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
					};
			return (DbQuery<AudienciasNotificacionCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
