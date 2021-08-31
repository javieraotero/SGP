
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
	public partial class EstadosArchivoExpedienteRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosArchivoExpedienteRef ObtenerPorId(int Id)
		{
			return db.EstadosArchivoExpedienteRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosArchivoExpedienteRef> ObtenerTodo()
		{
			return (DbQuery<EstadosArchivoExpedienteRef>)db.EstadosArchivoExpedienteRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosArchivoExpedienteRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosArchivoExpedienteRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosArchivoExpedienteRef
					select new EstadosArchivoExpedienteRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosArchivoExpedienteRefView>)x;
		}

		public void Guardar(EstadosArchivoExpedienteRef Objeto)
		{
			try
			{
				db.EstadosArchivoExpedienteRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosArchivoExpedienteRef Objeto)
		{
			try
			{
				db.EstadosArchivoExpedienteRef.Attach(Objeto);
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
				EstadosArchivoExpedienteRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosArchivoExpedienteRef.Remove(Objeto);
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

		public DbQuery<EstadosArchivoExpedienteRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosArchivoExpedienteRef
					select new EstadosArchivoExpedienteRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosArchivoExpedienteRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
