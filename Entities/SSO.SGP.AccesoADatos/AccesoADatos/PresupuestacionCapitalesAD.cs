
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
	public partial class PresupuestacionCapitalesAD
	{
		private BDEntities db = new BDEntities();

		public PresupuestacionCapitales ObtenerPorId(int Id)
		{
			return db.PresupuestacionCapitales.Single(c => c.Id == Id);
		}

		public DbQuery<PresupuestacionCapitales> ObtenerTodo()
		{
			return (DbQuery<PresupuestacionCapitales>)db.PresupuestacionCapitales;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PresupuestacionCapitales
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresupuestacionCapitalesView> ObtenerParaGrilla()
		{
			var x = from c in db.PresupuestacionCapitales
					select new PresupuestacionCapitalesView
					{
						 Id = c.Id,
						 Presupuestacion = c.Presupuestacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PresupuestacionCapitalesView>)x;
		}

		public void Guardar(PresupuestacionCapitales Objeto)
		{
			try
			{
				db.PresupuestacionCapitales.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionCapitales Objeto)
		{
			try
			{
				db.PresupuestacionCapitales.Attach(Objeto);
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
				PresupuestacionCapitales Objeto = this.ObtenerPorId(IdObjeto);
				db.PresupuestacionCapitales.Remove(Objeto);
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

		public DbQuery<PresupuestacionCapitalesViewT> JsonT(string term)
		{
			var x = from c in db.PresupuestacionCapitales
					select new PresupuestacionCapitalesViewT
					{
						 Id = c.Id,
						 Presupuestacion = c.Presupuestacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PresupuestacionCapitalesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
