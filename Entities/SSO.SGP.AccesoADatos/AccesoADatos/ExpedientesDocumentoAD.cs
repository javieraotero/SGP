
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
	public partial class ExpedientesDocumentoAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesDocumento ObtenerPorId(int Id)
		{
			return db.ExpedientesDocumento.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesDocumento> ObtenerTodo()
		{
			return (DbQuery<ExpedientesDocumento>)db.ExpedientesDocumento;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesDocumento
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesDocumentoView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesDocumento
					select new ExpedientesDocumentoView
					{
						 Id = c.Id,
						 Persona = c.Persona,
						 DocumentacionPersona = c.DocumentacionPersona,
						 Delito = c.Delito,
						 Actuacion = c.Actuacion,
						 Elemento = c.Elemento,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 Confirmado = c.Confirmado,
						 Nosotros = c.Nosotros,
					};
			return (DbQuery<ExpedientesDocumentoView>)x;
		}

		public void Guardar(ExpedientesDocumento Objeto)
		{
			try
			{
				db.ExpedientesDocumento.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesDocumento Objeto)
		{
			try
			{
				db.ExpedientesDocumento.Attach(Objeto);
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
				ExpedientesDocumento Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesDocumento.Remove(Objeto);
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

		public DbQuery<ExpedientesDocumentoViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesDocumento
					select new ExpedientesDocumentoViewT
					{
						 Id = c.Id,
						 Persona = c.Persona,
						 DocumentacionPersona = c.DocumentacionPersona,
						 Delito = c.Delito,
						 Actuacion = c.Actuacion,
						 Elemento = c.Elemento,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 Confirmado = c.Confirmado,
						 Nosotros = c.Nosotros,
					};
			return (DbQuery<ExpedientesDocumentoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
