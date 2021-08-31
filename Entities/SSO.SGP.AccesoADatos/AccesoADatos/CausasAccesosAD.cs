
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
	public partial class CausasAccesosAD
	{
		private BDEntities db = new BDEntities();

		public CausasAccesos ObtenerPorId(int Id)
		{
			return db.CausasAccesos.Single(c => c.Id == Id);
		}

		public DbQuery<CausasAccesos> ObtenerTodo()
		{
			return (DbQuery<CausasAccesos>)db.CausasAccesos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CausasAccesos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CausasAccesosView> ObtenerParaGrilla()
		{
			var x = from c in db.CausasAccesos
					select new CausasAccesosView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Actuacion = c.Actuacion,
						 Usuario = c.Usuario,
						 FechaHora = c.FechaHora,
					};
			return (DbQuery<CausasAccesosView>)x;
		}

		public void Guardar(CausasAccesos Objeto)
		{
			try
			{
				db.CausasAccesos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasAccesos Objeto)
		{
			try
			{
				db.CausasAccesos.Attach(Objeto);
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
				CausasAccesos Objeto = this.ObtenerPorId(IdObjeto);
				db.CausasAccesos.Remove(Objeto);
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

		public DbQuery<CausasAccesosViewT> JsonT(string term)
		{
			var x = from c in db.CausasAccesos
					select new CausasAccesosViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Actuacion = c.Actuacion,
						 Usuario = c.Usuario,
						 FechaHora = c.FechaHora,
					};
			return (DbQuery<CausasAccesosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
