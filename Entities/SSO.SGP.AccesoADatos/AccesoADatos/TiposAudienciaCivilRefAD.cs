
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
	public partial class TiposAudienciaCivilRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposAudienciaCivilRef ObtenerPorId(int Id)
		{
			return db.TiposAudienciaCivilRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposAudienciaCivilRef> ObtenerTodo()
		{
			return (DbQuery<TiposAudienciaCivilRef>)db.TiposAudienciaCivilRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposAudienciaCivilRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposAudienciaCivilRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposAudienciaCivilRef
					select new TiposAudienciaCivilRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EnUso = c.EnUso,
						 Ambito = c.Ambito,
					};
			return (DbQuery<TiposAudienciaCivilRefView>)x;
		}

		public void Guardar(TiposAudienciaCivilRef Objeto)
		{
			try
			{
				db.TiposAudienciaCivilRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposAudienciaCivilRef Objeto)
		{
			try
			{
				db.TiposAudienciaCivilRef.Attach(Objeto);
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
				TiposAudienciaCivilRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposAudienciaCivilRef.Remove(Objeto);
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

		public DbQuery<TiposAudienciaCivilRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposAudienciaCivilRef
					select new TiposAudienciaCivilRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EnUso = c.EnUso,
						 Ambito = c.Ambito,
					};
			return (DbQuery<TiposAudienciaCivilRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
