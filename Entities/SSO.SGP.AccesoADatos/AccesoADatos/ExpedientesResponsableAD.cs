
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
	public partial class ExpedientesResponsableAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesResponsable ObtenerPorId(int Id)
		{
			return db.ExpedientesResponsable.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesResponsable> ObtenerTodo()
		{
			return (DbQuery<ExpedientesResponsable>)db.ExpedientesResponsable;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesResponsable
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesResponsableView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesResponsable
					select new ExpedientesResponsableView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Fecha = c.Fecha,
						 Responsable = c.Responsable,
						 Cargo = c.Cargo,
						 UsuarioAsignacion = c.UsuarioAsignacion,
						 Observaciones = c.Observaciones,
						 PorSorteo = c.PorSorteo,
					};
			return (DbQuery<ExpedientesResponsableView>)x;
		}

		public void Guardar(ExpedientesResponsable Objeto)
		{
			try
			{
				db.ExpedientesResponsable.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesResponsable Objeto)
		{
			try
			{
				db.ExpedientesResponsable.Attach(Objeto);
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
				ExpedientesResponsable Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesResponsable.Remove(Objeto);
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

		public DbQuery<ExpedientesResponsableViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesResponsable
					select new ExpedientesResponsableViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Fecha = c.Fecha,
						 Responsable = c.Responsable,
						 Cargo = c.Cargo,
						 UsuarioAsignacion = c.UsuarioAsignacion,
						 Observaciones = c.Observaciones,
						 PorSorteo = c.PorSorteo,
					};
			return (DbQuery<ExpedientesResponsableViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
