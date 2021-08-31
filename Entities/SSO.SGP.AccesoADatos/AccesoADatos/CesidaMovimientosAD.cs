
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
	public partial class CesidaMovimientosAD
	{
		private BDEntities db = new BDEntities();

		public CesidaMovimientos ObtenerPorId(int Id)
		{
			return db.CesidaMovimientos.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaMovimientos> ObtenerTodo()
		{
			return (DbQuery<CesidaMovimientos>)db.CesidaMovimientos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaMovimientos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaMovimientosView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaMovimientos
					select new CesidaMovimientosView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 CodigoCesida = c.CodigoCesida,
						 ApiURLProduccion = c.ApiURLProduccion,
						 ApiURLPruebas = c.ApiURLPruebas,
					};
			return (DbQuery<CesidaMovimientosView>)x;
		}

		public void Guardar(CesidaMovimientos Objeto)
		{
			try
			{
				db.CesidaMovimientos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaMovimientos Objeto)
		{
			try
			{
				db.CesidaMovimientos.Attach(Objeto);
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
				CesidaMovimientos Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaMovimientos.Remove(Objeto);
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

		public DbQuery<CesidaMovimientosViewT> JsonT(string term)
		{
			var x = from c in db.CesidaMovimientos
					select new CesidaMovimientosViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 CodigoCesida = c.CodigoCesida,
						 ApiURLProduccion = c.ApiURLProduccion,
						 ApiURLPruebas = c.ApiURLPruebas,
					};
			return (DbQuery<CesidaMovimientosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
