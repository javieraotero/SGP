
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
	public partial class MovimientosDeAgentesAD
	{
		private BDEntities db = new BDEntities();

		public MovimientosDeAgentes ObtenerPorId(int Id)
		{
			return db.MovimientosDeAgentes.Single(c => c.Id == Id);
		}

		public DbQuery<MovimientosDeAgentes> ObtenerTodo()
		{
			return (DbQuery<MovimientosDeAgentes>)db.MovimientosDeAgentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MovimientosDeAgentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MovimientosDeAgentesView> ObtenerParaGrilla()
		{
			var x = from c in db.MovimientosDeAgentes
					select new MovimientosDeAgentesView
					{
						 Id = c.Id,
						 Nombramiento = c.Nombramiento,
						 NuevoCargo = c.NuevoCargo,
						 Fecha = c.Fecha,
						 NuevoOrganismo = c.NuevoOrganismo,
					};
			return (DbQuery<MovimientosDeAgentesView>)x;
		}

		public void Guardar(MovimientosDeAgentes Objeto)
		{
			try
			{
				db.MovimientosDeAgentes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MovimientosDeAgentes Objeto)
		{
			try
			{
				db.MovimientosDeAgentes.Attach(Objeto);
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
				MovimientosDeAgentes Objeto = this.ObtenerPorId(IdObjeto);
				db.MovimientosDeAgentes.Remove(Objeto);
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

		public DbQuery<MovimientosDeAgentesViewT> JsonT(string term)
		{
			var x = from c in db.MovimientosDeAgentes
					select new MovimientosDeAgentesViewT
					{
						 Id = c.Id,
						 Nombramiento = c.Nombramiento,
						 NuevoCargo = c.NuevoCargo,
						 Fecha = c.Fecha,
						 NuevoOrganismo = c.NuevoOrganismo,
					};
			return (DbQuery<MovimientosDeAgentesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
