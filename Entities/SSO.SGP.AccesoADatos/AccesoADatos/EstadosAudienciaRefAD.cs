
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
	public partial class EstadosAudienciaRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosAudienciaRef ObtenerPorId(int Id)
		{
			return db.EstadosAudienciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosAudienciaRef> ObtenerTodo()
		{
			return (DbQuery<EstadosAudienciaRef>)db.EstadosAudienciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosAudienciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosAudienciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosAudienciaRef
					select new EstadosAudienciaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 GrupoEstadoAudiencia = c.GrupoEstadoAudiencia,
					};
			return (DbQuery<EstadosAudienciaRefView>)x;
		}

		public void Guardar(EstadosAudienciaRef Objeto)
		{
			try
			{
				db.EstadosAudienciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosAudienciaRef Objeto)
		{
			try
			{
				db.EstadosAudienciaRef.Attach(Objeto);
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
				EstadosAudienciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosAudienciaRef.Remove(Objeto);
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

		public DbQuery<EstadosAudienciaRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosAudienciaRef
					select new EstadosAudienciaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 GrupoEstadoAudiencia = c.GrupoEstadoAudiencia,
					};
			return (DbQuery<EstadosAudienciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
