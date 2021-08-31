
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
	public partial class TiposEscolaridadRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposEscolaridadRef ObtenerPorId(int Id)
		{
			return db.TiposEscolaridadRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposEscolaridadRef> ObtenerTodo()
		{
			return (DbQuery<TiposEscolaridadRef>)db.TiposEscolaridadRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposEscolaridadRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposEscolaridadRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposEscolaridadRef
					select new TiposEscolaridadRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposEscolaridadRefView>)x;
		}

		public void Guardar(TiposEscolaridadRef Objeto)
		{
			try
			{
				db.TiposEscolaridadRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposEscolaridadRef Objeto)
		{
			try
			{
				db.TiposEscolaridadRef.Attach(Objeto);
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
				TiposEscolaridadRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposEscolaridadRef.Remove(Objeto);
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

		public DbQuery<TiposEscolaridadRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposEscolaridadRef
					select new TiposEscolaridadRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposEscolaridadRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
