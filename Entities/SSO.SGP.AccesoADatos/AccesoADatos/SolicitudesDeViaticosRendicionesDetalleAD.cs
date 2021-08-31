
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
	public partial class SolicitudesDeViaticosRendicionesDetalleAD
	{
		private BDEntities db = new BDEntities();

		public SolicitudesDeViaticosRendicionesDetalle ObtenerPorId(int Id)
		{
			return db.SolicitudesDeViaticosRendicionesDetalle.Single(c => c.Id == Id);
		}

        public DbQuery<SolicitudesDeViaticosRendicionesDetalle> ObtenerPorRendicion(int rendicion)
        {
            var res = from r in db.SolicitudesDeViaticosRendicionesAgentes
                      join d in db.SolicitudesDeViaticosRendicionesDetalle on r.Id equals d.RendicionAgente
                      select d;

            return (DbQuery<SolicitudesDeViaticosRendicionesDetalle>)res;
        }

        public DbQuery<SolicitudesDeViaticosRendicionesDetalle> ObtenerTodo()
		{
			return (DbQuery<SolicitudesDeViaticosRendicionesDetalle>)db.SolicitudesDeViaticosRendicionesDetalle;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SolicitudesDeViaticosRendicionesDetalle
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<SolicitudesDeViaticosRendicionesDetalle> ObtenerDetalle(int rendicion)
        {
            var res = from r in db.SolicitudesDeViaticosRendicionesAgentes
                      join d in db.SolicitudesDeViaticosRendicionesDetalle on r.Id equals d.RendicionAgente
                      where r.Rendicion == rendicion
                      select d;
                      
            return (DbQuery<SolicitudesDeViaticosRendicionesDetalle>)res;
        }

        public DbQuery<SolicitudesDeViaticosRendicionesDetalleView> ObtenerParaGrilla()
		{
			var x = from c in db.SolicitudesDeViaticosRendicionesDetalle
					select new SolicitudesDeViaticosRendicionesDetalleView
					{
						 Id = c.Id,
						 RendicionAgente = c.RendicionAgente,
						 Descripcion = c.Descripcion,
						 Importe = c.Importe,
						 Concepto = c.Concepto,
					};
			return (DbQuery<SolicitudesDeViaticosRendicionesDetalleView>)x;
		}

		public void Guardar(SolicitudesDeViaticosRendicionesDetalle Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosRendicionesDetalle.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SolicitudesDeViaticosRendicionesDetalle Objeto)
		{
			try
			{
				db.SolicitudesDeViaticosRendicionesDetalle.Attach(Objeto);
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
				SolicitudesDeViaticosRendicionesDetalle Objeto = this.ObtenerPorId(IdObjeto);
				db.SolicitudesDeViaticosRendicionesDetalle.Remove(Objeto);
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

		public DbQuery<SolicitudesDeViaticosRendicionesDetalleViewT> JsonT(string term)
		{
			var x = from c in db.SolicitudesDeViaticosRendicionesDetalle
					select new SolicitudesDeViaticosRendicionesDetalleViewT
					{
						 Id = c.Id,
						 RendicionAgente = c.RendicionAgente,
						 Descripcion = c.Descripcion,
						 Importe = c.Importe,
						 Concepto = c.Concepto,
					};
			return (DbQuery<SolicitudesDeViaticosRendicionesDetalleViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
