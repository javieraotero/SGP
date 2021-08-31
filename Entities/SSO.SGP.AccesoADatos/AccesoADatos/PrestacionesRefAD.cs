
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
	public partial class PrestacionesRefAD
	{
		private BDEntities db = new BDEntities();

		public PrestacionesRef ObtenerPorId(int Id)
		{
			return db.PrestacionesRef.Single(c => c.Id == Id);
		}

		public DbQuery<PrestacionesRef> ObtenerTodo()
		{
			return (DbQuery<PrestacionesRef>)db.PrestacionesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PrestacionesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PrestacionesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.PrestacionesRef
					select new PrestacionesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PrestacionesRefView>)x;
		}

		public void Guardar(PrestacionesRef Objeto)
		{
			try
			{
				db.PrestacionesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PrestacionesRef Objeto)
		{
			try
			{
				db.PrestacionesRef.Attach(Objeto);
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
				PrestacionesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.PrestacionesRef.Remove(Objeto);
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

		public DbQuery<PrestacionesRefViewT> JsonT(string term)
		{
			var x = from c in db.PrestacionesRef
					select new PrestacionesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PrestacionesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
