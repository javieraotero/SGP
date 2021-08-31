
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
	public partial class ConcursosAD
	{
		private BDEntities db = new BDEntities();

		public Concursos ObtenerPorId(int Id)
		{
			return db.Concursos.Single(c => c.Id == Id);
		}

		public DbQuery<Concursos> ObtenerTodo()
		{
			return (DbQuery<Concursos>)db.Concursos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Concursos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ConcursosView> ObtenerParaGrilla()
		{
			var x = from c in db.Concursos
					select new ConcursosView
					{
						 Id = c.Id,
						 Actividad = c.Actividad,
						 RazonSocial = c.RazonSocial,
						 DomicilioComercial = c.DomicilioComercial,
						 MatriculaRazonSocial = c.MatriculaRazonSocial,
						 FolioRazonSocial = c.FolioRazonSocial,
						 TomoRazonSocial = c.TomoRazonSocial,
						 AnioRazonSocial = c.AnioRazonSocial,
						 MatriculaComerciante = c.MatriculaComerciante,
						 FolioComerciante = c.FolioComerciante,
						 TomoComerciante = c.TomoComerciante,
						 AnioComerciante = c.AnioComerciante,
					};
			return (DbQuery<ConcursosView>)x;
		}

		public void Guardar(Concursos Objeto)
		{
			try
			{
				db.Concursos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Concursos Objeto)
		{
			try
			{
				db.Concursos.Attach(Objeto);
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
				Concursos Objeto = this.ObtenerPorId(IdObjeto);
				db.Concursos.Remove(Objeto);
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

		public DbQuery<ConcursosViewT> JsonT(string term)
		{
			var x = from c in db.Concursos
					select new ConcursosViewT
					{
						 Id = c.Id,
						 Actividad = c.Actividad,
						 RazonSocial = c.RazonSocial,
						 DomicilioComercial = c.DomicilioComercial,
						 MatriculaRazonSocial = c.MatriculaRazonSocial,
						 FolioRazonSocial = c.FolioRazonSocial,
						 TomoRazonSocial = c.TomoRazonSocial,
						 AnioRazonSocial = c.AnioRazonSocial,
						 MatriculaComerciante = c.MatriculaComerciante,
						 FolioComerciante = c.FolioComerciante,
						 TomoComerciante = c.TomoComerciante,
						 AnioComerciante = c.AnioComerciante,
					};
			return (DbQuery<ConcursosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
