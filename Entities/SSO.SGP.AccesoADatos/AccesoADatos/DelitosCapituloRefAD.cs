
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
	public partial class DelitosCapituloRefAD
	{
		private BDEntities db = new BDEntities();

		public DelitosCapituloRef ObtenerPorId(int Id)
		{
			return db.DelitosCapituloRef.Single(c => c.Id == Id);
		}

		public DbQuery<DelitosCapituloRef> ObtenerTodo()
		{
			return (DbQuery<DelitosCapituloRef>)db.DelitosCapituloRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.DelitosCapituloRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DelitosCapituloRefView> ObtenerParaGrilla()
		{
			var x = from c in db.DelitosCapituloRef
					select new DelitosCapituloRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Titulo = c.Titulo,
					};
			return (DbQuery<DelitosCapituloRefView>)x;
		}

		public void Guardar(DelitosCapituloRef Objeto)
		{
			try
			{
				db.DelitosCapituloRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DelitosCapituloRef Objeto)
		{
			try
			{
				db.DelitosCapituloRef.Attach(Objeto);
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
				DelitosCapituloRef Objeto = this.ObtenerPorId(IdObjeto);
				db.DelitosCapituloRef.Remove(Objeto);
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

		public DbQuery<DelitosCapituloRefViewT> JsonT(string term)
		{
			var x = from c in db.DelitosCapituloRef
					select new DelitosCapituloRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Titulo = c.Titulo,
					};
			return (DbQuery<DelitosCapituloRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
