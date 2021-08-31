
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
	public partial class ExpedientesPersonaadmAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesPersonaadm ObtenerPorId(int Id)
		{
			return db.ExpedientesPersonaadm.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesPersonaadm> ObtenerTodo()
		{
			return (DbQuery<ExpedientesPersonaadm>)db.ExpedientesPersonaadm;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesPersonaadm
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesPersonaadmView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesPersonaadm
					select new ExpedientesPersonaadmView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Persona = c.Persona,
						 Rol = c.Rol,
						 DomicilioReal = c.DomicilioReal,
						 LocalidadReal = c.LocalidadReal,
						 Correo = c.Correo,
						 Observaciones = c.Observaciones,
						 DomicilioRepresentanteLegal = c.DomicilioRepresentanteLegal,
						 NombreRepresentanteLegal = c.NombreRepresentanteLegal,
						 LocalidadRepsentanteLegal = c.LocalidadRepsentanteLegal,
						 CorreoRepresentanteLegal = c.CorreoRepresentanteLegal,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModificacion = c.FechaModificacion,
					};
			return (DbQuery<ExpedientesPersonaadmView>)x;
		}

		public void Guardar(ExpedientesPersonaadm Objeto)
		{
			try
			{
				db.ExpedientesPersonaadm.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPersonaadm Objeto)
		{
			try
			{
				db.ExpedientesPersonaadm.Attach(Objeto);
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
				ExpedientesPersonaadm Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesPersonaadm.Remove(Objeto);
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

		public DbQuery<ExpedientesPersonaadmViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesPersonaadm
					select new ExpedientesPersonaadmViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Persona = c.Persona,
						 Rol = c.Rol,
						 DomicilioReal = c.DomicilioReal,
						 LocalidadReal = c.LocalidadReal,
						 Correo = c.Correo,
						 Observaciones = c.Observaciones,
						 DomicilioRepresentanteLegal = c.DomicilioRepresentanteLegal,
						 NombreRepresentanteLegal = c.NombreRepresentanteLegal,
						 LocalidadRepsentanteLegal = c.LocalidadRepsentanteLegal,
						 CorreoRepresentanteLegal = c.CorreoRepresentanteLegal,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModificacion = c.FechaModificacion,
					};
			return (DbQuery<ExpedientesPersonaadmViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
