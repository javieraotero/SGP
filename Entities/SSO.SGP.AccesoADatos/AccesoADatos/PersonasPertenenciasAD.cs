
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
	public partial class PersonasPertenenciasAD
	{
		private BDEntities db = new BDEntities();

		public PersonasPertenencias ObtenerPorId(int Id)
		{
			return db.PersonasPertenencias.Single(c => c.Id == Id);
		}

		public DbQuery<PersonasPertenencias> ObtenerTodo()
		{
			return (DbQuery<PersonasPertenencias>)db.PersonasPertenencias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PersonasPertenencias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PersonasPertenenciasView> ObtenerParaGrilla()
		{
			var x = from c in db.PersonasPertenencias
					select new PersonasPertenenciasView
					{
						 Id = c.Id,
						 Persona1 = c.Persona1,
						 Persona2 = c.Persona2,
					};
			return (DbQuery<PersonasPertenenciasView>)x;
		}

		public void Guardar(PersonasPertenencias Objeto)
		{
			try
			{
				db.PersonasPertenencias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasPertenencias Objeto)
		{
			try
			{
				db.PersonasPertenencias.Attach(Objeto);
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
				PersonasPertenencias Objeto = this.ObtenerPorId(IdObjeto);
				db.PersonasPertenencias.Remove(Objeto);
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

		public DbQuery<PersonasPertenenciasViewT> JsonT(string term)
		{
			var x = from c in db.PersonasPertenencias
					select new PersonasPertenenciasViewT
					{
						 Id = c.Id,
						 Persona1 = c.Persona1,
						 Persona2 = c.Persona2,
					};
			return (DbQuery<PersonasPertenenciasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
