
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
	public partial class IncidentesEstadoAD
	{
		private BDEntities db = new BDEntities();

		public IncidentesEstado ObtenerPorId(int Id)
		{
			return db.IncidentesEstado.Single(c => c.Id == Id);
		}

		public DbQuery<IncidentesEstado> ObtenerTodo()
		{
			return (DbQuery<IncidentesEstado>)db.IncidentesEstado;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.IncidentesEstado
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<IncidentesEstadoView> ObtenerParaGrilla()
		{
			var x = from c in db.IncidentesEstado
					select new IncidentesEstadoView
					{
						 Id = c.Id,
						 Incidente = c.Incidente,
						 Estado = c.Estado,
						 FechaHora = c.FechaHora,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 DiasTranscurridos = c.DiasTranscurridos,
					};
			return (DbQuery<IncidentesEstadoView>)x;
		}

		public void Guardar(IncidentesEstado Objeto)
		{
			try
			{
				db.IncidentesEstado.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(IncidentesEstado Objeto)
		{
			try
			{
				db.IncidentesEstado.Attach(Objeto);
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
				IncidentesEstado Objeto = this.ObtenerPorId(IdObjeto);
				db.IncidentesEstado.Remove(Objeto);
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

		public DbQuery<IncidentesEstadoViewT> JsonT(string term)
		{
			var x = from c in db.IncidentesEstado
					select new IncidentesEstadoViewT
					{
						 Id = c.Id,
						 Incidente = c.Incidente,
						 Estado = c.Estado,
						 FechaHora = c.FechaHora,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 DiasTranscurridos = c.DiasTranscurridos,
					};
			return (DbQuery<IncidentesEstadoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
