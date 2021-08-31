
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
	public partial class PeritosSancionesAD
	{
		private BDEntities db = new BDEntities();

		public PeritosSanciones ObtenerPorId(int Id)
		{
			return db.PeritosSanciones.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosSanciones> ObtenerTodo()
		{
			return (DbQuery<PeritosSanciones>)db.PeritosSanciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosSanciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosSancionesView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosSanciones
					select new PeritosSancionesView
					{
						 Id = c.Id,
						 Perito = c.Perito,
						 SuspendidoDesde = c.SuspendidoDesde,
						 SuspendidoHasta = c.SuspendidoHasta,
						 Sanciones = c.Sanciones,
					};
			return (DbQuery<PeritosSancionesView>)x;
		}

		public void Guardar(PeritosSanciones Objeto)
		{
			try
			{
				db.PeritosSanciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosSanciones Objeto)
		{
			try
			{
				db.PeritosSanciones.Attach(Objeto);
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
				PeritosSanciones Objeto = this.ObtenerPorId(IdObjeto);
				db.PeritosSanciones.Remove(Objeto);
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

		public DbQuery<PeritosSancionesViewT> JsonT(string term)
		{
			var x = from c in db.PeritosSanciones
					select new PeritosSancionesViewT
					{
						 Id = c.Id,
						 Perito = c.Perito,
						 SuspendidoDesde = c.SuspendidoDesde,
						 SuspendidoHasta = c.SuspendidoHasta,
						 Sanciones = c.Sanciones,
					};
			return (DbQuery<PeritosSancionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
