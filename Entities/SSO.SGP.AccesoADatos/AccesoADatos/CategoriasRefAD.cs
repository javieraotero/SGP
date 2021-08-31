
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
	public partial class CategoriasRefAD
	{
		private BDEntities db = new BDEntities();

		public CategoriasRef ObtenerPorId(int Id)
		{
			return db.CategoriasRef.Single(c => c.Id == Id);
		}

		public DbQuery<CategoriasRef> ObtenerTodo()
		{
			return (DbQuery<CategoriasRef>)db.CategoriasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CategoriasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CategoriasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CategoriasRef
					select new CategoriasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CategoriasRefView>)x;
		}

		public void Guardar(CategoriasRef Objeto)
		{
			try
			{
				db.CategoriasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasRef Objeto)
		{
			try
			{
				db.CategoriasRef.Attach(Objeto);
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
				CategoriasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CategoriasRef.Remove(Objeto);
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

		public DbQuery<CategoriasRefViewT> JsonT(string term)
		{
			var x = from c in db.CategoriasRef
					select new CategoriasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CategoriasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
