
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
	public partial class PresupuestacionAD
	{
		private BDEntities db = new BDEntities();

		public Presupuestacion ObtenerPorId(int Id)
		{
			return db.Presupuestacion.Single(c => c.Id == Id);
		}

		public DbQuery<Presupuestacion> ObtenerTodo()
		{
			return (DbQuery<Presupuestacion>)db.Presupuestacion.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Presupuestacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresupuestacionView> ObtenerParaGrilla()
		{
			var x = from c in db.Presupuestacion
					where c.Activo == true
					select new PresupuestacionView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 FechaPresu = c.FechaPresu,
						 CapitalTotal = c.CapitalTotal,
						 InteresTotal = c.InteresTotal,
						 InteresAplicado = c.InteresAplicado,
						 TipoHonorario = c.TipoHonorario,
						 IVA = c.IVA,
						 Capitaliza = c.Capitaliza,
						 HonorariosTotal = c.HonorariosTotal,
						 GastosTotal = c.GastosTotal,
						 FechaInicioEjecutivo = c.FechaInicioEjecutivo,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 IVAIntereses = c.IVAIntereses,
					};
			return (DbQuery<PresupuestacionView>)x;
		}

		public void Guardar(Presupuestacion Objeto)
		{
			try
			{
				db.Presupuestacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Presupuestacion Objeto)
		{
			try
			{
				db.Presupuestacion.Attach(Objeto);
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
				Presupuestacion Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<PresupuestacionViewT> JsonT(string term)
		{
			var x = from c in db.Presupuestacion
					where c.Activo == true
					select new PresupuestacionViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 FechaPresu = c.FechaPresu,
						 CapitalTotal = c.CapitalTotal,
						 InteresTotal = c.InteresTotal,
						 InteresAplicado = c.InteresAplicado,
						 TipoHonorario = c.TipoHonorario,
						 IVA = c.IVA,
						 Capitaliza = c.Capitaliza,
						 HonorariosTotal = c.HonorariosTotal,
						 GastosTotal = c.GastosTotal,
						 FechaInicioEjecutivo = c.FechaInicioEjecutivo,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 IVAIntereses = c.IVAIntereses,
					};
			return (DbQuery<PresupuestacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
