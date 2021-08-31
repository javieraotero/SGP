
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
	public partial class CesidaMovimientosAgentesDetallesAD
	{
		private BDEntities db = new BDEntities();

		public CesidaMovimientosAgentesDetalles ObtenerPorId(int Id)
		{
			return db.CesidaMovimientosAgentesDetalles.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaMovimientosAgentesDetalles> ObtenerTodo()
		{
			return (DbQuery<CesidaMovimientosAgentesDetalles>)db.CesidaMovimientosAgentesDetalles;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaMovimientosAgentesDetalles
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaMovimientosAgentesDetallesView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaMovimientosAgentesDetalles
					select new CesidaMovimientosAgentesDetallesView
					{
						 Id = c.Id,
						 MovimientoAgente = c.MovimientoAgente,
						 Parametro = c.Parametro,
						 Valor = c.Valor,
					};
			return (DbQuery<CesidaMovimientosAgentesDetallesView>)x;
		}

		public void Guardar(CesidaMovimientosAgentesDetalles Objeto)
		{
			try
			{
				db.CesidaMovimientosAgentesDetalles.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaMovimientosAgentesDetalles Objeto)
		{
			try
			{
				db.CesidaMovimientosAgentesDetalles.Attach(Objeto);
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
				CesidaMovimientosAgentesDetalles Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaMovimientosAgentesDetalles.Remove(Objeto);
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

		public DbQuery<CesidaMovimientosAgentesDetallesViewT> JsonT(string term)
		{
			var x = from c in db.CesidaMovimientosAgentesDetalles
					select new CesidaMovimientosAgentesDetallesViewT
					{
						 Id = c.Id,
						 MovimientoAgente = c.MovimientoAgente,
						 Parametro = c.Parametro,
						 Valor = c.Valor,
					};
			return (DbQuery<CesidaMovimientosAgentesDetallesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
