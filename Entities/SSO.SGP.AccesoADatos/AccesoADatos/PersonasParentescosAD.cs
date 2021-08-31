
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
	public partial class PersonasParentescosAD
	{
		private BDEntities db = new BDEntities();

		public PersonasParentescos ObtenerPorId(int Id)
		{
			return db.PersonasParentescos.Single(c => c.Id == Id);
		}

		public DbQuery<PersonasParentescos> ObtenerTodo()
		{
			return (DbQuery<PersonasParentescos>)db.PersonasParentescos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PersonasParentescos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PersonasParentescosView> ObtenerParaGrilla()
		{
			var x = from c in db.PersonasParentescos
					select new PersonasParentescosView
					{
						 Id = c.Id,
						 Persona1 = c.Persona1,
						 Persona2 = c.Persona2,
						 TipoParentesco = c.TipoParentesco,
					};
			return (DbQuery<PersonasParentescosView>)x;
		}

		public void Guardar(PersonasParentescos Objeto)
		{
			try
			{
				db.PersonasParentescos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasParentescos Objeto)
		{
			try
			{
				db.PersonasParentescos.Attach(Objeto);
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
				PersonasParentescos Objeto = this.ObtenerPorId(IdObjeto);
				db.PersonasParentescos.Remove(Objeto);
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

		public DbQuery<PersonasParentescosViewT> JsonT(string term)
		{
			var x = from c in db.PersonasParentescos
					select new PersonasParentescosViewT
					{
						 Id = c.Id,
						 Persona1 = c.Persona1,
						 Persona2 = c.Persona2,
						 TipoParentesco = c.TipoParentesco,
					};
			return (DbQuery<PersonasParentescosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
