
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
	public partial class CausasDocumentoAD
	{
		private BDEntities db = new BDEntities();

		public CausasDocumento ObtenerPorId(int Id)
		{
			return db.CausasDocumento.Single(c => c.Id == Id);
		}

		public DbQuery<CausasDocumento> ObtenerTodo()
		{
			return (DbQuery<CausasDocumento>)db.CausasDocumento;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CausasDocumento
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CausasDocumentoView> ObtenerParaGrilla()
		{
			var x = from c in db.CausasDocumento
					select new CausasDocumentoView
					{
						 Id = c.Id,
						 Persona = c.Persona,
						 Actuacion = c.Actuacion,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 Confirmado = c.Confirmado,
						 Nosotros = c.Nosotros,
					};
			return (DbQuery<CausasDocumentoView>)x;
		}

		public void Guardar(CausasDocumento Objeto)
		{
			try
			{
				db.CausasDocumento.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasDocumento Objeto)
		{
			try
			{
				db.CausasDocumento.Attach(Objeto);
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
				CausasDocumento Objeto = this.ObtenerPorId(IdObjeto);
				db.CausasDocumento.Remove(Objeto);
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

		public DbQuery<CausasDocumentoViewT> JsonT(string term)
		{
			var x = from c in db.CausasDocumento
					select new CausasDocumentoViewT
					{
						 Id = c.Id,
						 Persona = c.Persona,
						 Actuacion = c.Actuacion,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 Confirmado = c.Confirmado,
						 Nosotros = c.Nosotros,
					};
			return (DbQuery<CausasDocumentoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
