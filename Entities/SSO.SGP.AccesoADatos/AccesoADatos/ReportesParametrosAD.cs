
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
	public partial class ReportesParametrosAD
	{
		private BDEntities db = new BDEntities();

		public ReportesParametros ObtenerPorId(int Id)
		{
			return db.ReportesParametros.Single(c => c.Id == Id);
		}

		public DbQuery<ReportesParametros> ObtenerTodo()
		{
			return (DbQuery<ReportesParametros>)db.ReportesParametros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ReportesParametros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ReportesParametrosView> ObtenerParaGrilla()
		{
			var x = from c in db.ReportesParametros
					select new ReportesParametrosView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 //Valor = c.Valor,
						 Reporte = c.Reporte,
					};
			return (DbQuery<ReportesParametrosView>)x;
		}

		public void Guardar(ReportesParametros Objeto)
		{
			try
			{
				db.ReportesParametros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ReportesParametros Objeto)
		{
			try
			{
				db.ReportesParametros.Attach(Objeto);
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
				ReportesParametros Objeto = this.ObtenerPorId(IdObjeto);
				db.ReportesParametros.Remove(Objeto);
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

		public DbQuery<ReportesParametrosViewT> JsonT(string term)
		{
			var x = from c in db.ReportesParametros
					select new ReportesParametrosViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 //Valor = c.Valor,
						 Reporte = c.Reporte
					};
			return (DbQuery<ReportesParametrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
