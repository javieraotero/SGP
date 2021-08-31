
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
	public partial class ExpedientesPersonaAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesPersona ObtenerPorId(int Id)
		{
			return db.ExpedientesPersona.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesPersona> ObtenerTodo()
		{
			return (DbQuery<ExpedientesPersona>)db.ExpedientesPersona.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesPersona
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesPersonaView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesPersona
					where c.Activo == true
					select new ExpedientesPersonaView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Persona = c.Persona,
						 Rol = c.Rol,
						 BarrioReal = c.BarrioReal,
						 CalleReal = c.CalleReal,
						 Calle2Real = c.Calle2Real,
						 NroReal = c.NroReal,
						 DomicilioReal = c.DomicilioReal,
						 LocalidadReal = c.LocalidadReal,
						 Correo = c.Correo,
						 Observaciones = c.Observaciones,
						 Telefono = c.Telefono,
						 BarrioProcesal = c.BarrioProcesal,
						 CalleProcesal = c.CalleProcesal,
						 NroProcesal = c.NroProcesal,
						 DomicilioProcesal = c.DomicilioProcesal,
						 LocalidadProcesal = c.LocalidadProcesal,
						 RepresentanteLegal = c.RepresentanteLegal,
						 BarrioRepresentanteLegal = c.BarrioRepresentanteLegal,
						 CalleRepresentanteLegal = c.CalleRepresentanteLegal,
						 NroRepresentanteLegal = c.NroRepresentanteLegal,
						 DomicilioRepresentanteLegal = c.DomicilioRepresentanteLegal,
						 LocalidadRepresentanteLegal = c.LocalidadRepresentanteLegal,
						 Confirmado = c.Confirmado,
						 Activo = c.Activo,
						 DefensorResponsable = c.DefensorResponsable,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaBaja = c.FechaBaja,
						 UsuarioBaja = c.UsuarioBaja,
						 Subrogante = c.Subrogante,
						 EsColaborador = c.EsColaborador,
						 EsSustituto = c.EsSustituto,
						 EsAdHoc = c.EsAdHoc,
					};
			return (DbQuery<ExpedientesPersonaView>)x;
		}

		public void Guardar(ExpedientesPersona Objeto)
		{
			try
			{
				db.ExpedientesPersona.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPersona Objeto)
		{
			try
			{
				db.ExpedientesPersona.Attach(Objeto);
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
				ExpedientesPersona Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
				Objeto.FechaBaja = DateTime.Now;
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

		public DbQuery<ExpedientesPersonaViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesPersona
					where c.Activo == true
					select new ExpedientesPersonaViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Persona = c.Persona,
						 Rol = c.Rol,
						 BarrioReal = c.BarrioReal,
						 CalleReal = c.CalleReal,
						 Calle2Real = c.Calle2Real,
						 NroReal = c.NroReal,
						 DomicilioReal = c.DomicilioReal,
						 LocalidadReal = c.LocalidadReal,
						 Correo = c.Correo,
						 Observaciones = c.Observaciones,
						 Telefono = c.Telefono,
						 BarrioProcesal = c.BarrioProcesal,
						 CalleProcesal = c.CalleProcesal,
						 NroProcesal = c.NroProcesal,
						 DomicilioProcesal = c.DomicilioProcesal,
						 LocalidadProcesal = c.LocalidadProcesal,
						 RepresentanteLegal = c.RepresentanteLegal,
						 BarrioRepresentanteLegal = c.BarrioRepresentanteLegal,
						 CalleRepresentanteLegal = c.CalleRepresentanteLegal,
						 NroRepresentanteLegal = c.NroRepresentanteLegal,
						 DomicilioRepresentanteLegal = c.DomicilioRepresentanteLegal,
						 LocalidadRepresentanteLegal = c.LocalidadRepresentanteLegal,
						 Confirmado = c.Confirmado,
						 Activo = c.Activo,
						 DefensorResponsable = c.DefensorResponsable,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModificacion = c.UsuarioModificacion,
						 FechaBaja = c.FechaBaja,
						 UsuarioBaja = c.UsuarioBaja,
						 Subrogante = c.Subrogante,
						 EsColaborador = c.EsColaborador,
						 EsSustituto = c.EsSustituto,
						 EsAdHoc = c.EsAdHoc,
					};
			return (DbQuery<ExpedientesPersonaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
