
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;
using Syncrosoft.Framework.Utils.Logs;
using System.Collections.Generic;

namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class CesidaParametrosDeMovimientosAD
	{
		private BDEntities db = new BDEntities();

		public CesidaParametrosDeMovimientos ObtenerPorId(int Id)
		{
			return db.CesidaParametrosDeMovimientos.Single(c => c.Id == Id);
		}

        public List<CesidaParametrosDeMovimientos> ObtenerPorMovmiento(int movimiento)
        {
            return db.CesidaParametrosDeMovimientos.Where(c => c.Movimiento == movimiento).OrderBy(o=>o.OrdenPantalla).ToList();
        }

        public DbQuery<CesidaParametrosDeMovimientos> ObtenerTodo()
		{
			return (DbQuery<CesidaParametrosDeMovimientos>)db.CesidaParametrosDeMovimientos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaParametrosDeMovimientos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaParametrosDeMovimientosView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaParametrosDeMovimientos
					select new CesidaParametrosDeMovimientosView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoDeDato = c.TipoDeDato,
						 Obligatorio = c.Obligatorio,
						 Referencia = c.Referencia,
						 Predeterminado = c.Predeterminado,
					};
			return (DbQuery<CesidaParametrosDeMovimientosView>)x;
		}

		public void Guardar(CesidaParametrosDeMovimientos Objeto)
		{
			try
			{
				db.CesidaParametrosDeMovimientos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaParametrosDeMovimientos Objeto)
		{
			try
			{
				db.CesidaParametrosDeMovimientos.Attach(Objeto);
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
				CesidaParametrosDeMovimientos Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaParametrosDeMovimientos.Remove(Objeto);
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

		public DbQuery<CesidaParametrosDeMovimientosViewT> JsonT(string term)
		{
			var x = from c in db.CesidaParametrosDeMovimientos
					select new CesidaParametrosDeMovimientosViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 TipoDeDato = c.TipoDeDato,
						 Obligatorio = c.Obligatorio,
						 Referencia = c.Referencia,
						 Predeterminado = c.Predeterminado,
					};
			return (DbQuery<CesidaParametrosDeMovimientosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
