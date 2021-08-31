
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
	public partial class PreventivosPersonaAD
	{
		private BDEntities db = new BDEntities();

		public PreventivosPersona ObtenerPorId(int Id)
		{
			return db.PreventivosPersona.Single(c => c.Id == Id);
		}

		public DbQuery<PreventivosPersona> ObtenerTodo()
		{
			return (DbQuery<PreventivosPersona>)db.PreventivosPersona;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PreventivosPersona
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PreventivosPersonaView> ObtenerParaGrilla()
		{
			var x = from c in db.PreventivosPersona
					select new PreventivosPersonaView
					{
						 Id = c.Id,
						 Preventivo = c.Preventivo,
						 Persona = c.Persona,
						 Rol = c.Rol,
						 Demorado = c.Demorado,
					};
			return (DbQuery<PreventivosPersonaView>)x;
		}

		public void Guardar(PreventivosPersona Objeto)
		{
			try
			{
				db.PreventivosPersona.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PreventivosPersona Objeto)
		{
			try
			{
				db.PreventivosPersona.Attach(Objeto);
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
				PreventivosPersona Objeto = this.ObtenerPorId(IdObjeto);
				db.PreventivosPersona.Remove(Objeto);
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

		public DbQuery<PreventivosPersonaViewT> JsonT(string term)
		{
			var x = from c in db.PreventivosPersona
					select new PreventivosPersonaViewT
					{
						 Id = c.Id,
						 Preventivo = c.Preventivo,
						 Persona = c.Persona,
						 Rol = c.Rol,
						 Demorado = c.Demorado,
					};
			return (DbQuery<PreventivosPersonaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
