
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
	public partial class EstadosCausaRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosCausaRef ObtenerPorId(int Id)
		{
			return db.EstadosCausaRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosCausaRef> ObtenerTodo()
		{
			return (DbQuery<EstadosCausaRef>)db.EstadosCausaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosCausaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosCausaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosCausaRef
					select new EstadosCausaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 GrupoEstado = c.GrupoEstado,
					};
			return (DbQuery<EstadosCausaRefView>)x;
		}

		public void Guardar(EstadosCausaRef Objeto)
		{
			try
			{
				db.EstadosCausaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosCausaRef Objeto)
		{
			try
			{
				db.EstadosCausaRef.Attach(Objeto);
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
				EstadosCausaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosCausaRef.Remove(Objeto);
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

		public DbQuery<EstadosCausaRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosCausaRef
					select new EstadosCausaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 GrupoEstado = c.GrupoEstado,
					};
			return (DbQuery<EstadosCausaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
