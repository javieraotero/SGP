
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
	public partial class CallesRefAD
	{
		private BDEntities db = new BDEntities();

		public CallesRef ObtenerPorId(int Id)
		{
			return db.CallesRef.Single(c => c.Id == Id);
		}

		public DbQuery<CallesRef> ObtenerTodo()
		{
			return (DbQuery<CallesRef>)db.CallesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CallesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CallesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CallesRef
					select new CallesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Localidad = c.Localidad,
					};
			return (DbQuery<CallesRefView>)x;
		}

		public void Guardar(CallesRef Objeto)
		{
			try
			{
				db.CallesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CallesRef Objeto)
		{
			try
			{
				db.CallesRef.Attach(Objeto);
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
				CallesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CallesRef.Remove(Objeto);
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

		public DbQuery<CallesRefViewT> JsonT(string term)
		{
			var x = from c in db.CallesRef
					select new CallesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Localidad = c.Localidad,
					};
			return (DbQuery<CallesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
