
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
	public partial class CategoriasExpedienteadmRefAD
	{
		private BDEntities db = new BDEntities();

		public CategoriasExpedienteadmRef ObtenerPorId(int Id)
		{
			return db.CategoriasExpedienteadmRef.Single(c => c.Id == Id);
		}

		public DbQuery<CategoriasExpedienteadmRef> ObtenerTodo()
		{
			return (DbQuery<CategoriasExpedienteadmRef>)db.CategoriasExpedienteadmRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CategoriasExpedienteadmRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CategoriasExpedienteadmRefView> ObtenerParaGrilla()
		{
			var x = from c in db.CategoriasExpedienteadmRef
					select new CategoriasExpedienteadmRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CategoriasExpedienteadmRefView>)x;
		}

		public void Guardar(CategoriasExpedienteadmRef Objeto)
		{
			try
			{
				db.CategoriasExpedienteadmRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasExpedienteadmRef Objeto)
		{
			try
			{
				db.CategoriasExpedienteadmRef.Attach(Objeto);
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
				CategoriasExpedienteadmRef Objeto = this.ObtenerPorId(IdObjeto);
				db.CategoriasExpedienteadmRef.Remove(Objeto);
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

		public DbQuery<CategoriasExpedienteadmRefViewT> JsonT(string term)
		{
			var x = from c in db.CategoriasExpedienteadmRef
					select new CategoriasExpedienteadmRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<CategoriasExpedienteadmRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
