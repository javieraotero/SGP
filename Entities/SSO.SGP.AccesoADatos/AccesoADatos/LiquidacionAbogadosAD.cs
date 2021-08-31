
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
	public partial class LiquidacionAbogadosAD
	{
		private BDEntities db = new BDEntities();

		public LiquidacionAbogados ObtenerPorId(int Id)
		{
			return db.LiquidacionAbogados.Single(c => c.Id == Id);
		}

		public DbQuery<LiquidacionAbogados> ObtenerTodo()
		{
			return (DbQuery<LiquidacionAbogados>)db.LiquidacionAbogados;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LiquidacionAbogados
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LiquidacionAbogadosView> ObtenerParaGrilla()
		{
			var x = from c in db.LiquidacionAbogados
					select new LiquidacionAbogadosView
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Nombre = c.Nombre,
						 IVA = c.IVA,
						 Fecha = c.Fecha,
					};
			return (DbQuery<LiquidacionAbogadosView>)x;
		}

		public void Guardar(LiquidacionAbogados Objeto)
		{
			try
			{
				db.LiquidacionAbogados.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LiquidacionAbogados Objeto)
		{
			try
			{
				db.LiquidacionAbogados.Attach(Objeto);
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
				LiquidacionAbogados Objeto = this.ObtenerPorId(IdObjeto);
				db.LiquidacionAbogados.Remove(Objeto);
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

		public DbQuery<LiquidacionAbogadosViewT> JsonT(string term)
		{
			var x = from c in db.LiquidacionAbogados
					select new LiquidacionAbogadosViewT
					{
						 Id = c.Id,
						 Liquidacion = c.Liquidacion,
						 Nombre = c.Nombre,
						 IVA = c.IVA,
						 Fecha = c.Fecha,
					};
			return (DbQuery<LiquidacionAbogadosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
