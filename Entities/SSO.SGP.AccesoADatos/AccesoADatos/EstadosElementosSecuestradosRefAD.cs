
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
	public partial class EstadosElementosSecuestradosRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosElementosSecuestradosRef ObtenerPorId(int Id)
		{
			return db.EstadosElementosSecuestradosRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosElementosSecuestradosRef> ObtenerTodo()
		{
			return (DbQuery<EstadosElementosSecuestradosRef>)db.EstadosElementosSecuestradosRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosElementosSecuestradosRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosElementosSecuestradosRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosElementosSecuestradosRef
					select new EstadosElementosSecuestradosRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosElementosSecuestradosRefView>)x;
		}

		public void Guardar(EstadosElementosSecuestradosRef Objeto)
		{
			try
			{
				db.EstadosElementosSecuestradosRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosElementosSecuestradosRef Objeto)
		{
			try
			{
				db.EstadosElementosSecuestradosRef.Attach(Objeto);
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
				EstadosElementosSecuestradosRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosElementosSecuestradosRef.Remove(Objeto);
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

		public DbQuery<EstadosElementosSecuestradosRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosElementosSecuestradosRef
					select new EstadosElementosSecuestradosRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<EstadosElementosSecuestradosRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
