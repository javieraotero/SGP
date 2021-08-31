
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
	public partial class ExpedientesPersonaDetenidaAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesPersonaDetenida ObtenerPorId(int Id)
		{
			return db.ExpedientesPersonaDetenida.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesPersonaDetenida> ObtenerTodo()
		{
			return (DbQuery<ExpedientesPersonaDetenida>)db.ExpedientesPersonaDetenida;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesPersonaDetenida
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesPersonaDetenidaView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesPersonaDetenida
					select new ExpedientesPersonaDetenidaView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Persona = c.Persona,
						 LugarDetencion = c.LugarDetencion,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Observaciones = c.Observaciones,
						 Anulada = c.Anulada,
						 MedidaSustitutiva = c.MedidaSustitutiva,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaAnula = c.FechaAnula,
						 UsuarioAnula = c.UsuarioAnula,
						 DenidoPorOficinaJudicial = c.DenidoPorOficinaJudicial,
						 Anulada72HS = c.Anulada72HS,
					};
			return (DbQuery<ExpedientesPersonaDetenidaView>)x;
		}

		public void Guardar(ExpedientesPersonaDetenida Objeto)
		{
			try
			{
				db.ExpedientesPersonaDetenida.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesPersonaDetenida Objeto)
		{
			try
			{
				db.ExpedientesPersonaDetenida.Attach(Objeto);
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
				ExpedientesPersonaDetenida Objeto = this.ObtenerPorId(IdObjeto);
				db.ExpedientesPersonaDetenida.Remove(Objeto);
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

		public DbQuery<ExpedientesPersonaDetenidaViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesPersonaDetenida
					select new ExpedientesPersonaDetenidaViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Persona = c.Persona,
						 LugarDetencion = c.LugarDetencion,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 Observaciones = c.Observaciones,
						 Anulada = c.Anulada,
						 MedidaSustitutiva = c.MedidaSustitutiva,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaAnula = c.FechaAnula,
						 UsuarioAnula = c.UsuarioAnula,
						 DenidoPorOficinaJudicial = c.DenidoPorOficinaJudicial,
						 Anulada72HS = c.Anulada72HS,
					};
			return (DbQuery<ExpedientesPersonaDetenidaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
