
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
	public partial class ExpedientesCategoriasRelAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesCategoriasRel ObtenerPorId(int Id)
		{
			return db.ExpedientesCategoriasRel.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesCategoriasRel> ObtenerTodo()
		{
			return (DbQuery<ExpedientesCategoriasRel>)db.ExpedientesCategoriasRel;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesCategoriasRel
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesCategoriasRelView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesCategoriasRel
					select new ExpedientesCategoriasRelView
					{
						 Categoria = c.Categoria,
						 Expediente = c.Expediente,
					};
			return (DbQuery<ExpedientesCategoriasRelView>)x;
		}

		public void Guardar(ExpedientesCategoriasRel Objeto)
		{
			try
			{
				db.ExpedientesCategoriasRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesCategoriasRel Objeto)
		{
			try
			{
				db.ExpedientesCategoriasRel.Attach(Objeto);
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
				ExpedientesCategoriasRel Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesCategoriasRel.Remove(Objeto);
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

		public DbQuery<ExpedientesCategoriasRelViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesCategoriasRel
					select new ExpedientesCategoriasRelViewT
					{
						 Categoria = c.Categoria,
						 Expediente = c.Expediente,
					};
			return (DbQuery<ExpedientesCategoriasRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
