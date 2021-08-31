
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
	public partial class CambiosRadicacionAD
	{
		private BDEntities db = new BDEntities();

		public CambiosRadicacion ObtenerPorId(int Id)
		{
			return db.CambiosRadicacion.Single(c => c.Id == Id);
		}

		public DbQuery<CambiosRadicacion> ObtenerTodo()
		{
			return (DbQuery<CambiosRadicacion>)db.CambiosRadicacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CambiosRadicacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CambiosRadicacionView> ObtenerParaGrilla()
		{
			var x = from c in db.CambiosRadicacion
					select new CambiosRadicacionView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Causa = c.Causa,
						 Juzgado = c.Juzgado,
					};
			return (DbQuery<CambiosRadicacionView>)x;
		}

		public void Guardar(CambiosRadicacion Objeto)
		{
			try
			{
				db.CambiosRadicacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CambiosRadicacion Objeto)
		{
			try
			{
				db.CambiosRadicacion.Attach(Objeto);
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
				CambiosRadicacion Objeto = this.ObtenerPorId(IdObjeto);
				db.CambiosRadicacion.Remove(Objeto);
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

		public DbQuery<CambiosRadicacionViewT> JsonT(string term)
		{
			var x = from c in db.CambiosRadicacion
					select new CambiosRadicacionViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Causa = c.Causa,
						 Juzgado = c.Juzgado,
					};
			return (DbQuery<CambiosRadicacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
