
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
	public partial class FormulariosAD
	{
		private BDEntities db = new BDEntities();

		public Formularios ObtenerPorId(int Id)
		{
			return db.Formularios.Single(c => c.Id == Id);
		}

		public DbQuery<Formularios> ObtenerTodo()
		{
			return (DbQuery<Formularios>)db.Formularios;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Formularios
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<FormulariosView> ObtenerParaGrilla()
		{
			var x = from c in db.Formularios
					select new FormulariosView
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Descripcion = c.Descripcion,
						 Url = c.Url,
					};
			return (DbQuery<FormulariosView>)x;
		}

		public void Guardar(Formularios Objeto)
		{
			try
			{
				db.Formularios.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Formularios Objeto)
		{
			try
			{
				db.Formularios.Attach(Objeto);
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
				Formularios Objeto = this.ObtenerPorId(IdObjeto);
				db.Formularios.Remove(Objeto);
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

		public DbQuery<FormulariosViewT> JsonT(string term)
		{
			var x = from c in db.Formularios
					select new FormulariosViewT
					{
						 Id = c.Id,
						 Nombre = c.Nombre,
						 Descripcion = c.Descripcion,
						 Url = c.Url,
					};
			return (DbQuery<FormulariosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
