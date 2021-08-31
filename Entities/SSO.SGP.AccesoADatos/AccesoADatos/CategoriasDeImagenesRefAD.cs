
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
	public partial class CategoriasDeImagenesRefAD
	{
		private BDEntities db = new BDEntities();

		public CategoriasDeImagenesRef ObtenerPorId(int Id)
		{
			return db.CategoriasDeImagenesRef.Single(c => c.Id == Id);
		}

		public DbQuery<CategoriasDeImagenesRef> ObtenerTodo()
		{
			return (DbQuery<CategoriasDeImagenesRef>)db.CategoriasDeImagenesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CategoriasDeImagenesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CategoriasDeImagenesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CategoriasDeImagenesRef
					select new CategoriasDeImagenesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CategoriasDeImagenesRefView>)x;
		}

		public void Guardar(CategoriasDeImagenesRef Objeto)
		{
			try
			{
				db.CategoriasDeImagenesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasDeImagenesRef Objeto)
		{
			try
			{
				db.CategoriasDeImagenesRef.Attach(Objeto);
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
				CategoriasDeImagenesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CategoriasDeImagenesRef.Remove(Objeto);
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

		public DbQuery<CategoriasDeImagenesRefViewT> JsonT(string term)
		{
			var x = from c in db.CategoriasDeImagenesRef
					select new CategoriasDeImagenesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CategoriasDeImagenesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
