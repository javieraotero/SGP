
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
	public partial class ExpedientesPaseadmAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesPaseadm ObtenerPorId(int Id)
		{
			return db.ExpedientesPaseadm.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesPaseadm> ObtenerTodo()
		{
			return (DbQuery<ExpedientesPaseadm>)db.ExpedientesPaseadm;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesPaseadm
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesPaseadmView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesPaseadm
					select new ExpedientesPaseadmView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Fecha = c.Fecha,
						 OrganismoReceptor = c.OrganismoReceptor,
					};
			return (DbQuery<ExpedientesPaseadmView>)x;
		}

		public void Guardar(ExpedientesPaseadm Objeto)
		{
			try
			{
				db.ExpedientesPaseadm.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPaseadm Objeto)
		{
			try
			{
				db.ExpedientesPaseadm.Attach(Objeto);
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
				ExpedientesPaseadm Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesPaseadm.Remove(Objeto);
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

		public DbQuery<ExpedientesPaseadmViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesPaseadm
					select new ExpedientesPaseadmViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Fecha = c.Fecha,
						 OrganismoReceptor = c.OrganismoReceptor,
					};
			return (DbQuery<ExpedientesPaseadmViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
