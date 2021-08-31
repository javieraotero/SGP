
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
	public partial class EstadosUsuarioRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosUsuarioRef ObtenerPorId(int Id)
		{
			return db.EstadosUsuarioRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosUsuarioRef> ObtenerTodo()
		{
			return (DbQuery<EstadosUsuarioRef>)db.EstadosUsuarioRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosUsuarioRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosUsuarioRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosUsuarioRef
					select new EstadosUsuarioRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosUsuarioRefView>)x;
		}

		public void Guardar(EstadosUsuarioRef Objeto)
		{
			try
			{
				db.EstadosUsuarioRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosUsuarioRef Objeto)
		{
			try
			{
				db.EstadosUsuarioRef.Attach(Objeto);
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
				EstadosUsuarioRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosUsuarioRef.Remove(Objeto);
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

		public DbQuery<EstadosUsuarioRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosUsuarioRef
					select new EstadosUsuarioRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosUsuarioRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
