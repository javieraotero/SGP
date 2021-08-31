
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
	public partial class CoMediadoresEspecialidadAD
	{
		private BDEntities db = new BDEntities();

		public CoMediadoresEspecialidad ObtenerPorId(int Id)
		{
			return db.CoMediadoresEspecialidad.Single(c => c.Id == Id);
		}

		public DbQuery<CoMediadoresEspecialidad> ObtenerTodo()
		{
			return (DbQuery<CoMediadoresEspecialidad>)db.CoMediadoresEspecialidad;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CoMediadoresEspecialidad
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CoMediadoresEspecialidadView> ObtenerParaGrilla()
		{
			var x = from c in db.CoMediadoresEspecialidad
					select new CoMediadoresEspecialidadView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CoMediadoresEspecialidadView>)x;
		}

		public void Guardar(CoMediadoresEspecialidad Objeto)
		{
			try
			{
				db.CoMediadoresEspecialidad.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CoMediadoresEspecialidad Objeto)
		{
			try
			{
				db.CoMediadoresEspecialidad.Attach(Objeto);
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
				CoMediadoresEspecialidad Objeto = this.ObtenerPorId(IdObjeto);
				db.CoMediadoresEspecialidad.Remove(Objeto);
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

		public DbQuery<CoMediadoresEspecialidadViewT> JsonT(string term)
		{
			var x = from c in db.CoMediadoresEspecialidad
					select new CoMediadoresEspecialidadViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CoMediadoresEspecialidadViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
