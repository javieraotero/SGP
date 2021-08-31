
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
	public partial class AudienciasSolicitudPersonasRelAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasSolicitudPersonasRel ObtenerPorId(int Id)
		{
			return db.AudienciasSolicitudPersonasRel.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasSolicitudPersonasRel> ObtenerTodo()
		{
			return (DbQuery<AudienciasSolicitudPersonasRel>)db.AudienciasSolicitudPersonasRel;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasSolicitudPersonasRel
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasSolicitudPersonasRelView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasSolicitudPersonasRel
					select new AudienciasSolicitudPersonasRelView
					{
						 Solicitud = c.Solicitud,
						 Parte = c.Parte,
					};
			return (DbQuery<AudienciasSolicitudPersonasRelView>)x;
		}

		public void Guardar(AudienciasSolicitudPersonasRel Objeto)
		{
			try
			{
				db.AudienciasSolicitudPersonasRel.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasSolicitudPersonasRel Objeto)
		{
			try
			{
				db.AudienciasSolicitudPersonasRel.Attach(Objeto);
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
				AudienciasSolicitudPersonasRel Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasSolicitudPersonasRel.Remove(Objeto);
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

		public DbQuery<AudienciasSolicitudPersonasRelViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasSolicitudPersonasRel
					select new AudienciasSolicitudPersonasRelViewT
					{
						 Solicitud = c.Solicitud,
						 Parte = c.Parte,
					};
			return (DbQuery<AudienciasSolicitudPersonasRelViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
