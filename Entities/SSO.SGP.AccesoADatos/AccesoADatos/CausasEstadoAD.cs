
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
	public partial class CausasEstadoAD
	{
		private BDEntities db = new BDEntities();

		public CausasEstado ObtenerPorId(int Id)
		{
			return db.CausasEstado.Single(c => c.Id == Id);
		}

		public DbQuery<CausasEstado> ObtenerTodo()
		{
			return (DbQuery<CausasEstado>)db.CausasEstado;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CausasEstado
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CausasEstadoView> ObtenerParaGrilla()
		{
			var x = from c in db.CausasEstado
					select new CausasEstadoView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Actuacion = c.Actuacion,
						 Estado = c.Estado,
						 Fecha = c.Fecha,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 CambioManual = c.CambioManual,
					};
			return (DbQuery<CausasEstadoView>)x;
		}

		public void Guardar(CausasEstado Objeto)
		{
			try
			{
				db.CausasEstado.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasEstado Objeto)
		{
			try
			{
				db.CausasEstado.Attach(Objeto);
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
				CausasEstado Objeto = this.ObtenerPorId(IdObjeto);
				db.CausasEstado.Remove(Objeto);
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

		public DbQuery<CausasEstadoViewT> JsonT(string term)
		{
			var x = from c in db.CausasEstado
					select new CausasEstadoViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Actuacion = c.Actuacion,
						 Estado = c.Estado,
						 Fecha = c.Fecha,
						 Usuario = c.Usuario,
						 Observaciones = c.Observaciones,
						 CambioManual = c.CambioManual,
					};
			return (DbQuery<CausasEstadoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
