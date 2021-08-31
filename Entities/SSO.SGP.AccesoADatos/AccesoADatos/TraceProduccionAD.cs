
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
	public partial class TraceProduccionAD
	{
		private BDEntities db = new BDEntities();

		public TraceProduccion ObtenerPorId(int Id)
		{
			return db.TraceProduccion.Single(c => c.Id == Id);
		}

		public DbQuery<TraceProduccion> ObtenerTodo()
		{
			return (DbQuery<TraceProduccion>)db.TraceProduccion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TraceProduccion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TraceProduccionView> ObtenerParaGrilla()
		{
			var x = from c in db.TraceProduccion
					select new TraceProduccionView
					{
						 RowNumber = c.RowNumber,
						 EventClass = c.EventClass,
						 TextData = c.TextData,
						 ApplicationName = c.ApplicationName,
						 NTUserName = c.NTUserName,
						 LoginName = c.LoginName,
						 CPU = c.CPU,
						 Reads = c.Reads,
						 Writes = c.Writes,
						 Duration = c.Duration,
						 ClientProcessID = c.ClientProcessID,
						 SPID = c.SPID,
						 StartTime = c.StartTime,
						 EndTime = c.EndTime,
						 BinaryData = c.BinaryData,
					};
			return (DbQuery<TraceProduccionView>)x;
		}

		public void Guardar(TraceProduccion Objeto)
		{
			try
			{
				db.TraceProduccion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TraceProduccion Objeto)
		{
			try
			{
				db.TraceProduccion.Attach(Objeto);
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
				TraceProduccion Objeto = this.ObtenerPorId(IdObjeto);
				db.TraceProduccion.Remove(Objeto);
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

		public DbQuery<TraceProduccionViewT> JsonT(string term)
		{
			var x = from c in db.TraceProduccion
					select new TraceProduccionViewT
					{
						 RowNumber = c.RowNumber,
						 EventClass = c.EventClass,
						 TextData = c.TextData,
						 ApplicationName = c.ApplicationName,
						 NTUserName = c.NTUserName,
						 LoginName = c.LoginName,
						 CPU = c.CPU,
						 Reads = c.Reads,
						 Writes = c.Writes,
						 Duration = c.Duration,
						 ClientProcessID = c.ClientProcessID,
						 SPID = c.SPID,
						 StartTime = c.StartTime,
						 EndTime = c.EndTime,
						 BinaryData = c.BinaryData,
					};
			return (DbQuery<TraceProduccionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
