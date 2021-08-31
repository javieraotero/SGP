
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
	public partial class SuspensionPlazoAD
	{
		private BDEntities db = new BDEntities();

		public SuspensionPlazo ObtenerPorId(int Id)
		{
			return db.SuspensionPlazo.Single(c => c.Id == Id);
		}

		public DbQuery<SuspensionPlazo> ObtenerTodo()
		{
			return (DbQuery<SuspensionPlazo>)db.SuspensionPlazo;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.SuspensionPlazo
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<SuspensionPlazoView> ObtenerParaGrilla()
		{
			var x = from c in db.SuspensionPlazo
					select new SuspensionPlazoView
					{
						 Id = c.Id,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Observaciones = c.Observaciones,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModificacion = c.FechaModificacion,
					};
			return (DbQuery<SuspensionPlazoView>)x;
		}

		public void Guardar(SuspensionPlazo Objeto)
		{
			try
			{
				db.SuspensionPlazo.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(SuspensionPlazo Objeto)
		{
			try
			{
				db.SuspensionPlazo.Attach(Objeto);
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
				SuspensionPlazo Objeto = this.ObtenerPorId(IdObjeto);
				db.SuspensionPlazo.Remove(Objeto);
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

		public DbQuery<SuspensionPlazoViewT> JsonT(string term)
		{
			var x = from c in db.SuspensionPlazo
					select new SuspensionPlazoViewT
					{
						 Id = c.Id,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Observaciones = c.Observaciones,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModificacion = c.FechaModificacion,
					};
			return (DbQuery<SuspensionPlazoViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
