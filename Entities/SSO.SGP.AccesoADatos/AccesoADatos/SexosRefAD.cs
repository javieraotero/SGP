
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
	public partial class SexosRefAD
	{
		private BDEntities db = new BDEntities();

		public SexosRef ObtenerPorId(int Id)
		{
			return db.SexosRef.Single(c => c.Id == Id);
		}

		public DbQuery<SexosRef> ObtenerTodo()
		{
			return (DbQuery<SexosRef>)db.SexosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SexosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SexosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.SexosRef
					select new SexosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<SexosRefView>)x;
		}

		public void Guardar(SexosRef Objeto)
		{
			try
			{
				db.SexosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SexosRef Objeto)
		{
			try
			{
				db.SexosRef.Attach(Objeto);
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
				SexosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.SexosRef.Remove(Objeto);
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

		public DbQuery<SexosRefViewT> JsonT(string term)
		{
			var x = from c in db.SexosRef
					select new SexosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<SexosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
