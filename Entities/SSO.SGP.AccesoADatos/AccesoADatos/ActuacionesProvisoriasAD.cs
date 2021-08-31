
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
	public partial class ActuacionesProvisoriasAD
	{
		private BDEntities db = new BDEntities();

		public ActuacionesProvisorias ObtenerPorId(int Id)
		{
			return db.ActuacionesProvisorias.Single(c => c.Id == Id);
		}

		public DbQuery<ActuacionesProvisorias> ObtenerTodo()
		{
			return (DbQuery<ActuacionesProvisorias>)db.ActuacionesProvisorias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActuacionesProvisorias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesProvisoriasView> ObtenerParaGrilla()
		{
			var x = from c in db.ActuacionesProvisorias
					select new ActuacionesProvisoriasView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Actuacion = c.Actuacion,
						 Fundamento = c.Fundamento,
						 Usuario = c.Usuario,
					};
			return (DbQuery<ActuacionesProvisoriasView>)x;
		}

		public void Guardar(ActuacionesProvisorias Objeto)
		{
			try
			{
				db.ActuacionesProvisorias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesProvisorias Objeto)
		{
			try
			{
				db.ActuacionesProvisorias.Attach(Objeto);
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
				ActuacionesProvisorias Objeto = this.ObtenerPorId(IdObjeto);
				db.ActuacionesProvisorias.Remove(Objeto);
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

		public DbQuery<ActuacionesProvisoriasViewT> JsonT(string term)
		{
			var x = from c in db.ActuacionesProvisorias
					select new ActuacionesProvisoriasViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Actuacion = c.Actuacion,
						 Fundamento = c.Fundamento,
						 Usuario = c.Usuario,
					};
			return (DbQuery<ActuacionesProvisoriasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
