
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
	public partial class LiquidacionAD
	{
		private BDEntities db = new BDEntities();

		public Liquidacion ObtenerPorId(int Id)
		{
			return db.Liquidacion.Single(c => c.Id == Id);
		}

		public DbQuery<Liquidacion> ObtenerTodo()
		{
			return (DbQuery<Liquidacion>)db.Liquidacion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Liquidacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LiquidacionView> ObtenerParaGrilla()
		{
			var x = from c in db.Liquidacion
					where c.Activo == true
					select new LiquidacionView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 FechaLiq = c.FechaLiq,
						 CapitalTotal = c.CapitalTotal,
						 InteresTotal = c.InteresTotal,
						 InteresAplicado = c.InteresAplicado,
						 TipoHonorario = c.TipoHonorario,
						 IVA = c.IVA,
						 Capitaliza = c.Capitaliza,
						 HonorariosTotal = c.HonorariosTotal,
						 GastosTotal = c.GastosTotal,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 IVAIntereses = c.IVAIntereses,
					};
			return (DbQuery<LiquidacionView>)x;
		}

		public void Guardar(Liquidacion Objeto)
		{
			try
			{
				db.Liquidacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Liquidacion Objeto)
		{
			try
			{
				db.Liquidacion.Attach(Objeto);
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
				Liquidacion Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<LiquidacionViewT> JsonT(string term)
		{
			var x = from c in db.Liquidacion
					where c.Activo == true
					select new LiquidacionViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 FechaLiq = c.FechaLiq,
						 CapitalTotal = c.CapitalTotal,
						 InteresTotal = c.InteresTotal,
						 InteresAplicado = c.InteresAplicado,
						 TipoHonorario = c.TipoHonorario,
						 IVA = c.IVA,
						 Capitaliza = c.Capitaliza,
						 HonorariosTotal = c.HonorariosTotal,
						 GastosTotal = c.GastosTotal,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 IVAIntereses = c.IVAIntereses,
					};
			return (DbQuery<LiquidacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
