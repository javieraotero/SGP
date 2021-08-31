
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
	public partial class DivisionesExtraPresupuestariasAD
	{
		private BDEntities db = new BDEntities();

		public DivisionesExtraPresupuestarias ObtenerPorId(int Id)
		{
			return db.DivisionesExtraPresupuestarias.Single(c => c.Id == Id);
		}

		public DbQuery<DivisionesExtraPresupuestarias> ObtenerTodo()
		{
			return (DbQuery<DivisionesExtraPresupuestarias>)db.DivisionesExtraPresupuestarias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.DivisionesExtraPresupuestarias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DivisionesExtraPresupuestariasView> ObtenerParaGrilla()
		{
			var x = from c in db.DivisionesExtraPresupuestarias
					select new DivisionesExtraPresupuestariasView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 CodigoCESIDA = c.CodigoCESIDA,
						 PartidaPresupuestaria = c.PartidaPresupuestaria,
					};
			return (DbQuery<DivisionesExtraPresupuestariasView>)x;
		}

		public void Guardar(DivisionesExtraPresupuestarias Objeto)
		{
			try
			{
				db.DivisionesExtraPresupuestarias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DivisionesExtraPresupuestarias Objeto)
		{
			try
			{
				db.DivisionesExtraPresupuestarias.Attach(Objeto);
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
				DivisionesExtraPresupuestarias Objeto = this.ObtenerPorId(IdObjeto);
				db.DivisionesExtraPresupuestarias.Remove(Objeto);
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

		public DbQuery<DivisionesExtraPresupuestariasViewT> JsonT(string term)
		{
			var x = from c in db.DivisionesExtraPresupuestarias
					select new DivisionesExtraPresupuestariasViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 CodigoCESIDA = c.CodigoCESIDA,
						 PartidaPresupuestaria = "modificar este valor"//c.PartidaPresupuestarias.Mnemo,
					};
			return (DbQuery<DivisionesExtraPresupuestariasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
