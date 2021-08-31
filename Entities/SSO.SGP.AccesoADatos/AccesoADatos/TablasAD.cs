
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
	public partial class TablasAD
	{
		private BDEntities db = new BDEntities();

		public Tablas ObtenerPorId(int Id)
		{
			return db.Tablas.Single(c => c.Id == Id);
		}

		public DbQuery<Tablas> ObtenerTodo()
		{
			return (DbQuery<Tablas>)db.Tablas;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Tablas
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TablasView> ObtenerParaGrilla()
		{
			var x = from c in db.Tablas
					select new TablasView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Descripcion = c.Descripcion,
						 DelSistema = c.DelSistema,
						 SoloLectura = c.SoloLectura,
						 Clase = c.Clase,
						 HabilitarEliminacion = c.HabilitarEliminacion,
						 Orden = c.Orden,
						 AdministrarPorGenerico = c.AdministrarPorGenerico,
					};
			return (DbQuery<TablasView>)x;
		}

		public void Guardar(Tablas Objeto)
		{
			try
			{
				db.Tablas.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Tablas Objeto)
		{
			try
			{
				db.Tablas.Attach(Objeto);
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
				Tablas Objeto = this.ObtenerPorId(IdObjeto);
				db.Tablas.Remove(Objeto);
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

		public DbQuery<TablasViewT> JsonT(string term)
		{
			var x = from c in db.Tablas
					select new TablasViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Descripcion = c.Descripcion,
						 DelSistema = c.DelSistema,
						 SoloLectura = c.SoloLectura,
						 Clase = c.Clase,
						 HabilitarEliminacion = c.HabilitarEliminacion,
						 Orden = c.Orden,
						 AdministrarPorGenerico = c.AdministrarPorGenerico,
					};
			return (DbQuery<TablasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
