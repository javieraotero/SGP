
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
	public partial class ElementosSecuestradosDocumentoAD
	{
		private BDEntities db = new BDEntities();

		public ElementosSecuestradosDocumento ObtenerPorId(int Id)
		{
			return db.ElementosSecuestradosDocumento.Single(c => c.Id == Id);
		}

		public DbQuery<ElementosSecuestradosDocumento> ObtenerTodo()
		{
			return (DbQuery<ElementosSecuestradosDocumento>)db.ElementosSecuestradosDocumento;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ElementosSecuestradosDocumento
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ElementosSecuestradosDocumentoView> ObtenerParaGrilla()
		{
			var x = from c in db.ElementosSecuestradosDocumento
					select new ElementosSecuestradosDocumentoView
					{
						 Id = c.Id,
						 Elemento = c.Elemento,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
						 Confirmado = c.Confirmado,
					};
			return (DbQuery<ElementosSecuestradosDocumentoView>)x;
		}

		public void Guardar(ElementosSecuestradosDocumento Objeto)
		{
			try
			{
				db.ElementosSecuestradosDocumento.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ElementosSecuestradosDocumento Objeto)
		{
			try
			{
				db.ElementosSecuestradosDocumento.Attach(Objeto);
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
				ElementosSecuestradosDocumento Objeto = this.ObtenerPorId(IdObjeto);
				db.ElementosSecuestradosDocumento.Remove(Objeto);
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

		public DbQuery<ElementosSecuestradosDocumentoViewT> JsonT(string term)
		{
			var x = from c in db.ElementosSecuestradosDocumento
					select new ElementosSecuestradosDocumentoViewT
					{
						 Id = c.Id,
						 Elemento = c.Elemento,
						 NombreOriginal = c.NombreOriginal,
						 Extension = c.Extension,
						 Descripcion = c.Descripcion,
						 FechaAlta = c.FechaAlta,
						 Usuario = c.Usuario,
						 Confirmado = c.Confirmado,
					};
			return (DbQuery<ElementosSecuestradosDocumentoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
