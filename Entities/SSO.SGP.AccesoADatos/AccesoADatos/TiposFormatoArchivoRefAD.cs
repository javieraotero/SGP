
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
	public partial class TiposFormatoArchivoRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposFormatoArchivoRef ObtenerPorId(int Id)
		{
			return db.TiposFormatoArchivoRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposFormatoArchivoRef> ObtenerTodo()
		{
			return (DbQuery<TiposFormatoArchivoRef>)db.TiposFormatoArchivoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposFormatoArchivoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposFormatoArchivoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposFormatoArchivoRef
					select new TiposFormatoArchivoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposFormatoArchivoRefView>)x;
		}

		public void Guardar(TiposFormatoArchivoRef Objeto)
		{
			try
			{
				db.TiposFormatoArchivoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposFormatoArchivoRef Objeto)
		{
			try
			{
				db.TiposFormatoArchivoRef.Attach(Objeto);
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
				TiposFormatoArchivoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposFormatoArchivoRef.Remove(Objeto);
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

		public DbQuery<TiposFormatoArchivoRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposFormatoArchivoRef
					select new TiposFormatoArchivoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposFormatoArchivoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
