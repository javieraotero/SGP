
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
	public partial class CesidaMovimientoAgentesAD
	{
		private BDEntities db = new BDEntities();

		public CesidaMovimientoAgentes ObtenerPorId(int Id)
		{
			return db.CesidaMovimientoAgentes.Single(c => c.Id == Id);
		}

		public DbQuery<CesidaMovimientoAgentes> ObtenerTodo()
		{
			return (DbQuery<CesidaMovimientoAgentes>)db.CesidaMovimientoAgentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.CesidaMovimientoAgentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<CesidaMovimientoAgentesView> ObtenerParaGrilla()
		{
			var x = from c in db.CesidaMovimientoAgentes
					select new CesidaMovimientoAgentesView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Movimiento = c.Movimiento,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 Autorizado = c.Autorizado,
						 MensajeRespuesta = c.MensajeRespuesta,
						 NroLote = c.NroLote,
						 CodOperacion = c.CodOperacion,
						 Persona = c.Persona,
						 FechaEnvio = c.FechaEnvio,
						 FechaAutoriza = c.FechaAutoriza,
						 UsuarioAutoriza = c.UsuarioAutoriza,
					};
			return (DbQuery<CesidaMovimientoAgentesView>)x;
		}

		public void Guardar(CesidaMovimientoAgentes Objeto)
		{
			try
			{
				db.CesidaMovimientoAgentes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(CesidaMovimientoAgentes Objeto)
		{
			try
			{
				db.CesidaMovimientoAgentes.Attach(Objeto);
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
				CesidaMovimientoAgentes Objeto = this.ObtenerPorId(IdObjeto);
				db.CesidaMovimientoAgentes.Remove(Objeto);
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

		public DbQuery<CesidaMovimientoAgentesViewT> JsonT(string term)
		{
			var x = from c in db.CesidaMovimientoAgentes
					select new CesidaMovimientoAgentesViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Movimiento = c.Movimiento,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaAlta = c.FechaAlta,
						 Autorizado = c.Autorizado,
						 MensajeRespuesta = c.MensajeRespuesta,
						 NroLote = c.NroLote,
						 CodOperacion = c.CodOperacion,
						 Persona = c.Persona,
						 FechaEnvio = c.FechaEnvio,
						 FechaAutoriza = c.FechaAutoriza,
						 UsuarioAutoriza = c.UsuarioAutoriza,
					};
			return (DbQuery<CesidaMovimientoAgentesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
