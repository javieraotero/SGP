
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
	public partial class SolicitudesDeViaticosRendicionesAD
	{
		private BDEntities db = new BDEntities();

		public SolicitudesDeViaticosRendiciones ObtenerPorId(int Id)
		{
			return db.SolicitudesDeViaticosRendiciones.Single(c => c.Id == Id);
		}

        public SolicitudesDeViaticosRendiciones ObtenerPorSolicitud(int Id)
        {
            var r = db.SolicitudesDeViaticosRendiciones.Where(x=>x.SolicitudDeViatico == Id);
            if (r.Count() > 0)
                return r.FirstOrDefault();
            else
                return new SolicitudesDeViaticosRendiciones();

        }

        public DbQuery<SolicitudesDeViaticosRendiciones> ObtenerTodo()
		{
			return (DbQuery<SolicitudesDeViaticosRendiciones>)db.SolicitudesDeViaticosRendiciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SolicitudesDeViaticosRendiciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SolicitudesDeViaticosRendicionesView> ObtenerParaGrilla()
		{
			var x = from c in db.SolicitudesDeViaticosRendiciones
					select new SolicitudesDeViaticosRendicionesView
					{
						 Id = c.Id,
						 SolicitudDeViatico = c.SolicitudDeViatico,
						 FechaDeInicio = c.FechaDeInicio,
						 FechaDeFin = c.FechaDeFin,
						 TotalBienesDeConsumo = c.TotalBienesDeConsumo,
						 TotalServiciosNoPersonales = c.TotalServiciosNoPersonales,
						 TotalOtros = c.TotalOtros,
						 FechaDeAlta = c.FechaDeAlta,
						 UsuarioAlta = c.UsuarioAlta,
					};
			return (DbQuery<SolicitudesDeViaticosRendicionesView>)x;
		}

		public void Guardar(SolicitudesDeViaticosRendiciones Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosRendiciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SolicitudesDeViaticosRendiciones Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosRendiciones.Attach(Objeto);
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
				SolicitudesDeViaticosRendiciones Objeto = this.ObtenerPorId(IdObjeto);
				db.SolicitudesDeViaticosRendiciones.Remove(Objeto);
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

		//public DbQuery<SolicitudesDeViaticosRendicionesViewT> JsonT(string term)
		//{
		//	var x = from c in db.SolicitudesDeViaticosRendiciones
		//			select new SolicitudesDeViaticosRendicionesViewT
		//			{
		//				 Id = c.Id,
		//				 SolicitudDeViatico = c.SolicitudDeViatico,
		//				 FechaDeInicio = c.FechaDeInicio,
		//				 FechaDeFin = c.FechaDeFin,
		//				 TotalBienesDeConsumo = c.TotalBienesDeConsumo,
		//				 TotalServiciosNoPersonales = c.TotalServiciosNoPersonales,
		//				 TotalOtros = c.TotalOtros,
		//				 FechaDeAlta = c.FechaDeAlta,
		//				 UsuarioAlta = c.UsuarioAlta,
		//			};
		//	return (DbQuery<SolicitudesDeViaticosRendicionesViewT>)x;
		//}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
