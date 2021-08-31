
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
	public partial class CategoriasCausasAD
	{
		private BDEntities db = new BDEntities();

		public CategoriasCausas ObtenerPorId(int Id)
		{
			return db.CategoriasCausas.Single(c => c.Id == Id);
		}

		public DbQuery<CategoriasCausas> ObtenerTodo()
		{
			return (DbQuery<CategoriasCausas>)db.CategoriasCausas.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CategoriasCausas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CategoriasCausasView> ObtenerParaGrilla()
		{
			var x = from c in db.CategoriasCausas
					where c.Activo == true
					select new CategoriasCausasView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
						 Activo = c.Activo,
					};
			return (DbQuery<CategoriasCausasView>)x;
		}

		public void Guardar(CategoriasCausas Objeto)
		{
			try
			{
				db.CategoriasCausas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasCausas Objeto)
		{
			try
			{
				db.CategoriasCausas.Attach(Objeto);
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
				CategoriasCausas Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<CategoriasCausasViewT> JsonT(string term)
		{
			var x = from c in db.CategoriasCausas
					where c.Activo == true
					select new CategoriasCausasViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mnemo = c.Mnemo,
						 Activo = c.Activo,
					};
			return (DbQuery<CategoriasCausasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
