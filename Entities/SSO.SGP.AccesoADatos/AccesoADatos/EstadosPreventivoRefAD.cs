
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
	public partial class EstadosPreventivoRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosPreventivoRef ObtenerPorId(int Id)
		{
			return db.EstadosPreventivoRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosPreventivoRef> ObtenerTodo()
		{
			return (DbQuery<EstadosPreventivoRef>)db.EstadosPreventivoRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosPreventivoRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosPreventivoRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosPreventivoRef
					select new EstadosPreventivoRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosPreventivoRefView>)x;
		}

		public void Guardar(EstadosPreventivoRef Objeto)
		{
			try
			{
				db.EstadosPreventivoRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosPreventivoRef Objeto)
		{
			try
			{
				db.EstadosPreventivoRef.Attach(Objeto);
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
				EstadosPreventivoRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosPreventivoRef.Remove(Objeto);
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

		public DbQuery<EstadosPreventivoRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosPreventivoRef
					select new EstadosPreventivoRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosPreventivoRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
