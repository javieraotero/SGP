
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
	public partial class SucesosReceptoriaAD
	{
		private BDEntities db = new BDEntities();

		public SucesosReceptoria ObtenerPorId(int Id)
		{
			return db.SucesosReceptoria.Single(c => c.Id == Id);
		}

		public DbQuery<SucesosReceptoria> ObtenerTodo()
		{
			return (DbQuery<SucesosReceptoria>)db.SucesosReceptoria;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SucesosReceptoria
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SucesosReceptoriaView> ObtenerParaGrilla()
		{
			var x = from c in db.SucesosReceptoria
					select new SucesosReceptoriaView
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Tipo = c.Tipo,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
					};
			return (DbQuery<SucesosReceptoriaView>)x;
		}

		public void Guardar(SucesosReceptoria Objeto)
		{
			try
			{
				db.SucesosReceptoria.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SucesosReceptoria Objeto)
		{
			try
			{
				db.SucesosReceptoria.Attach(Objeto);
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
				SucesosReceptoria Objeto = this.ObtenerPorId(IdObjeto);
				db.SucesosReceptoria.Remove(Objeto);
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

		public DbQuery<SucesosReceptoriaViewT> JsonT(string term)
		{
			var x = from c in db.SucesosReceptoria
					select new SucesosReceptoriaViewT
					{
						 Id = c.Id,
						 Fecha = c.Fecha,
						 Tipo = c.Tipo,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
					};
			return (DbQuery<SucesosReceptoriaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
