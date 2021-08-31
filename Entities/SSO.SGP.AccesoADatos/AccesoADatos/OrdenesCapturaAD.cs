
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
	public partial class OrdenesCapturaAD
	{
		private BDEntities db = new BDEntities();

		public OrdenesCaptura ObtenerPorId(int Id)
		{
			return db.OrdenesCaptura.Single(c => c.Id == Id);
		}

		public DbQuery<OrdenesCaptura> ObtenerTodo()
		{
			return (DbQuery<OrdenesCaptura>)db.OrdenesCaptura;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.OrdenesCaptura
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<OrdenesCapturaView> ObtenerParaGrilla()
		{
			var x = from c in db.OrdenesCaptura
					select new OrdenesCapturaView
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Persona = c.Persona,
						 Observaciones = c.Observaciones,
						 Anulada = c.Anulada,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaAnula = c.FechaAnula,
						 UsuarioAnula = c.UsuarioAnula,
					};
			return (DbQuery<OrdenesCapturaView>)x;
		}

		public void Guardar(OrdenesCaptura Objeto)
		{
			try
			{
				db.OrdenesCaptura.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(OrdenesCaptura Objeto)
		{
			try
			{
				db.OrdenesCaptura.Attach(Objeto);
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
				OrdenesCaptura Objeto = this.ObtenerPorId(IdObjeto);
				db.OrdenesCaptura.Remove(Objeto);
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

		public DbQuery<OrdenesCapturaViewT> JsonT(string term)
		{
			var x = from c in db.OrdenesCaptura
					select new OrdenesCapturaViewT
					{
						 Id = c.Id,
						 Expediente = c.Expediente,
						 Actuacion = c.Actuacion,
						 Persona = c.Persona,
						 Observaciones = c.Observaciones,
						 Anulada = c.Anulada,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 FechaModificacion = c.FechaModificacion,
						 UsuarioModifica = c.UsuarioModifica,
						 FechaAnula = c.FechaAnula,
						 UsuarioAnula = c.UsuarioAnula,
					};
			return (DbQuery<OrdenesCapturaViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
