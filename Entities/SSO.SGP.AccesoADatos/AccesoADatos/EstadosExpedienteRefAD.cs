
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
	public partial class EstadosExpedienteRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosExpedienteRef ObtenerPorId(int Id)
		{
			return db.EstadosExpedienteRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosExpedienteRef> ObtenerTodo()
		{
			return (DbQuery<EstadosExpedienteRef>)db.EstadosExpedienteRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosExpedienteRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosExpedienteRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosExpedienteRef
					select new EstadosExpedienteRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 GrupoEstado = c.GrupoEstado,
						 Finaliza = c.Finaliza,
					};
			return (DbQuery<EstadosExpedienteRefView>)x;
		}

		public void Guardar(EstadosExpedienteRef Objeto)
		{
			try
			{
				db.EstadosExpedienteRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosExpedienteRef Objeto)
		{
			try
			{
				db.EstadosExpedienteRef.Attach(Objeto);
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
				EstadosExpedienteRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosExpedienteRef.Remove(Objeto);
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

		public DbQuery<EstadosExpedienteRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosExpedienteRef
					select new EstadosExpedienteRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 GrupoEstado = c.GrupoEstado,
						 Finaliza = c.Finaliza,
					};
			return (DbQuery<EstadosExpedienteRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
