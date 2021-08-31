
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
	public partial class AtencionesRefAD
	{
		private BDEntities db = new BDEntities();

		public AtencionesRef ObtenerPorId(int Id)
		{
			return db.AtencionesRef.Single(c => c.Id == Id);
		}

		public DbQuery<AtencionesRef> ObtenerTodo()
		{
			return (DbQuery<AtencionesRef>)db.AtencionesRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AtencionesRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AtencionesRefView> ObtenerParaGrilla()
		{
			var x = from c in db.AtencionesRef
					select new AtencionesRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Prestacion = c.Prestacion,
					};
			return (DbQuery<AtencionesRefView>)x;
		}

		public void Guardar(AtencionesRef Objeto)
		{
			try
			{
				db.AtencionesRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AtencionesRef Objeto)
		{
			try
			{
				db.AtencionesRef.Attach(Objeto);
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
				AtencionesRef Objeto = this.ObtenerPorId(IdObjeto);
				db.AtencionesRef.Remove(Objeto);
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

		public DbQuery<AtencionesRefViewT> JsonT(string term)
		{
			var x = from c in db.AtencionesRef
					select new AtencionesRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Prestacion = c.Prestacion,
					};
			return (DbQuery<AtencionesRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
