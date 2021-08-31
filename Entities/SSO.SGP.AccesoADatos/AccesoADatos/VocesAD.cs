
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
	public partial class VocesAD
	{
		private BDEntities db = new BDEntities();

		public Voces ObtenerPorId(int Id)
		{
			return db.Voces.Single(c => c.Id == Id);
		}

		public void ejecutarSQL(string sql) { 
			db.Database.ExecuteSqlCommand(sql);
		}

		public DbQuery<Voces> ObtenerTodo()
		{
			return (DbQuery<Voces>)db.Voces;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Voces
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<VocesView> ObtenerParaGrilla()
		{
			var x = from c in db.Voces
					select new VocesView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 PerteneceSAIJ = c.PerteneceSAIJ,
						 Activa = c.Activa,
					};
			return (DbQuery<VocesView>)x;
		}

		public void Guardar(Voces Objeto)
		{
			try
			{
				db.Voces.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Voces Objeto)
		{
			try
			{
				db.Voces.Attach(Objeto);
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
				Voces Objeto = this.ObtenerPorId(IdObjeto);
				db.Voces.Remove(Objeto);
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

		public DbQuery<VocesViewT> JsonT(string term)
		{
			var x = from c in db.Voces
					select new VocesViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 PerteneceSAIJ = c.PerteneceSAIJ,
						 Activa = c.Activa,
					};
			return (DbQuery<VocesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
