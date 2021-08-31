
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
	public partial class PasosAD
	{
		private BDEntities db = new BDEntities();

		public Pasos ObtenerPorId(int Id)
		{
			return db.Pasos.Single(c => c.Id == Id);
		}

		public DbQuery<Pasos> ObtenerTodo()
		{
			return (DbQuery<Pasos>)db.Pasos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Pasos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PasosView> ObtenerParaGrilla()
		{
			var x = from c in db.Pasos
					select new PasosView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Fecha = c.Fecha,
						 Motivo = c.Motivo,
						 Usuario = c.Usuario,
					};
			return (DbQuery<PasosView>)x;
		}

		public void Guardar(Pasos Objeto)
		{
			try
			{
				db.Pasos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Pasos Objeto)
		{
			try
			{
				db.Pasos.Attach(Objeto);
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
				Pasos Objeto = this.ObtenerPorId(IdObjeto);
				db.Pasos.Remove(Objeto);
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

		public DbQuery<PasosViewT> JsonT(string term)
		{
			var x = from c in db.Pasos
					select new PasosViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Fecha = c.Fecha,
						 Motivo = c.Motivo,
						 Usuario = c.Usuario,
					};
			return (DbQuery<PasosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
