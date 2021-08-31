
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
	public partial class GrupoElementosPoliciaRefAD
	{
		private BDEntities db = new BDEntities();

		public GrupoElementosPoliciaRef ObtenerPorId(int Id)
		{
			return db.GrupoElementosPoliciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<GrupoElementosPoliciaRef> ObtenerTodo()
		{
			return (DbQuery<GrupoElementosPoliciaRef>)db.GrupoElementosPoliciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.GrupoElementosPoliciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<GrupoElementosPoliciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.GrupoElementosPoliciaRef
					select new GrupoElementosPoliciaRefView
					{
						 Id = c.Id,
						 IdSigla = c.IdSigla,
						 Sigla = c.Sigla,
						 ElementosSigla = c.ElementosSigla,
					};
			return (DbQuery<GrupoElementosPoliciaRefView>)x;
		}

		public void Guardar(GrupoElementosPoliciaRef Objeto)
		{
			try
			{
				db.GrupoElementosPoliciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(GrupoElementosPoliciaRef Objeto)
		{
			try
			{
				db.GrupoElementosPoliciaRef.Attach(Objeto);
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
				GrupoElementosPoliciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.GrupoElementosPoliciaRef.Remove(Objeto);
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

		public DbQuery<GrupoElementosPoliciaRefViewT> JsonT(string term)
		{
			var x = from c in db.GrupoElementosPoliciaRef
					select new GrupoElementosPoliciaRefViewT
					{
						 Id = c.Id,
						 IdSigla = c.IdSigla,
						 Sigla = c.Sigla,
						 ElementosSigla = c.ElementosSigla,
					};
			return (DbQuery<GrupoElementosPoliciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
