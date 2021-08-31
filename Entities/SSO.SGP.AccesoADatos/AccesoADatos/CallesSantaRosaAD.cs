
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Data.Objects.SqlClient;
using SSO.SGP.EntidadesDeNegocio;
using SSO.SGP.EntidadesDeNegocio.Vistas;


namespace SSO.SGP.AccesoADatos
{
	/// <summary>
	/// Acceso a Datos Generada por el Generador de codigo.
	/// </summary>
	public partial class CallesSantaRosaAD
	{
		private BDEntities db = new BDEntities();

		public CallesSantaRosa ObtenerPorId(int Id)
		{
			return db.CallesSantaRosa.Single(c => c.Id == Id);
		}

		public DbQuery<CallesSantaRosa> ObtenerTodo()
		{
			return (DbQuery<CallesSantaRosa>)db.CallesSantaRosa;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CallesSantaRosa
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CallesSantaRosaView> ObtenerParaGrilla()
		{
			var x = from c in db.CallesSantaRosa
					select new CallesSantaRosaView
					{
						 Columna 0 = c.Columna 0,
						 Columna 1 = c.Columna 1,
						 Columna 2 = c.Columna 2,
						 Columna 3 = c.Columna 3,
						 Columna 4 = c.Columna 4,
						 Columna 5 = c.Columna 5,
						 Columna 6 = c.Columna 6,
						 Columna 7 = c.Columna 7,
						 Columna 8 = c.Columna 8,
					};
			return (DbQuery<CallesSantaRosaView>)x;
		}

		public void Guardar(CallesSantaRosa Objeto)
		{
			try
			{
				db.CallesSantaRosa.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CallesSantaRosa Objeto)
		{
			try
			{
				db.CallesSantaRosa.Attach(Objeto);
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
				CallesSantaRosa Objeto = this.ObtenerPorId(IdObjeto);
				db.CallesSantaRosa.Remove(Objeto);
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

		public DbQuery<CallesSantaRosaViewT> JsonT(string term)
		{
			var x = from c in db.CallesSantaRosa
					select new CallesSantaRosaViewT
					{
						 Columna 0 = c.Columna 0,
						 Columna 1 = c.Columna 1,
						 Columna 2 = c.Columna 2,
						 Columna 3 = c.Columna 3,
						 Columna 4 = c.Columna 4,
						 Columna 5 = c.Columna 5,
						 Columna 6 = c.Columna 6,
						 Columna 7 = c.Columna 7,
						 Columna 8 = c.Columna 8,
					};
			return (DbQuery<CallesSantaRosaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
