
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
	public partial class PresupuestacionGastosAD
	{
		private BDEntities db = new BDEntities();

		public PresupuestacionGastos ObtenerPorId(int Id)
		{
			return db.PresupuestacionGastos.Single(c => c.Id == Id);
		}

		public DbQuery<PresupuestacionGastos> ObtenerTodo()
		{
			return (DbQuery<PresupuestacionGastos>)db.PresupuestacionGastos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PresupuestacionGastos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PresupuestacionGastosView> ObtenerParaGrilla()
		{
			var x = from c in db.PresupuestacionGastos
					select new PresupuestacionGastosView
					{
						 Id = c.Id,
						 Presupuestacion = c.Presupuestacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PresupuestacionGastosView>)x;
		}

		public void Guardar(PresupuestacionGastos Objeto)
		{
			try
			{
				db.PresupuestacionGastos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PresupuestacionGastos Objeto)
		{
			try
			{
				db.PresupuestacionGastos.Attach(Objeto);
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
				PresupuestacionGastos Objeto = this.ObtenerPorId(IdObjeto);
				db.PresupuestacionGastos.Remove(Objeto);
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

		public DbQuery<PresupuestacionGastosViewT> JsonT(string term)
		{
			var x = from c in db.PresupuestacionGastos
					select new PresupuestacionGastosViewT
					{
						 Id = c.Id,
						 Presupuestacion = c.Presupuestacion,
						 Fecha = c.Fecha,
						 Monto = c.Monto,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<PresupuestacionGastosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
