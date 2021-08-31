
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
	public partial class ResultadosNotificacionAD
	{
		private BDEntities db = new BDEntities();

		public ResultadosNotificacion ObtenerPorId(int Id)
		{
			return db.ResultadosNotificacion.Single(c => c.Id == Id);
		}

		public DbQuery<ResultadosNotificacion> ObtenerTodo()
		{
			return (DbQuery<ResultadosNotificacion>)db.ResultadosNotificacion;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ResultadosNotificacion
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ResultadosNotificacionView> ObtenerParaGrilla()
		{
			var x = from c in db.ResultadosNotificacion
					select new ResultadosNotificacionView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ResultadosNotificacionView>)x;
		}

		public void Guardar(ResultadosNotificacion Objeto)
		{
			try
			{
				db.ResultadosNotificacion.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ResultadosNotificacion Objeto)
		{
			try
			{
				db.ResultadosNotificacion.Attach(Objeto);
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
				ResultadosNotificacion Objeto = this.ObtenerPorId(IdObjeto);
				db.ResultadosNotificacion.Remove(Objeto);
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

		public DbQuery<ResultadosNotificacionViewT> JsonT(string term)
		{
			var x = from c in db.ResultadosNotificacion
					select new ResultadosNotificacionViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<ResultadosNotificacionViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
