
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
	public partial class LiquidacionConfiguracionValoresAD
	{
		private BDEntities db = new BDEntities();

		public LiquidacionConfiguracionValores ObtenerPorId(int Id)
		{
			return db.LiquidacionConfiguracionValores.Single(c => c.Id == Id);
		}

		public DbQuery<LiquidacionConfiguracionValores> ObtenerTodo()
		{
			return (DbQuery<LiquidacionConfiguracionValores>)db.LiquidacionConfiguracionValores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LiquidacionConfiguracionValores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LiquidacionConfiguracionValoresView> ObtenerParaGrilla()
		{
			var x = from c in db.LiquidacionConfiguracionValores
					select new LiquidacionConfiguracionValoresView
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Configuracion = c.Configuracion,
						 Valor = c.Valor,
					};
			return (DbQuery<LiquidacionConfiguracionValoresView>)x;
		}

		public void Guardar(LiquidacionConfiguracionValores Objeto)
		{
			try
			{
				db.LiquidacionConfiguracionValores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionConfiguracionValores Objeto)
		{
			try
			{
				db.LiquidacionConfiguracionValores.Attach(Objeto);
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
				LiquidacionConfiguracionValores Objeto = this.ObtenerPorId(IdObjeto);
				db.LiquidacionConfiguracionValores.Remove(Objeto);
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

		public DbQuery<LiquidacionConfiguracionValoresViewT> JsonT(string term)
		{
			var x = from c in db.LiquidacionConfiguracionValores
					select new LiquidacionConfiguracionValoresViewT
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Configuracion = c.Configuracion,
						 Valor = c.Valor,
					};
			return (DbQuery<LiquidacionConfiguracionValoresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
