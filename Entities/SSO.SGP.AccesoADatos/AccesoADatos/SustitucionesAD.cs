
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
	public partial class SustitucionesAD
	{
		private BDEntities db = new BDEntities();

		public Sustituciones ObtenerPorId(int Id)
		{
            //Sustituciones s = db.Sustituciones.Include("Agentes").Where(p => p.Id == Id).FirstOrDefault();
			//return db.Sustituciones.Single(c => c.Id == Id);
            Sustituciones s = (from x in db.Sustituciones
                               where x.Id == Id
                               select x).First();


            return s;
		}

		public DbQuery<Sustituciones> ObtenerTodo()
		{
			return (DbQuery<Sustituciones>)db.Sustituciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Sustituciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SustitucionesView> ObtenerParaGrilla()
		{
			var x = from c in db.Sustituciones
                    where c.FechaElimina == null
					select new SustitucionesView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Acuerdo = c.Acuerdo,
						 Desde = c.Desde,
						 Hasta = c.Hasta,
						 Motivo = c.Motivo,
						 Cargo = c.Cargo,
						 Organismo = c.Organismo,
					};
			return (DbQuery<SustitucionesView>)x;
		}

		public void Guardar(Sustituciones Objeto)
		{
			try
			{
				db.Sustituciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Sustituciones Objeto)
		{
			try
			{
				db.Sustituciones.Attach(Objeto);
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
				Sustituciones Objeto = this.ObtenerPorId(IdObjeto);
                Objeto.FechaElimina = DateTime.Now;
                db.Entry(Objeto).State = EntityState.Modified;
                //db.Sustituciones.Remove(Objeto);
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

		public DbQuery<SustitucionesViewT> JsonT(int agente, bool activos)
		{
			var x = from c in db.Sustituciones
                    where c.Agente == agente && c.FechaElimina.HasValue == !activos
					select new SustitucionesViewT
					{
						 Id = c.Id,
	    				 Acuerdo = c.Acuerdo,
						 FechaDesde = c.Desde,
						 FechaHasta = c.Hasta,
						 Cargo = c.Cargos.Descripcion,
						 Organismo = c.Organismoss.Descripcion
					};
			return (DbQuery<SustitucionesViewT>)x;
		}

	}
}
