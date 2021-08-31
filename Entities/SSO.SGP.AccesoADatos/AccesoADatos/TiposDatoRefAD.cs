
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
	public partial class TiposDatoRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposDatoRef ObtenerPorId(int Id)
		{
			return db.TiposDatoRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposDatoRef> ObtenerTodo()
		{
			return (DbQuery<TiposDatoRef>)db.TiposDatoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposDatoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposDatoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposDatoRef
					select new TiposDatoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mascara = c.Mascara,
					};
			return (DbQuery<TiposDatoRefView>)x;
		}

		public void Guardar(TiposDatoRef Objeto)
		{
			try
			{
				db.TiposDatoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposDatoRef Objeto)
		{
			try
			{
				db.TiposDatoRef.Attach(Objeto);
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
				TiposDatoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposDatoRef.Remove(Objeto);
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

		public DbQuery<TiposDatoRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposDatoRef
					select new TiposDatoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Mascara = c.Mascara,
					};
			return (DbQuery<TiposDatoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
