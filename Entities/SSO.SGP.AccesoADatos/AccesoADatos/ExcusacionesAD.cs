
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
	public partial class ExcusacionesAD
	{
		private BDEntities db = new BDEntities();

		public Excusaciones ObtenerPorId(int Id)
		{
			return db.Excusaciones.Single(c => c.Id == Id);
		}

		public DbQuery<Excusaciones> ObtenerTodo()
		{
			return (DbQuery<Excusaciones>)db.Excusaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Excusaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExcusacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.Excusaciones
					select new ExcusacionesView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Juzgado = c.Juzgado,
					};
			return (DbQuery<ExcusacionesView>)x;
		}

		public void Guardar(Excusaciones Objeto)
		{
			try
			{
				db.Excusaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Excusaciones Objeto)
		{
			try
			{
				db.Excusaciones.Attach(Objeto);
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
				Excusaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.Excusaciones.Remove(Objeto);
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

		public DbQuery<ExcusacionesViewT> JsonT(string term)
		{
			var x = from c in db.Excusaciones
					select new ExcusacionesViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Juzgado = c.Juzgado,
					};
			return (DbQuery<ExcusacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
