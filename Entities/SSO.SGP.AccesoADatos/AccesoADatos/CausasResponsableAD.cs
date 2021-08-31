
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
	public partial class CausasResponsableAD
	{
		private BDEntities db = new BDEntities();

		public CausasResponsable ObtenerPorId(int Id)
		{
			return db.CausasResponsable.Single(c => c.Id == Id);
		}

		public DbQuery<CausasResponsable> ObtenerTodo()
		{
			return (DbQuery<CausasResponsable>)db.CausasResponsable;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CausasResponsable
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CausasResponsableView> ObtenerParaGrilla()
		{
			var x = from c in db.CausasResponsable
					select new CausasResponsableView
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Fecha = c.Fecha,
						 Responsable = c.Responsable,
						 Cargo = c.Cargo,
						 Rol = c.Rol,
						 UsuarioAsignacion = c.UsuarioAsignacion,
						 Observaciones = c.Observaciones,
						 PorSorteo = c.PorSorteo,
					};
			return (DbQuery<CausasResponsableView>)x;
		}

		public void Guardar(CausasResponsable Objeto)
		{
			try
			{
				db.CausasResponsable.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CausasResponsable Objeto)
		{
			try
			{
				db.CausasResponsable.Attach(Objeto);
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
				CausasResponsable Objeto = this.ObtenerPorId(IdObjeto);
				db.CausasResponsable.Remove(Objeto);
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

		public DbQuery<CausasResponsableViewT> JsonT(string term)
		{
			var x = from c in db.CausasResponsable
					select new CausasResponsableViewT
					{
						 Id = c.Id,
						 Causa = c.Causa,
						 Fecha = c.Fecha,
						 Responsable = c.Responsable,
						 Cargo = c.Cargo,
						 Rol = c.Rol,
						 UsuarioAsignacion = c.UsuarioAsignacion,
						 Observaciones = c.Observaciones,
						 PorSorteo = c.PorSorteo,
					};
			return (DbQuery<CausasResponsableViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
