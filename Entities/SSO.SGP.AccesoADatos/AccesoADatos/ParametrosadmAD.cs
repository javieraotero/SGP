
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
	public partial class ParametrosadmAD
	{
		private BDEntities db = new BDEntities();

		public Parametrosadm ObtenerPorId(int Id)
		{
			return db.Parametrosadm.Single(c => c.Id == Id);
		}

		public DbQuery<Parametrosadm> ObtenerTodo()
		{
			return (DbQuery<Parametrosadm>)db.Parametrosadm;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Parametrosadm
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ParametrosadmView> ObtenerParaGrilla()
		{
			var x = from c in db.Parametrosadm
					select new ParametrosadmView
					{
						 Id = c.Id,
						 UltimoExpediente = c.UltimoExpediente,
						 UltimaFactura = c.UltimaFactura,
						 UltimoTramite = c.UltimoTramite,
					};
			return (DbQuery<ParametrosadmView>)x;
		}

		public void Guardar(Parametrosadm Objeto)
		{
			try
			{
				db.Parametrosadm.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Parametrosadm Objeto)
		{
			try
			{
				db.Parametrosadm.Attach(Objeto);
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
				Parametrosadm Objeto = this.ObtenerPorId(IdObjeto);
				db.Parametrosadm.Remove(Objeto);
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

		public DbQuery<ParametrosadmViewT> JsonT(string term)
		{
			var x = from c in db.Parametrosadm
					select new ParametrosadmViewT
					{
						 Id = c.Id,
						 UltimoExpediente = c.UltimoExpediente,
						 UltimaFactura = c.UltimaFactura,
						 UltimoTramite = c.UltimoTramite,
					};
			return (DbQuery<ParametrosadmViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
