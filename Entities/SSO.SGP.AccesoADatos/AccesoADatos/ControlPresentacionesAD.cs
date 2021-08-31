
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
	public partial class ControlPresentacionesAD
	{
		private BDEntities db = new BDEntities();

		public ControlPresentaciones ObtenerPorId(int Id)
		{
			return db.ControlPresentaciones.Single(c => c.Id == Id);
		}

		public DbQuery<ControlPresentaciones> ObtenerTodo()
		{
			return (DbQuery<ControlPresentaciones>)db.ControlPresentaciones;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ControlPresentaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ControlPresentacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.ControlPresentaciones
					select new ControlPresentacionesView
					{
						 Id = c.Id,
						 ExpedientePersona = c.ExpedientePersona,
						 FechaPresentacion = c.FechaPresentacion,
						 Firma = c.Firma,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
					};
			return (DbQuery<ControlPresentacionesView>)x;
		}

		public void Guardar(ControlPresentaciones Objeto)
		{
			try
			{
				db.ControlPresentaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ControlPresentaciones Objeto)
		{
			try
			{
				db.ControlPresentaciones.Attach(Objeto);
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
				ControlPresentaciones Objeto = this.ObtenerPorId(IdObjeto);
				db.ControlPresentaciones.Remove(Objeto);
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

		public DbQuery<ControlPresentacionesViewT> JsonT(string term)
		{
			var x = from c in db.ControlPresentaciones
					select new ControlPresentacionesViewT
					{
						 Id = c.Id,
						 ExpedientePersona = c.ExpedientePersona,
						 FechaPresentacion = c.FechaPresentacion,
						 Firma = c.Firma,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
					};
			return (DbQuery<ControlPresentacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
