
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
	public partial class TiposExpedienteadmRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposExpedienteadmRef ObtenerPorId(int Id)
		{
			return db.TiposExpedienteadmRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposExpedienteadmRef> ObtenerTodo()
		{
			return (DbQuery<TiposExpedienteadmRef>)db.TiposExpedienteadmRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposExpedienteadmRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposExpedienteadmRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposExpedienteadmRef
					select new TiposExpedienteadmRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 UltimoNumero = c.UltimoNumero,
					};
			return (DbQuery<TiposExpedienteadmRefView>)x;
		}

		public void Guardar(TiposExpedienteadmRef Objeto)
		{
			try
			{
				db.TiposExpedienteadmRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposExpedienteadmRef Objeto)
		{
			try
			{
				db.TiposExpedienteadmRef.Attach(Objeto);
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
				TiposExpedienteadmRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposExpedienteadmRef.Remove(Objeto);
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

		public DbQuery<TiposExpedienteadmRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposExpedienteadmRef
					select new TiposExpedienteadmRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 UltimoNumero = c.UltimoNumero,
					};
			return (DbQuery<TiposExpedienteadmRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
