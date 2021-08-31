
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
	public partial class CesidaUbicacionesAD
	{
		private BDEntities db = new BDEntities();

		public CesidaUbicaciones ObtenerPorId(int Id)
		{
			return db.CesidaUbicaciones.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaUbicaciones> ObtenerTodo()
		{
			return (DbQuery<CesidaUbicaciones>)db.CesidaUbicaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaUbicaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaUbicacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaUbicaciones
					select new CesidaUbicacionesView
					{
						 Id = c.Id,
						 NUMERO = c.NUMERO,
						 DESCRIPCION = c.DESCRIPCION,
					};
			return (DbQuery<CesidaUbicacionesView>)x;
		}

		public void Guardar(CesidaUbicaciones Objeto)
		{
			try
			{
				db.CesidaUbicaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaUbicaciones Objeto)
		{
			try
			{
				db.CesidaUbicaciones.Attach(Objeto);
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
				CesidaUbicaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaUbicaciones.Remove(Objeto);
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

		public DbQuery<CesidaUbicacionesViewT> JsonT(string term)
		{
			var x = from c in db.CesidaUbicaciones
					select new CesidaUbicacionesViewT
					{
						 Id = c.Id,
						 NUMERO = c.NUMERO,
						 DESCRIPCION = c.DESCRIPCION,
					};
			return (DbQuery<CesidaUbicacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
