
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
	public partial class PeritosPeriodoAD
	{
		private BDEntities db = new BDEntities();

		public PeritosPeriodo ObtenerPorId(int Id)
		{
			return db.PeritosPeriodo.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosPeriodo> ObtenerTodo()
		{
			return (DbQuery<PeritosPeriodo>)db.PeritosPeriodo.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosPeriodo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosPeriodoView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosPeriodo
					where c.Activo == true
					select new PeritosPeriodoView
					{
						 Id = c.Id,
						 TipoPeriodo = c.TipoPeriodo,
						 FecIniInscripcion = c.FecIniInscripcion,
						 FecFinInscripcion = c.FecFinInscripcion,
						 FecIniPeriodo = c.FecIniPeriodo,
						 FecFinPeriodo = c.FecFinPeriodo,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosPeriodoView>)x;
		}

		public void Guardar(PeritosPeriodo Objeto)
		{
			try
			{
				db.PeritosPeriodo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosPeriodo Objeto)
		{
			try
			{
				db.PeritosPeriodo.Attach(Objeto);
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
				PeritosPeriodo Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<PeritosPeriodoViewT> JsonT(string term)
		{
			var x = from c in db.PeritosPeriodo
					where c.Activo == true
					select new PeritosPeriodoViewT
					{
						 Id = c.Id,
						 TipoPeriodo = c.TipoPeriodo,
						 FecIniInscripcion = c.FecIniInscripcion,
						 FecFinInscripcion = c.FecFinInscripcion,
						 FecIniPeriodo = c.FecIniPeriodo,
						 FecFinPeriodo = c.FecFinPeriodo,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosPeriodoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
