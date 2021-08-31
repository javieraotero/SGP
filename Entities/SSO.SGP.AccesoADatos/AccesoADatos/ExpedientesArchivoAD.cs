
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
	public partial class ExpedientesArchivoAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesArchivo ObtenerPorId(int Id)
		{
			return db.ExpedientesArchivo.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesArchivo> ObtenerTodo()
		{
			return (DbQuery<ExpedientesArchivo>)db.ExpedientesArchivo;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesArchivo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesArchivoView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesArchivo
					select new ExpedientesArchivoView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 UsuarioEnvio = c.UsuarioEnvio,
						 Firmante = c.Firmante,
						 FechaEnvio = c.FechaEnvio,
						 Observaciones = c.Observaciones,
						 Anulado = c.Anulado,
						 FechaFinArchivo = c.FechaFinArchivo,
						 FechaAlta = c.FechaAlta,
					};
			return (DbQuery<ExpedientesArchivoView>)x;
		}

		public void Guardar(ExpedientesArchivo Objeto)
		{
			try
			{
				db.ExpedientesArchivo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesArchivo Objeto)
		{
			try
			{
				db.ExpedientesArchivo.Attach(Objeto);
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
				ExpedientesArchivo Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesArchivo.Remove(Objeto);
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

		public DbQuery<ExpedientesArchivoViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesArchivo
					select new ExpedientesArchivoViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 UsuarioEnvio = c.UsuarioEnvio,
						 Firmante = c.Firmante,
						 FechaEnvio = c.FechaEnvio,
						 Observaciones = c.Observaciones,
						 Anulado = c.Anulado,
						 FechaFinArchivo = c.FechaFinArchivo,
						 FechaAlta = c.FechaAlta,
					};
			return (DbQuery<ExpedientesArchivoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
