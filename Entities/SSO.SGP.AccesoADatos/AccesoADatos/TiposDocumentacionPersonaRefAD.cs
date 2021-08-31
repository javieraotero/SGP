
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
	public partial class TiposDocumentacionPersonaRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposDocumentacionPersonaRef ObtenerPorId(int Id)
		{
			return db.TiposDocumentacionPersonaRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposDocumentacionPersonaRef> ObtenerTodo()
		{
			return (DbQuery<TiposDocumentacionPersonaRef>)db.TiposDocumentacionPersonaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposDocumentacionPersonaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposDocumentacionPersonaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposDocumentacionPersonaRef
					select new TiposDocumentacionPersonaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Antecedente = c.Antecedente,
						 Orden = c.Orden,
					};
			return (DbQuery<TiposDocumentacionPersonaRefView>)x;
		}

		public void Guardar(TiposDocumentacionPersonaRef Objeto)
		{
			try
			{
				db.TiposDocumentacionPersonaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDocumentacionPersonaRef Objeto)
		{
			try
			{
				db.TiposDocumentacionPersonaRef.Attach(Objeto);
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
				TiposDocumentacionPersonaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposDocumentacionPersonaRef.Remove(Objeto);
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

		public DbQuery<TiposDocumentacionPersonaRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposDocumentacionPersonaRef
					select new TiposDocumentacionPersonaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Antecedente = c.Antecedente,
						 Orden = c.Orden,
					};
			return (DbQuery<TiposDocumentacionPersonaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
