
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
	public partial class UnidadesrrhhRefAD
	{
		private BDEntities db = new BDEntities();

		public UnidadesrrhhRef ObtenerPorId(int Id)
		{
			return db.UnidadesrrhhRef.Single(c => c.Id == Id);
		}

		public DbQuery<UnidadesrrhhRef> ObtenerTodo()
		{
			return (DbQuery<UnidadesrrhhRef>)db.UnidadesrrhhRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.UnidadesrrhhRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<UnidadesrrhhRefView> ObtenerParaGrilla()
		{
			var x = from c in db.UnidadesrrhhRef
					select new UnidadesrrhhRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<UnidadesrrhhRefView>)x;
		}

		public void Guardar(UnidadesrrhhRef Objeto)
		{
			try
			{
				db.UnidadesrrhhRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(UnidadesrrhhRef Objeto)
		{
			try
			{
				db.UnidadesrrhhRef.Attach(Objeto);
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
				UnidadesrrhhRef Objeto = this.ObtenerPorId(IdObjeto);
				db.UnidadesrrhhRef.Remove(Objeto);
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

		public DbQuery<UnidadesrrhhRefViewT> JsonT(string term)
		{
			var x = from c in db.UnidadesrrhhRef
					select new UnidadesrrhhRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<UnidadesrrhhRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
