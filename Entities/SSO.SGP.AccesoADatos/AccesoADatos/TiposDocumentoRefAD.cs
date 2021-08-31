
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
	public partial class TiposDocumentoRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposDocumentoRef ObtenerPorId(int Id)
		{
			return db.TiposDocumentoRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposDocumentoRef> ObtenerTodo()
		{
			return (DbQuery<TiposDocumentoRef>)db.TiposDocumentoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposDocumentoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposDocumentoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposDocumentoRef
					select new TiposDocumentoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposDocumentoRefView>)x;
		}

		public void Guardar(TiposDocumentoRef Objeto)
		{
			try
			{
				db.TiposDocumentoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDocumentoRef Objeto)
		{
			try
			{
				db.TiposDocumentoRef.Attach(Objeto);
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
				TiposDocumentoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposDocumentoRef.Remove(Objeto);
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

		public DbQuery<TiposDocumentoRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposDocumentoRef
					select new TiposDocumentoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposDocumentoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
