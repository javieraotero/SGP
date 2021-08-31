
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
	public partial class CategoriasExpedientesAD
	{
		private BDEntities db = new BDEntities();

		public CategoriasExpedientes ObtenerPorId(int Id)
		{
			return db.CategoriasExpedientes.Single(c => c.Id == Id);
		}

		public DbQuery<CategoriasExpedientes> ObtenerTodo()
		{
			return (DbQuery<CategoriasExpedientes>)db.CategoriasExpedientes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CategoriasExpedientes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CategoriasExpedientesView> ObtenerParaGrilla()
		{
			var x = from c in db.CategoriasExpedientes
					select new CategoriasExpedientesView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 SubAmbito = c.SubAmbito,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<CategoriasExpedientesView>)x;
		}

		public void Guardar(CategoriasExpedientes Objeto)
		{
			try
			{
				db.CategoriasExpedientes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CategoriasExpedientes Objeto)
		{
			try
			{
				db.CategoriasExpedientes.Attach(Objeto);
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
				CategoriasExpedientes Objeto = this.ObtenerPorId(IdObjeto);
				db.CategoriasExpedientes.Remove(Objeto);
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

		public DbQuery<CategoriasExpedientesViewT> JsonT(string term)
		{
			var x = from c in db.CategoriasExpedientes
					select new CategoriasExpedientesViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 SubAmbito = c.SubAmbito,
						 Circunscripcion = c.Circunscripcion,
					};
			return (DbQuery<CategoriasExpedientesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
