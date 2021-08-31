
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
	public partial class GruposUsuarioRefAD
	{
		private BDEntities db = new BDEntities();

		public GruposUsuarioRef ObtenerPorId(int Id)
		{
			return db.GruposUsuarioRef.Single(c => c.Id == Id);
		}

		public DbQuery<GruposUsuarioRef> ObtenerTodo()
		{
			return (DbQuery<GruposUsuarioRef>)db.GruposUsuarioRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GruposUsuarioRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GruposUsuarioRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GruposUsuarioRef
					select new GruposUsuarioRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EsPolicia = c.EsPolicia,
					};
			return (DbQuery<GruposUsuarioRefView>)x;
		}

		public void Guardar(GruposUsuarioRef Objeto)
		{
			try
			{
				db.GruposUsuarioRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposUsuarioRef Objeto)
		{
			try
			{
				db.GruposUsuarioRef.Attach(Objeto);
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
				GruposUsuarioRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GruposUsuarioRef.Remove(Objeto);
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

		public DbQuery<GruposUsuarioRefViewT> JsonT(string term)
		{
			var x = from c in db.GruposUsuarioRef
					select new GruposUsuarioRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EsPolicia = c.EsPolicia,
					};
			return (DbQuery<GruposUsuarioRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
