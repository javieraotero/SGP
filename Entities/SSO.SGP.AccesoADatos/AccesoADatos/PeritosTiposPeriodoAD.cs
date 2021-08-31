
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
	public partial class PeritosTiposPeriodoAD
	{
		private BDEntities db = new BDEntities();

		public PeritosTiposPeriodo ObtenerPorId(int Id)
		{
			return db.PeritosTiposPeriodo.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosTiposPeriodo> ObtenerTodo()
		{
			return (DbQuery<PeritosTiposPeriodo>)db.PeritosTiposPeriodo;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosTiposPeriodo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosTiposPeriodoView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosTiposPeriodo
					select new PeritosTiposPeriodoView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PeritosTiposPeriodoView>)x;
		}

		public void Guardar(PeritosTiposPeriodo Objeto)
		{
			try
			{
				db.PeritosTiposPeriodo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosTiposPeriodo Objeto)
		{
			try
			{
				db.PeritosTiposPeriodo.Attach(Objeto);
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
				PeritosTiposPeriodo Objeto = this.ObtenerPorId(IdObjeto);
				db.PeritosTiposPeriodo.Remove(Objeto);
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

		public DbQuery<PeritosTiposPeriodoViewT> JsonT(string term)
		{
			var x = from c in db.PeritosTiposPeriodo
					select new PeritosTiposPeriodoViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PeritosTiposPeriodoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
