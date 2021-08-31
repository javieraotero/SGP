
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
	public partial class PermisosAD
	{
		private BDEntities db = new BDEntities();

		public Permisos ObtenerPorId(int Id)
		{
			return db.Permisos.Single(c => c.Id == Id);
		}

		public DbQuery<Permisos> ObtenerTodo()
		{
			return (DbQuery<Permisos>)db.Permisos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Permisos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PermisosView> ObtenerParaGrilla()
		{
			var x = from c in db.Permisos
					select new PermisosView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Formulario = c.Formulario,
						 Accion = c.Accion,
					};
			return (DbQuery<PermisosView>)x;
		}

		public void Guardar(Permisos Objeto)
		{
			try
			{
				db.Permisos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Permisos Objeto)
		{
			try
			{
				db.Permisos.Attach(Objeto);
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
				Permisos Objeto = this.ObtenerPorId(IdObjeto);
				db.Permisos.Remove(Objeto);
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

		public DbQuery<PermisosViewT> JsonT(string term)
		{
			var x = from c in db.Permisos
					select new PermisosViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Formulario = c.Formulario,
						 Accion = c.Accion,
					};
			return (DbQuery<PermisosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
