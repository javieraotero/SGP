
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
	public partial class LicenciasOrdinariasInicialesAD
	{
		private BDEntities db = new BDEntities();

		public LicenciasOrdinariasIniciales ObtenerPorId(int Id)
		{
			return db.LicenciasOrdinariasIniciales.Single(c => c.Id == Id);
		}

		public DbQuery<LicenciasOrdinariasIniciales> ObtenerTodo()
		{
			return (DbQuery<LicenciasOrdinariasIniciales>)db.LicenciasOrdinariasIniciales;
		}

        public DbQuery<LicenciasOrdinariasIniciales> ObtenerPorAgente(int agente)
        {
            var licencias = from x in db.LicenciasOrdinariasIniciales
                            where x.Agente == agente
                            && x.Saldo > 0
                            orderby x.Anio ascending
                            select x;

            return (DbQuery<LicenciasOrdinariasIniciales>)licencias;
        }

        public DbQuery<LicenciasOrdinariasIniciales> ObtenerTodoPorAgente(int agente)
        {
            return (DbQuery<LicenciasOrdinariasIniciales>)db.LicenciasOrdinariasIniciales.Where(a=>a.Agente == agente);
        }

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.LicenciasOrdinariasIniciales
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<LicenciasOrdinariasInicialesView> ObtenerParaGrilla()
		{
			var x = from c in db.LicenciasOrdinariasIniciales
					select new LicenciasOrdinariasInicialesView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 UsuarioAlta = c.UsuarioAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaAlta = c.FechaAlta,
						 FechaModifica = c.FechaModifica,
					};
			return (DbQuery<LicenciasOrdinariasInicialesView>)x;
		}

		public void Guardar(LicenciasOrdinariasIniciales Objeto)
		{
			try
			{
				db.LicenciasOrdinariasIniciales.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(LicenciasOrdinariasIniciales Objeto)
		{
			try
			{
				db.LicenciasOrdinariasIniciales.Attach(Objeto);
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
				LicenciasOrdinariasIniciales Objeto = this.ObtenerPorId(IdObjeto);
				db.LicenciasOrdinariasIniciales.Remove(Objeto);
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

		public DbQuery<LicenciasOrdinariasInicialesViewT> JsonT(string term)
		{
			var x = from c in db.LicenciasOrdinariasIniciales
					select new LicenciasOrdinariasInicialesViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 UsuarioAlta = c.UsuarioAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaAlta = c.FechaAlta,
						 FechaModifica = c.FechaModifica,
					};
			return (DbQuery<LicenciasOrdinariasInicialesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
