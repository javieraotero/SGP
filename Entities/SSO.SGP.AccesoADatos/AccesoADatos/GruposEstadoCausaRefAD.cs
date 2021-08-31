
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
	public partial class GruposEstadoCausaRefAD
	{
		private BDEntities db = new BDEntities();

		public GruposEstadoCausaRef ObtenerPorId(int Id)
		{
			return db.GruposEstadoCausaRef.Single(c => c.ID == Id);
		}

		public DbQuery<GruposEstadoCausaRef> ObtenerTodo()
		{
			return (DbQuery<GruposEstadoCausaRef>)db.GruposEstadoCausaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GruposEstadoCausaRef
                      select new SelectOptionsView { text = SqlFunctions.StringConvert((double)x.ID), value = x.ID };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GruposEstadoCausaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GruposEstadoCausaRef
					select new GruposEstadoCausaRefView
					{
						 ID = c.ID,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<GruposEstadoCausaRefView>)x;
		}

		public void Guardar(GruposEstadoCausaRef Objeto)
		{
			try
			{
				db.GruposEstadoCausaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GruposEstadoCausaRef Objeto)
		{
			try
			{
				db.GruposEstadoCausaRef.Attach(Objeto);
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
				GruposEstadoCausaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GruposEstadoCausaRef.Remove(Objeto);
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

		public DbQuery<GruposEstadoCausaRefViewT> JsonT(string term)
		{
			var x = from c in db.GruposEstadoCausaRef
					select new GruposEstadoCausaRefViewT
					{
						 ID = c.ID,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<GruposEstadoCausaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
