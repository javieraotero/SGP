
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
	public partial class ExpedientesAnotacionesAD
	{
		private BDEntities db = new BDEntities();

		public ExpedientesAnotaciones ObtenerPorId(int Id)
		{
			return db.ExpedientesAnotaciones.Single(c => c.Id == Id);
		}

		public DbQuery<ExpedientesAnotaciones> ObtenerTodo()
		{
			return (DbQuery<ExpedientesAnotaciones>)db.ExpedientesAnotaciones.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.ExpedientesAnotaciones
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesAnotacionesView> ObtenerParaGrilla()
		{
			var x = from c in db.ExpedientesAnotaciones
					where c.Activo == true
					select new ExpedientesAnotacionesView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Titulo = c.Titulo,
						 Fundamento = c.Fundamento,
						 OficinaOrigen = c.OficinaOrigen,
						 SubAmbitoOrigen = c.SubAmbitoOrigen,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
						 FundamentoMax = c.FundamentoMax,
					};
			return (DbQuery<ExpedientesAnotacionesView>)x;
		}

		public void Guardar(ExpedientesAnotaciones Objeto)
		{
			try
			{
				db.ExpedientesAnotaciones.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(ExpedientesAnotaciones Objeto)
		{
			try
			{
				db.ExpedientesAnotaciones.Attach(Objeto);
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
				ExpedientesAnotaciones Objeto = this.ObtenerPorId(IdObjeto);
				Objeto.Activo = false;
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

		public DbQuery<ExpedientesAnotacionesViewT> JsonT(string term)
		{
			var x = from c in db.ExpedientesAnotaciones
					where c.Activo == true
					select new ExpedientesAnotacionesViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Titulo = c.Titulo,
						 Fundamento = c.Fundamento,
						 OficinaOrigen = c.OficinaOrigen,
						 SubAmbitoOrigen = c.SubAmbitoOrigen,
						 Activo = c.Activo,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaModifica = c.FechaModifica,
						 FechaElimina = c.FechaElimina,
						 UsuarioElimina = c.UsuarioElimina,
						 FundamentoMax = c.FundamentoMax,
					};
			return (DbQuery<ExpedientesAnotacionesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
