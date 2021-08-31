
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
	public partial class AuditoriaAD
	{
		private BDEntities db = new BDEntities();

		public Auditoria ObtenerPorId(int Id)
		{
			return db.Auditoria.Single(c => c.Id == Id);
		}

		public DbQuery<Auditoria> ObtenerTodo()
		{
			return (DbQuery<Auditoria>)db.Auditoria;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Auditoria
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AuditoriaView> ObtenerParaGrilla()
		{
			var x = from c in db.Auditoria
					select new AuditoriaView
					{
						 Id = c.Id,
						 Tabla = c.Tabla,
						 Columna = c.Columna,
						 Referencia = c.Referencia,
						 IdReferencia = c.IdReferencia,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 ValorAnterior = c.ValorAnterior,
						 ValorNuevo = c.ValorNuevo,
					};
			return (DbQuery<AuditoriaView>)x;
		}

		public void Guardar(Auditoria Objeto)
		{
			try
			{
				db.Auditoria.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Auditoria Objeto)
		{
			try
			{
				db.Auditoria.Attach(Objeto);
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
				Auditoria Objeto = this.ObtenerPorId(IdObjeto);
				db.Auditoria.Remove(Objeto);
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

		public DbQuery<AuditoriaViewT> JsonT(string term)
		{
			var x = from c in db.Auditoria
					select new AuditoriaViewT
					{
						 Id = c.Id,
						 Tabla = c.Tabla,
						 Columna = c.Columna,
						 Referencia = c.Referencia,
						 IdReferencia = c.IdReferencia,
						 Usuario = c.Usuario,
						 Fecha = c.Fecha,
						 ValorAnterior = c.ValorAnterior,
						 ValorNuevo = c.ValorNuevo,
					};
			return (DbQuery<AuditoriaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
