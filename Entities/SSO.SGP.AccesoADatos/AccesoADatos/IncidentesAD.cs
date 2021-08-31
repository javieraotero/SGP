
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
	public partial class IncidentesAD
	{
		private BDEntities db = new BDEntities();

		public Incidentes ObtenerPorId(int Id)
		{
			return db.Incidentes.Single(c => c.Id == Id);
		}

		public DbQuery<Incidentes> ObtenerTodo()
		{
			return (DbQuery<Incidentes>)db.Incidentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Incidentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<IncidentesView> ObtenerParaGrilla()
		{
			var x = from c in db.Incidentes
					select new IncidentesView
					{
						 Id = c.Id,
						 UsuarioSolicitante = c.UsuarioSolicitante,
						 AmbitoSolicitante = c.AmbitoSolicitante,
						 SubambitoSolicitante = c.SubambitoSolicitante,
						 FechaHoraSolicitud = c.FechaHoraSolicitud,
						 EstadoActual = c.EstadoActual,
						 FechaUltimoCambioEstado = c.FechaUltimoCambioEstado,
						 Prioridad = c.Prioridad,
						 Titulo = c.Titulo,
						 Problema = c.Problema,
						 Observaciones = c.Observaciones,
						 Version = c.Version,
						 Etiquetas = c.Etiquetas,
						 TesteadoUsuario = c.TesteadoUsuario,
						 TesteadoDesarrollador = c.TesteadoDesarrollador,
						 TesteadoSupervisor = c.TesteadoSupervisor,
						 Desarrollador = c.Desarrollador,
						 PrioridadDesarrollo = c.PrioridadDesarrollo,
					};
			return (DbQuery<IncidentesView>)x;
		}

		public void Guardar(Incidentes Objeto)
		{
			try
			{
				db.Incidentes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Incidentes Objeto)
		{
			try
			{
				db.Incidentes.Attach(Objeto);
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
				Incidentes Objeto = this.ObtenerPorId(IdObjeto);
				db.Incidentes.Remove(Objeto);
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

		public DbQuery<IncidentesViewT> JsonT(string term)
		{
			var x = from c in db.Incidentes
					select new IncidentesViewT
					{
						 Id = c.Id,
						 UsuarioSolicitante = c.UsuarioSolicitante,
						 AmbitoSolicitante = c.AmbitoSolicitante,
						 SubambitoSolicitante = c.SubambitoSolicitante,
						 FechaHoraSolicitud = c.FechaHoraSolicitud,
						 EstadoActual = c.EstadoActual,
						 FechaUltimoCambioEstado = c.FechaUltimoCambioEstado,
						 Prioridad = c.Prioridad,
						 Titulo = c.Titulo,
						 Problema = c.Problema,
						 Observaciones = c.Observaciones,
						 Version = c.Version,
						 Etiquetas = c.Etiquetas,
						 TesteadoUsuario = c.TesteadoUsuario,
						 TesteadoDesarrollador = c.TesteadoDesarrollador,
						 TesteadoSupervisor = c.TesteadoSupervisor,
						 Desarrollador = c.Desarrollador,
						 PrioridadDesarrollo = c.PrioridadDesarrollo,
					};
			return (DbQuery<IncidentesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
