
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
	public partial class LiquidacionCapitalesAD
	{
		private BDEntities db = new BDEntities();

		public LiquidacionCapitales ObtenerPorId(int Id)
		{
			return db.LiquidacionCapitales.Single(c => c.Id == Id);
		}

		public DbQuery<LiquidacionCapitales> ObtenerTodo()
		{
			return (DbQuery<LiquidacionCapitales>)db.LiquidacionCapitales;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LiquidacionCapitales
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LiquidacionCapitalesView> ObtenerParaGrilla()
		{
			var x = from c in db.LiquidacionCapitales
					select new LiquidacionCapitalesView
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<LiquidacionCapitalesView>)x;
		}

		public void Guardar(LiquidacionCapitales Objeto)
		{
			try
			{
				db.LiquidacionCapitales.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionCapitales Objeto)
		{
			try
			{
				db.LiquidacionCapitales.Attach(Objeto);
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
				LiquidacionCapitales Objeto = this.ObtenerPorId(IdObjeto);
				db.LiquidacionCapitales.Remove(Objeto);
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

		public DbQuery<LiquidacionCapitalesViewT> JsonT(string term)
		{
			var x = from c in db.LiquidacionCapitales
					select new LiquidacionCapitalesViewT
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<LiquidacionCapitalesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
