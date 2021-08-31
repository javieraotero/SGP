
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
	public partial class ExpedientesOficinasRelAD
	{
		private BDEntities db = new BDEntities();

        //public ExpedientesOficinasRel ObtenerPorId(int Id)
        //{
        //    return db.ExpedientesOficinasRel.Single(c => c.Id == Id);
        //}

		public DbQuery<ExpedientesOficinasRel> ObtenerTodo()
		{
			return (DbQuery<ExpedientesOficinasRel>)db.ExpedientesOficinasRel;
		}

        //public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
        //{
        //    var res = from x in db.ExpedientesOficinasRel
        //        select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
        //    return (DbQuery<SelectOptionsView>)res;
        //}

		public DbQuery<ExpedientesOficinasRelView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesOficinasRel
					select new ExpedientesOficinasRelView
					{
						 Expediente = c.Expediente,
						 Oficina = c.Oficina,
					};
			return (DbQuery<ExpedientesOficinasRelView>)x;
		}

		public void Guardar(ExpedientesOficinasRel Objeto)
		{
			try
			{
				db.ExpedientesOficinasRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesOficinasRel Objeto)
		{
			try
			{
				db.ExpedientesOficinasRel.Attach(Objeto);
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
				ExpedientesOficinasRel Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesOficinasRel.Remove(Objeto);
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

		public DbQuery<ExpedientesOficinasRelViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesOficinasRel
					select new ExpedientesOficinasRelViewT
					{
						 Expediente = c.Expediente,
						 Oficina = c.Oficina,
					};
			return (DbQuery<ExpedientesOficinasRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
