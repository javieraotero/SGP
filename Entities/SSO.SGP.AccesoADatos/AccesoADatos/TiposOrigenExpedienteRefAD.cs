
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
	public partial class TiposOrigenExpedienteRefAD
	{
		private BDEntities db = new BDEntities();

		public TiposOrigenExpedienteRef ObtenerPorId(int Id)
		{
			return db.TiposOrigenExpedienteRef.Single(c => c.Id == Id);
		}

		public DbQuery<TiposOrigenExpedienteRef> ObtenerTodo()
		{
			return (DbQuery<TiposOrigenExpedienteRef>)db.TiposOrigenExpedienteRef;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.TiposOrigenExpedienteRef
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<TiposOrigenExpedienteRefView> ObtenerParaGrilla()
		{
			var x = from c in db.TiposOrigenExpedienteRef
					select new TiposOrigenExpedienteRefView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 MostrarEnCaratula = c.MostrarEnCaratula,
						 MostrarEnOficinaJudicial = c.MostrarEnOficinaJudicial,
						 TipoActuacionInicio = c.TipoActuacionInicio,
						 RequiereFiscal = c.RequiereFiscal,
						 RequiereJuez = c.RequiereJuez,
						 RequiereDefensor = c.RequiereDefensor,
					};
			return (DbQuery<TiposOrigenExpedienteRefView>)x;
		}

		public void Guardar(TiposOrigenExpedienteRef Objeto)
		{
			try
			{
				db.TiposOrigenExpedienteRef.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(TiposOrigenExpedienteRef Objeto)
		{
			try
			{
				db.TiposOrigenExpedienteRef.Attach(Objeto);
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
				TiposOrigenExpedienteRef Objeto = this.ObtenerPorId(IdObjeto);
				db.TiposOrigenExpedienteRef.Remove(Objeto);
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

		public DbQuery<TiposOrigenExpedienteRefViewT> JsonT(string term)
		{
			var x = from c in db.TiposOrigenExpedienteRef
					select new TiposOrigenExpedienteRefViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 MostrarEnCaratula = c.MostrarEnCaratula,
						 MostrarEnOficinaJudicial = c.MostrarEnOficinaJudicial,
						 TipoActuacionInicio = c.TipoActuacionInicio,
						 RequiereFiscal = c.RequiereFiscal,
						 RequiereJuez = c.RequiereJuez,
						 RequiereDefensor = c.RequiereDefensor,
					};
			return (DbQuery<TiposOrigenExpedienteRefViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
