
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
	public partial class LiquidacionGastosAD
	{
		private BDEntities db = new BDEntities();

		public LiquidacionGastos ObtenerPorId(int Id)
		{
			return db.LiquidacionGastos.Single(c => c.Id == Id);
		}

		public DbQuery<LiquidacionGastos> ObtenerTodo()
		{
			return (DbQuery<LiquidacionGastos>)db.LiquidacionGastos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LiquidacionGastos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LiquidacionGastosView> ObtenerParaGrilla()
		{
			var x = from c in db.LiquidacionGastos
					select new LiquidacionGastosView
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<LiquidacionGastosView>)x;
		}

		public void Guardar(LiquidacionGastos Objeto)
		{
			try
			{
				db.LiquidacionGastos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionGastos Objeto)
		{
			try
			{
				db.LiquidacionGastos.Attach(Objeto);
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
				LiquidacionGastos Objeto = this.ObtenerPorId(IdObjeto);
				db.LiquidacionGastos.Remove(Objeto);
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

		public DbQuery<LiquidacionGastosViewT> JsonT(string term)
		{
			var x = from c in db.LiquidacionGastos
					select new LiquidacionGastosViewT
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<LiquidacionGastosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
