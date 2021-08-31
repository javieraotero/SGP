
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
	public partial class ExpedientesEstadoAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesEstado ObtenerPorId(int Id)
		{
			return db.ExpedientesEstado.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesEstado> ObtenerTodo()
		{
			return (DbQuery<ExpedientesEstado>)db.ExpedientesEstado;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesEstado
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesEstadoView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesEstado
					select new ExpedientesEstadoView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Estado = c.Estado,
						 Fecha = c.Fecha,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 CambioManual = c.CambioManual,
					};
			return (DbQuery<ExpedientesEstadoView>)x;
		}

		public void Guardar(ExpedientesEstado Objeto)
		{
			try
			{
				db.ExpedientesEstado.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesEstado Objeto)
		{
			try
			{
				db.ExpedientesEstado.Attach(Objeto);
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
				ExpedientesEstado Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesEstado.Remove(Objeto);
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

		public DbQuery<ExpedientesEstadoViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesEstado
					select new ExpedientesEstadoViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Estado = c.Estado,
						 Fecha = c.Fecha,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 CambioManual = c.CambioManual,
					};
			return (DbQuery<ExpedientesEstadoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
