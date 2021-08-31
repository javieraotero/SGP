
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
	public partial class TiposArchivadoRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposArchivadoRef ObtenerPorId(int Id)
		{
			return db.TiposArchivadoRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposArchivadoRef> ObtenerTodo()
		{
			return (DbQuery<TiposArchivadoRef>)db.TiposArchivadoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposArchivadoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposArchivadoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposArchivadoRef
					select new TiposArchivadoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposArchivadoRefView>)x;
		}

		public void Guardar(TiposArchivadoRef Objeto)
		{
			try
			{
				db.TiposArchivadoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposArchivadoRef Objeto)
		{
			try
			{
				db.TiposArchivadoRef.Attach(Objeto);
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
				TiposArchivadoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposArchivadoRef.Remove(Objeto);
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

		public DbQuery<TiposArchivadoRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposArchivadoRef
					select new TiposArchivadoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposArchivadoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
