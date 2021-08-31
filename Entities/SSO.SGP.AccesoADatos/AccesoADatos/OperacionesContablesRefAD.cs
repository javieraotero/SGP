
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
	public partial class OperacionesContablesRefAD
	{
		private BDEntities db = new BDEntities();

		public OperacionesContablesRef ObtenerPorId(int Id)
		{
			return db.OperacionesContablesRef.Single(c => c.Id == Id);
		}

		public DbQuery<OperacionesContablesRef> ObtenerTodo()
		{
			return (DbQuery<OperacionesContablesRef>)db.OperacionesContablesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.OperacionesContablesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<OperacionesContablesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.OperacionesContablesRef
					select new OperacionesContablesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Imputa = c.Imputa,
					};
			return (DbQuery<OperacionesContablesRefView>)x;
		}

		public void Guardar(OperacionesContablesRef Objeto)
		{
			try
			{
				db.OperacionesContablesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OperacionesContablesRef Objeto)
		{
			try
			{
				db.OperacionesContablesRef.Attach(Objeto);
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
				OperacionesContablesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.OperacionesContablesRef.Remove(Objeto);
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

		public DbQuery<OperacionesContablesRefViewT> JsonT(string term)
		{
			var x = from c in db.OperacionesContablesRef
					select new OperacionesContablesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Imputa = c.Imputa,
					};
			return (DbQuery<OperacionesContablesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
