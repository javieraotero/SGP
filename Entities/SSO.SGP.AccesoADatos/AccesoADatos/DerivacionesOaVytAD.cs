
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
	public partial class DerivacionesOaVytAD
	{
		private BDEntities db = new BDEntities();

		public DerivacionesOaVyt ObtenerPorId(int Id)
		{
			return db.DerivacionesOaVyt.Single(c => c.Id == Id);
		}

		public DbQuery<DerivacionesOaVyt> ObtenerTodo()
		{
			return (DbQuery<DerivacionesOaVyt>)db.DerivacionesOaVyt;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.DerivacionesOaVyt
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<DerivacionesOaVytView> ObtenerParaGrilla()
		{
			var x = from c in db.DerivacionesOaVyt
					select new DerivacionesOaVytView
					{
						 Id = c.Id,
						 Abreviatura = c.Abreviatura,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<DerivacionesOaVytView>)x;
		}

		public void Guardar(DerivacionesOaVyt Objeto)
		{
			try
			{
				db.DerivacionesOaVyt.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(DerivacionesOaVyt Objeto)
		{
			try
			{
				db.DerivacionesOaVyt.Attach(Objeto);
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
				DerivacionesOaVyt Objeto = this.ObtenerPorId(IdObjeto);
				db.DerivacionesOaVyt.Remove(Objeto);
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

		public DbQuery<DerivacionesOaVytViewT> JsonT(string term)
		{
			var x = from c in db.DerivacionesOaVyt
					select new DerivacionesOaVytViewT
					{
						 Id = c.Id,
						 Abreviatura = c.Abreviatura,
						 Descripcion = c.Descripcion,
					};
			return (DbQuery<DerivacionesOaVytViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
