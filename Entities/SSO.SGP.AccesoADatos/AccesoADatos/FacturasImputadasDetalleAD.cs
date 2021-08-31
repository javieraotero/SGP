
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
	public partial class FacturasImputadasDetalleAD
	{
		private BDEntities db = new BDEntities();

		public FacturasImputadasDetalle ObtenerPorId(int Id)
		{
			return db.FacturasImputadasDetalle.Single(c => c.Id == Id);
		}

		public DbQuery<FacturasImputadasDetalle> ObtenerTodo()
		{
			return (DbQuery<FacturasImputadasDetalle>)db.FacturasImputadasDetalle;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.FacturasImputadasDetalle
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FacturasImputadasDetalleView> ObtenerParaGrilla()
		{
			var x = from c in db.FacturasImputadasDetalle
					select new FacturasImputadasDetalleView
					{
						 Id = c.Id,
						 FacturaImputada = c.FacturaImputada,
						 Partida = c.Partida,
						 Division = c.Division,
						 Importe = c.Importe,
					};
			return (DbQuery<FacturasImputadasDetalleView>)x;
		}

		public void Guardar(FacturasImputadasDetalle Objeto)
		{
			try
			{
				db.FacturasImputadasDetalle.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(FacturasImputadasDetalle Objeto)
		{
			try
			{
				db.FacturasImputadasDetalle.Attach(Objeto);
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
				FacturasImputadasDetalle Objeto = this.ObtenerPorId(IdObjeto);
				db.FacturasImputadasDetalle.Remove(Objeto);
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

		public DbQuery<FacturasImputadasDetalleViewT> JsonT(string term)
		{
			var x = from c in db.FacturasImputadasDetalle
					select new FacturasImputadasDetalleViewT
					{
						 Id = c.Id,
						 FacturaImputada = c.FacturaImputada,
						 Partida = c.Partida,
						 Division = c.Division,
						 Importe = c.Importe,
					};
			return (DbQuery<FacturasImputadasDetalleViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
