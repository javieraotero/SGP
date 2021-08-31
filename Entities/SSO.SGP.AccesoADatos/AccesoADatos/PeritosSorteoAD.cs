
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
	public partial class PeritosSorteoAD
	{
		private BDEntities db = new BDEntities();

		public PeritosSorteo ObtenerPorId(int Id)
		{
			return db.PeritosSorteo.Single(c => c.Id == Id);
		}

		public DbQuery<PeritosSorteo> ObtenerTodo()
		{
			return (DbQuery<PeritosSorteo>)db.PeritosSorteo;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PeritosSorteo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosSorteoView> ObtenerParaGrilla()
		{
			var x = from c in db.PeritosSorteo
					select new PeritosSorteoView
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Organismo = c.Organismo,
						 Caratula = c.Caratula,
						 Oficio = c.Oficio,
						 NroExpediente = c.NroExpediente,
						 Fecha = c.Fecha,
						 UsuarioSorteo = c.UsuarioSorteo,
					};
			return (DbQuery<PeritosSorteoView>)x;
		}

		public void Guardar(PeritosSorteo Objeto)
		{
			try
			{
				db.PeritosSorteo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PeritosSorteo Objeto)
		{
			try
			{
				db.PeritosSorteo.Attach(Objeto);
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
				PeritosSorteo Objeto = this.ObtenerPorId(IdObjeto);
				db.PeritosSorteo.Remove(Objeto);
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

		public DbQuery<PeritosSorteoViewT> JsonT(string term)
		{
			var x = from c in db.PeritosSorteo
					select new PeritosSorteoViewT
					{
						 Id = c.Id,
						 Inscripcion = c.Inscripcion,
						 Organismo = c.Organismo,
						 Caratula = c.Caratula,
						 Oficio = c.Oficio,
						 NroExpediente = c.NroExpediente,
						 Fecha = c.Fecha,
						 UsuarioSorteo = c.UsuarioSorteo,
					};
			return (DbQuery<PeritosSorteoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
