
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
	public partial class TiposOrganismoRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposOrganismoRef ObtenerPorId(int Id)
		{
			return db.TiposOrganismoRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposOrganismoRef> ObtenerTodo()
		{
			return (DbQuery<TiposOrganismoRef>)db.TiposOrganismoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposOrganismoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposOrganismoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposOrganismoRef
					select new TiposOrganismoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposOrganismoRefView>)x;
		}

		public void Guardar(TiposOrganismoRef Objeto)
		{
			try
			{
				db.TiposOrganismoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOrganismoRef Objeto)
		{
			try
			{
				db.TiposOrganismoRef.Attach(Objeto);
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
				TiposOrganismoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposOrganismoRef.Remove(Objeto);
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

		public DbQuery<TiposOrganismoRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposOrganismoRef
					select new TiposOrganismoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposOrganismoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
