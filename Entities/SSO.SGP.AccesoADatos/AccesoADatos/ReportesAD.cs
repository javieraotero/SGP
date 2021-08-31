
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
	public partial class ReportesAD
	{
		private BDEntities db = new BDEntities();

		public Reportes ObtenerPorId(int Id)
		{
			return db.Reportes.Single(c => c.Id == Id);
		}

		public DbQuery<Reportes> ObtenerTodo()
		{
			return (DbQuery<Reportes>)db.Reportes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Reportes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ReportesView> ObtenerParaGrilla()
		{
			var x = from c in db.Reportes
					select new ReportesView
					{
						 Id = c.Id,
						 NombreDeArchivo = c.NombreDeArchivo,
					};
			return (DbQuery<ReportesView>)x;
		}

		public void Guardar(Reportes Objeto)
		{
			try
			{
				db.Reportes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Reportes Objeto)
		{
			try
			{
				db.Reportes.Attach(Objeto);
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
				Reportes Objeto = this.ObtenerPorId(IdObjeto);
				db.Reportes.Remove(Objeto);
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

		public DbQuery<ReportesViewT> JsonT(string term)
		{
			var x = from c in db.Reportes
					select new ReportesViewT
					{
						 Id = c.Id,
						 NombreDeArchivo = c.NombreDeArchivo,
					};
			return (DbQuery<ReportesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
