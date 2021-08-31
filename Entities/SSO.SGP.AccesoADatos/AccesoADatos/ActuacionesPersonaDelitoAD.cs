
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
	public partial class ActuacionesPersonaDelitoAD
	{
		private BDEntities db = new BDEntities();

		public ActuacionesPersonaDelito ObtenerPorId(int Id)
		{
			return db.ActuacionesPersonaDelito.Single(c => c.Id == Id);
		}

		public DbQuery<ActuacionesPersonaDelito> ObtenerTodo()
		{
			return (DbQuery<ActuacionesPersonaDelito>)db.ActuacionesPersonaDelito;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActuacionesPersonaDelito
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesPersonaDelitoView> ObtenerParaGrilla()
		{
			var x = from c in db.ActuacionesPersonaDelito
					select new ActuacionesPersonaDelitoView
					{
						 Id = c.Id,
						 Actuacion = c.Actuacion,
						 Persona = c.Persona,
						 Delito = c.Delito,
						 Automatico = c.Automatico,
					};
			return (DbQuery<ActuacionesPersonaDelitoView>)x;
		}

		public void Guardar(ActuacionesPersonaDelito Objeto)
		{
			try
			{
				db.ActuacionesPersonaDelito.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesPersonaDelito Objeto)
		{
			try
			{
				db.ActuacionesPersonaDelito.Attach(Objeto);
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
				ActuacionesPersonaDelito Objeto = this.ObtenerPorId(IdObjeto);
				db.ActuacionesPersonaDelito.Remove(Objeto);
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

		public DbQuery<ActuacionesPersonaDelitoViewT> JsonT(string term)
		{
			var x = from c in db.ActuacionesPersonaDelito
					select new ActuacionesPersonaDelitoViewT
					{
						 Id = c.Id,
						 Actuacion = c.Actuacion,
						 Persona = c.Persona,
						 Delito = c.Delito,
						 Automatico = c.Automatico,
					};
			return (DbQuery<ActuacionesPersonaDelitoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
