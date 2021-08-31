
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
	public partial class TiposCuentasBancariasRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposCuentasBancariasRef ObtenerPorId(int Id)
		{
			return db.TiposCuentasBancariasRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposCuentasBancariasRef> ObtenerTodo()
		{
			return (DbQuery<TiposCuentasBancariasRef>)db.TiposCuentasBancariasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposCuentasBancariasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposCuentasBancariasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposCuentasBancariasRef
					select new TiposCuentasBancariasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposCuentasBancariasRefView>)x;
		}

		public void Guardar(TiposCuentasBancariasRef Objeto)
		{
			try
			{
				db.TiposCuentasBancariasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposCuentasBancariasRef Objeto)
		{
			try
			{
				db.TiposCuentasBancariasRef.Attach(Objeto);
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
				TiposCuentasBancariasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposCuentasBancariasRef.Remove(Objeto);
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

		public DbQuery<TiposCuentasBancariasRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposCuentasBancariasRef
					select new TiposCuentasBancariasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<TiposCuentasBancariasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
