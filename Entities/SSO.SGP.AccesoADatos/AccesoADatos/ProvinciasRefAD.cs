
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
	public partial class ProvinciasRefAD
	{
		private BDEntities db = new BDEntities();

		public ProvinciasRef ObtenerPorId(int Id)
		{
			return db.ProvinciasRef.Single(c => c.Id == Id);
		}

		public DbQuery<ProvinciasRef> ObtenerTodo()
		{
			return (DbQuery<ProvinciasRef>)db.ProvinciasRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ProvinciasRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ProvinciasRefView> ObtenerParaGrilla()
		{
			var x = from c in db.ProvinciasRef
					select new ProvinciasRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ProvinciasRefView>)x;
		}

		public void Guardar(ProvinciasRef Objeto)
		{
			try
			{
				db.ProvinciasRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ProvinciasRef Objeto)
		{
			try
			{
				db.ProvinciasRef.Attach(Objeto);
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
				ProvinciasRef Objeto = this.ObtenerPorId(IdObjeto);
				db.ProvinciasRef.Remove(Objeto);
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

		public DbQuery<ProvinciasRefViewT> JsonT(string term)
		{
			var x = from c in db.ProvinciasRef
					select new ProvinciasRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ProvinciasRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
