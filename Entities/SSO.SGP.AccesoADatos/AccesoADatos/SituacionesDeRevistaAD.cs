
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
	public partial class SituacionesDeRevistaAD
	{
		private BDEntities db = new BDEntities();

		public SituacionesDeRevista ObtenerPorId(int Id)
		{
			return db.SituacionesDeRevista.Single(c => c.Id == Id);
		}

		public DbQuery<SituacionesDeRevista> ObtenerTodo()
		{
			return (DbQuery<SituacionesDeRevista>)db.SituacionesDeRevista;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SituacionesDeRevista
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SituacionesDeRevistaView> ObtenerParaGrilla()
		{
			var x = from c in db.SituacionesDeRevista
					select new SituacionesDeRevistaView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
					};
			return (DbQuery<SituacionesDeRevistaView>)x;
		}

		public void Guardar(SituacionesDeRevista Objeto)
		{
			try
			{
				db.SituacionesDeRevista.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SituacionesDeRevista Objeto)
		{
			try
			{
				db.SituacionesDeRevista.Attach(Objeto);
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
				SituacionesDeRevista Objeto = this.ObtenerPorId(IdObjeto);
				db.SituacionesDeRevista.Remove(Objeto);
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

		public DbQuery<SituacionesDeRevistaViewT> JsonT(string term)
		{
			var x = from c in db.SituacionesDeRevista
					select new SituacionesDeRevistaViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Abreviatura = c.Abreviatura,
					};
			return (DbQuery<SituacionesDeRevistaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
