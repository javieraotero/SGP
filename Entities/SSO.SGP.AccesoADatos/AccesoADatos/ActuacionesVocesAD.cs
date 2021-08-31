
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
	public partial class ActuacionesVocesAD
	{
		private BDEntities db = new BDEntities();

		public ActuacionesVoces ObtenerPorId(int Id)
		{
			return db.ActuacionesVoces.Single(c => c.Id == Id);
		}

		public DbQuery<ActuacionesVoces> ObtenerTodo()
		{
			return (DbQuery<ActuacionesVoces>)db.ActuacionesVoces.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActuacionesVoces
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActuacionesVocesView> ObtenerParaGrilla()
		{
			var x = from c in db.ActuacionesVoces
					where c.Activo == true
					select new ActuacionesVocesView
					{
						 Id = c.Id,
						 Actuacion = c.Actuacion,
						 Voz = c.Voz,
						 Activo = c.Activo,
						 Confirmado = c.Confirmado,
					};
			return (DbQuery<ActuacionesVocesView>)x;
		}

		public void Guardar(ActuacionesVoces Objeto)
		{
			try
			{
				db.ActuacionesVoces.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActuacionesVoces Objeto)
		{
			try
			{
				db.ActuacionesVoces.Attach(Objeto);
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
				ActuacionesVoces Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<ActuacionesVocesViewT> JsonT(string term)
		{
			var x = from c in db.ActuacionesVoces
					where c.Activo == true
					select new ActuacionesVocesViewT
					{
						 Id = c.Id,
						 Actuacion = c.Actuacion,
						 Voz = c.Voz,
						 Activo = c.Activo,
						 Confirmado = c.Confirmado,
					};
			return (DbQuery<ActuacionesVocesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
