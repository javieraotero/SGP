
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
	public partial class AudienciasSolicitudAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasSolicitud ObtenerPorId(int Id)
		{
			return db.AudienciasSolicitud.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasSolicitud> ObtenerTodo()
		{
			return (DbQuery<AudienciasSolicitud>)db.AudienciasSolicitud;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasSolicitud
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasSolicitudView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasSolicitud
					select new AudienciasSolicitudView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Solicitante = c.Solicitante,
						 TipoAudiencia = c.TipoAudiencia,
						 SolicitaJuez = c.SolicitaJuez,
						 Observaciones = c.Observaciones,
						 Audiencia = c.Audiencia,
						 Circunscripcion = c.Circunscripcion,
						 Expediente = c.Expediente,
						 ActuacionOriginante = c.ActuacionOriginante,
					};
			return (DbQuery<AudienciasSolicitudView>)x;
		}

		public void Guardar(AudienciasSolicitud Objeto)
		{
			try
			{
				db.AudienciasSolicitud.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasSolicitud Objeto)
		{
			try
			{
				db.AudienciasSolicitud.Attach(Objeto);
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
				AudienciasSolicitud Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasSolicitud.Remove(Objeto);
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

		public DbQuery<AudienciasSolicitudViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasSolicitud
					select new AudienciasSolicitudViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Solicitante = c.Solicitante,
						 TipoAudiencia = c.TipoAudiencia,
						 SolicitaJuez = c.SolicitaJuez,
						 Observaciones = c.Observaciones,
						 Audiencia = c.Audiencia,
						 Circunscripcion = c.Circunscripcion,
						 Expediente = c.Expediente,
						 ActuacionOriginante = c.ActuacionOriginante,
					};
			return (DbQuery<AudienciasSolicitudViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
