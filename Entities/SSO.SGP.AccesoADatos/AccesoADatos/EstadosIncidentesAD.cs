
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
	public partial class EstadosIncidentesAD
	{
		private BDEntities db = new BDEntities();

		public EstadosIncidentes ObtenerPorId(int Id)
		{
			return db.EstadosIncidentes.Single(c => c.Id == Id);
		}

		public DbQuery<EstadosIncidentes> ObtenerTodo()
		{
			return (DbQuery<EstadosIncidentes>)db.EstadosIncidentes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EstadosIncidentes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EstadosIncidentesView> ObtenerParaGrilla()
		{
			var x = from c in db.EstadosIncidentes
					select new EstadosIncidentesView
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Icono = c.Icono,
					};
			return (DbQuery<EstadosIncidentesView>)x;
		}

		public void Guardar(EstadosIncidentes Objeto)
		{
			try
			{
				db.EstadosIncidentes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EstadosIncidentes Objeto)
		{
			try
			{
				db.EstadosIncidentes.Attach(Objeto);
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
				EstadosIncidentes Objeto = this.ObtenerPorId(IdObjeto);
				db.EstadosIncidentes.Remove(Objeto);
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

		public DbQuery<EstadosIncidentesViewT> JsonT(string term)
		{
			var x = from c in db.EstadosIncidentes
					select new EstadosIncidentesViewT
					{
						 Id = c.Id,
						 Descripcion = c.Descripcion,
						 Icono = c.Icono,
					};
			return (DbQuery<EstadosIncidentesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
