
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
	public partial class ExpedientesDocumentoadmAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesDocumentoadm ObtenerPorId(int Id)
		{
			return db.ExpedientesDocumentoadm.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesDocumentoadm> ObtenerTodo()
		{
			return (DbQuery<ExpedientesDocumentoadm>)db.ExpedientesDocumentoadm;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesDocumentoadm
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

        public DbQuery<ExpedientesDocumentoadm> ObtenerPorExpediente(int expediente)
        {
            var res = from x in db.ExpedientesDocumentoadm
                      where x.Expediente == expediente
                      select x;
            return (DbQuery<ExpedientesDocumentoadm>)res;
        }

        public DbQuery<ExpedientesDocumentoadm> ObtenerPorActuacion(int actuacion)
        {
            var res = from x in db.ExpedientesDocumentoadm
                      where x.Actuacion == actuacion
                      select x;
            return (DbQuery<ExpedientesDocumentoadm>)res;
        }

        public DbQuery<ExpedientesDocumentoadmView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesDocumentoadm
					select new ExpedientesDocumentoadmView
					{
						 Id = c.Id,
						// Persona = c.Persona,
						 Actuacion = c.Actuacion,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 Confirmado = c.Confirmado,
					};
			return (DbQuery<ExpedientesDocumentoadmView>)x;
		}

		public void Guardar(ExpedientesDocumentoadm Objeto)
		{
			try
			{
				db.ExpedientesDocumentoadm.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesDocumentoadm Objeto)
		{
			try
			{
				db.ExpedientesDocumentoadm.Attach(Objeto);
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
				ExpedientesDocumentoadm Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesDocumentoadm.Remove(Objeto);
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

		public DbQuery<ExpedientesDocumentoadmViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesDocumentoadm
					select new ExpedientesDocumentoadmViewT
					{
						 Id = c.Id,
						 //Persona = c.Persona,
						 Actuacion = c.Actuacion,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 Confirmado = c.Confirmado,
					};
			return (DbQuery<ExpedientesDocumentoadmViewT>)x;
		}
        /*********************************************
		* Seccion Particular
		* *******************************************/       
    }
}
