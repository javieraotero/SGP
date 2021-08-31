
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
	public partial class PersonasCaracteristicasRefAD
	{
		private BDEntities db = new BDEntities();

		public PersonasCaracteristicasRef ObtenerPorId(int Id)
		{
			return db.PersonasCaracteristicasRef.Single(c => c.Id == Id);
		}

		public DbQuery<PersonasCaracteristicasRef> ObtenerTodo()
		{
			return (DbQuery<PersonasCaracteristicasRef>)db.PersonasCaracteristicasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PersonasCaracteristicasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PersonasCaracteristicasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.PersonasCaracteristicasRef
					select new PersonasCaracteristicasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Tipo = c.Tipo,
					};
			return (DbQuery<PersonasCaracteristicasRefView>)x;
		}

		public void Guardar(PersonasCaracteristicasRef Objeto)
		{
			try
			{
				db.PersonasCaracteristicasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PersonasCaracteristicasRef Objeto)
		{
			try
			{
				db.PersonasCaracteristicasRef.Attach(Objeto);
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
				PersonasCaracteristicasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.PersonasCaracteristicasRef.Remove(Objeto);
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

		public DbQuery<PersonasCaracteristicasRefViewT> JsonT(string term)
		{
			var x = from c in db.PersonasCaracteristicasRef
					select new PersonasCaracteristicasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Tipo = c.Tipo,
					};
			return (DbQuery<PersonasCaracteristicasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
