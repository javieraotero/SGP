
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
	public partial class PreventivosDelitosAD
	{
		private BDEntities db = new BDEntities();

		public PreventivosDelitos ObtenerPorId(int Id)
		{
			return db.PreventivosDelitos.Single(c => c.Id == Id);
		}

		public DbQuery<PreventivosDelitos> ObtenerTodo()
		{
			return (DbQuery<PreventivosDelitos>)db.PreventivosDelitos;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.PreventivosDelitos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PreventivosDelitosView> ObtenerParaGrilla()
		{
			var x = from c in db.PreventivosDelitos
					select new PreventivosDelitosView
					{
						 Id = c.Id,
						 Preventivo = c.Preventivo,
						 Delito = c.Delito,
						 Tentativa = c.Tentativa,
						 Flagrancia = c.Flagrancia,
					};
			return (DbQuery<PreventivosDelitosView>)x;
		}

		public void Guardar(PreventivosDelitos Objeto)
		{
			try
			{
				db.PreventivosDelitos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(PreventivosDelitos Objeto)
		{
			try
			{
				db.PreventivosDelitos.Attach(Objeto);
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
				PreventivosDelitos Objeto = this.ObtenerPorId(IdObjeto);
				db.PreventivosDelitos.Remove(Objeto);
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

		public DbQuery<PreventivosDelitosViewT> JsonT(string term)
		{
			var x = from c in db.PreventivosDelitos
					select new PreventivosDelitosViewT
					{
						 Id = c.Id,
						 Preventivo = c.Preventivo,
						 Delito = c.Delito,
						 Tentativa = c.Tentativa,
						 Flagrancia = c.Flagrancia,
					};
			return (DbQuery<PreventivosDelitosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
