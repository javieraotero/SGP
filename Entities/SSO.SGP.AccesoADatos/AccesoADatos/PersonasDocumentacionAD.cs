
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
	public partial class PersonasDocumentacionAD
	{
		private BDEntities db = new BDEntities();

		public PersonasDocumentacion ObtenerPorId(int Id)
		{
			return db.PersonasDocumentacion.Single(c => c.Id == Id);
		}

		public DbQuery<PersonasDocumentacion> ObtenerTodo()
		{
			return (DbQuery<PersonasDocumentacion>)db.PersonasDocumentacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PersonasDocumentacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PersonasDocumentacionView> ObtenerParaGrilla()
		{
			var x = from c in db.PersonasDocumentacion
					select new PersonasDocumentacionView
					{
						 Id = c.Id,
						 Persona = c.Persona,
						 TipoDocumentacion = c.TipoDocumentacion,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<PersonasDocumentacionView>)x;
		}

		public void Guardar(PersonasDocumentacion Objeto)
		{
			try
			{
				db.PersonasDocumentacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasDocumentacion Objeto)
		{
			try
			{
				db.PersonasDocumentacion.Attach(Objeto);
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
				PersonasDocumentacion Objeto = this.ObtenerPorId(IdObjeto);
				db.PersonasDocumentacion.Remove(Objeto);
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

		public DbQuery<PersonasDocumentacionViewT> JsonT(string term)
		{
			var x = from c in db.PersonasDocumentacion
					select new PersonasDocumentacionViewT
					{
						 Id = c.Id,
						 Persona = c.Persona,
						 TipoDocumentacion = c.TipoDocumentacion,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<PersonasDocumentacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
