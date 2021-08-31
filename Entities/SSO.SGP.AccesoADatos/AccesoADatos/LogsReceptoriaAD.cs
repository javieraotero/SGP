
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
	public partial class LogsReceptoriaAD
	{
		private BDEntities db = new BDEntities();

		public LogsReceptoria ObtenerPorId(int Id)
		{
			return db.LogsReceptoria.Single(c => c.Id == Id);
		}

		public DbQuery<LogsReceptoria> ObtenerTodo()
		{
			return (DbQuery<LogsReceptoria>)db.LogsReceptoria;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LogsReceptoria
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LogsReceptoriaView> ObtenerParaGrilla()
		{
			var x = from c in db.LogsReceptoria
					select new LogsReceptoriaView
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Juzgado = c.Juzgado,
						 Fecha = c.Fecha,
						 Categoria = c.Categoria,
						 Contadores = c.Contadores,
						 IdCategoria = c.IdCategoria,
					};
			return (DbQuery<LogsReceptoriaView>)x;
		}

		public void Guardar(LogsReceptoria Objeto)
		{
			try
			{
				db.LogsReceptoria.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LogsReceptoria Objeto)
		{
			try
			{
				db.LogsReceptoria.Attach(Objeto);
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
				LogsReceptoria Objeto = this.ObtenerPorId(IdObjeto);
				db.LogsReceptoria.Remove(Objeto);
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

		public DbQuery<LogsReceptoriaViewT> JsonT(string term)
		{
			var x = from c in db.LogsReceptoria
					select new LogsReceptoriaViewT
					{
						 Id = c.Id,
						 Numero = c.Numero,
						 Juzgado = c.Juzgado,
						 Fecha = c.Fecha,
						 Categoria = c.Categoria,
						 Contadores = c.Contadores,
						 IdCategoria = c.IdCategoria,
					};
			return (DbQuery<LogsReceptoriaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
