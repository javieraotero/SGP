
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
	public partial class PeritosAD
	{
		private BDEntities db = new BDEntities();

		public Peritos ObtenerPorId(int Id)
		{
			return db.Peritos.Single(c => c.Id == Id);
		}

		public DbQuery<Peritos> ObtenerTodo()
		{
			return (DbQuery<Peritos>)db.Peritos.Where(c => c.Activo == true);
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Peritos
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<PeritosView> ObtenerParaGrilla()
		{
			var x = from c in db.Peritos
					where c.Activo == true
					select new PeritosView
					{
						 Id = c.Id,
						 Universidad = c.Universidad,
						 FechaTitulo = c.FechaTitulo,
						 EstaSuspendido = c.EstaSuspendido,
						 SuspendidoDesde = c.SuspendidoDesde,
						 SuspendidoHasta = c.SuspendidoHasta,
						 Observaciones = c.Observaciones,
						 Sanciones = c.Sanciones,
						 Persona = c.Persona,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosView>)x;
		}

		public void Guardar(Peritos Objeto)
		{
			try
			{
				db.Peritos.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Peritos Objeto)
		{
			try
			{
				db.Peritos.Attach(Objeto);
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
				Peritos Objeto = this.ObtenerPorId(IdObjeto);
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

		public DbQuery<PeritosViewT> JsonT(string term)
		{
			var x = from c in db.Peritos
					where c.Activo == true
					select new PeritosViewT
					{
						 Id = c.Id,
						 Universidad = c.Universidad,
						 FechaTitulo = c.FechaTitulo,
						 EstaSuspendido = c.EstaSuspendido,
						 SuspendidoDesde = c.SuspendidoDesde,
						 SuspendidoHasta = c.SuspendidoHasta,
						 Observaciones = c.Observaciones,
						 Sanciones = c.Sanciones,
						 Persona = c.Persona,
						 Activo = c.Activo,
					};
			return (DbQuery<PeritosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
