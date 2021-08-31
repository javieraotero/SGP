
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
	public partial class EstadosActuacionRefAD
	{
		private BDEntities db = new BDEntities();

		public EstadosActuacionRef ObtenerPorId(int Id)
		{
			return db.EstadosActuacionRef.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosActuacionRef> ObtenerTodo()
		{
			return (DbQuery<EstadosActuacionRef>)db.EstadosActuacionRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosActuacionRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosActuacionRefView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosActuacionRef
					select new EstadosActuacionRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Procesal = c.Procesal,
					};
			return (DbQuery<EstadosActuacionRefView>)x;
		}

		public void Guardar(EstadosActuacionRef Objeto)
		{
			try
			{
				db.EstadosActuacionRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosActuacionRef Objeto)
		{
			try
			{
				db.EstadosActuacionRef.Attach(Objeto);
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
				EstadosActuacionRef Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosActuacionRef.Remove(Objeto);
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

		public DbQuery<EstadosActuacionRefViewT> JsonT(string term)
		{
			var x = from c in db.EstadosActuacionRef
					select new EstadosActuacionRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Procesal = c.Procesal,
					};
			return (DbQuery<EstadosActuacionRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
