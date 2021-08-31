
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
	public partial class EjecucionesPresupuestariasReestructurasAD
	{
		private BDEntities db = new BDEntities();

		public EjecucionesPresupuestariasReestructuras ObtenerPorId(int Id)
		{
			return db.EjecucionesPresupuestariasReestructuras.Single(c => c.Id == Id);
		}

		public DbQuery<EjecucionesPresupuestariasReestructuras> ObtenerTodo()
		{
			return (DbQuery<EjecucionesPresupuestariasReestructuras>)db.EjecucionesPresupuestariasReestructuras;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EjecucionesPresupuestariasReestructuras
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EjecucionesPresupuestariasReestructurasView> ObtenerParaGrilla()
		{
            var x = from c in db.EjecucionesPresupuestariasReestructuras
                    join p in db.PartidasPresupuestarias on c.PartidaPresupuestaria equals p.Id
                    select new EjecucionesPresupuestariasReestructurasView
                    {
                        Id = c.Id,
                        Anio = c.Anio,
                        Partida = p.Mnemo,
                        Importe = c.Importe,
                        Fecha = c.Fecha,
                        Otorgado = c.ImporteOtorgado.HasValue ? c.ImporteOtorgado.Value : 0,
                        Tipo = c.Tipo.HasValue && c.Tipo.Value == 1 ? "Habilitación" :
                               c.Tipo.HasValue && c.Tipo.Value == 2 ? "Refuerzo" :
                               c.Tipo.HasValue && c.Tipo.Value == 3 ? "Compensación" :
                               c.Tipo.HasValue && c.Tipo.Value == 4 ? "Incorporación" : "-"
                    };                						 
			return (DbQuery<EjecucionesPresupuestariasReestructurasView>)x;
		}

		public void Guardar(EjecucionesPresupuestariasReestructuras Objeto)
		{
			try
			{
				db.EjecucionesPresupuestariasReestructuras.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EjecucionesPresupuestariasReestructuras Objeto)
		{
			try
			{
				db.EjecucionesPresupuestariasReestructuras.Attach(Objeto);
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
				EjecucionesPresupuestariasReestructuras Objeto = this.ObtenerPorId(IdObjeto);
				db.EjecucionesPresupuestariasReestructuras.Remove(Objeto);
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

		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
