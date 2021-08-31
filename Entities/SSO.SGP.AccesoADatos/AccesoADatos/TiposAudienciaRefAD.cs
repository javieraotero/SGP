
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
	public partial class TiposAudienciaRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposAudienciaRef ObtenerPorId(int Id)
		{
			return db.TiposAudienciaRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposAudienciaRef> ObtenerTodo()
		{
			return (DbQuery<TiposAudienciaRef>)db.TiposAudienciaRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposAudienciaRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposAudienciaRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposAudienciaRef
					select new TiposAudienciaRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EnUso = c.EnUso,
						 Juicio = c.Juicio,
						 RelevarControl = c.RelevarControl,
						 Ambito = c.Ambito,
						 NotificaPresidenteAudiencia = c.NotificaPresidenteAudiencia,
					};
			return (DbQuery<TiposAudienciaRefView>)x;
		}

		public void Guardar(TiposAudienciaRef Objeto)
		{
			try
			{
				db.TiposAudienciaRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposAudienciaRef Objeto)
		{
			try
			{
				db.TiposAudienciaRef.Attach(Objeto);
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
				TiposAudienciaRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposAudienciaRef.Remove(Objeto);
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

		public DbQuery<TiposAudienciaRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposAudienciaRef
					select new TiposAudienciaRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 EnUso = c.EnUso,
						 Juicio = c.Juicio,
						 RelevarControl = c.RelevarControl,
						 Ambito = c.Ambito,
						 NotificaPresidenteAudiencia = c.NotificaPresidenteAudiencia,
					};
			return (DbQuery<TiposAudienciaRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
