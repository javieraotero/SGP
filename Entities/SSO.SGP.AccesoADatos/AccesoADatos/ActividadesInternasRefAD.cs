
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
	public partial class ActividadesInternasRefAD
	{
		private BDEntities db = new BDEntities();

		public ActividadesInternasRef ObtenerPorId(int Id)
		{
			return db.ActividadesInternasRef.Single(c => c.Id == Id);
		}

		public DbQuery<ActividadesInternasRef> ObtenerTodo()
		{
			return (DbQuery<ActividadesInternasRef>)db.ActividadesInternasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ActividadesInternasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ActividadesInternasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ActividadesInternasRef
					select new ActividadesInternasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ActividadesInternasRefView>)x;
		}

		public void Guardar(ActividadesInternasRef Objeto)
		{
			try
			{
				db.ActividadesInternasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ActividadesInternasRef Objeto)
		{
			try
			{
				db.ActividadesInternasRef.Attach(Objeto);
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
				ActividadesInternasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.ActividadesInternasRef.Remove(Objeto);
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

		public DbQuery<ActividadesInternasRefViewT> JsonT(string term)
		{
			var x = from c in db.ActividadesInternasRef
					select new ActividadesInternasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ActividadesInternasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
