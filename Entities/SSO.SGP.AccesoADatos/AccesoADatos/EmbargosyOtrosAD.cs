
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
	public partial class EmbargosyOtrosAD
	{
		private BDEntities db = new BDEntities();

		public EmbargosyOtros ObtenerPorId(int Id)
		{
			return db.EmbargosyOtros.Single(c => c.Id == Id);
		}

		public DbQuery<EmbargosyOtros> ObtenerTodo()
		{
			return (DbQuery<EmbargosyOtros>)db.EmbargosyOtros;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.EmbargosyOtros
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<EmbargosyOtrosView> ObtenerParaGrilla()
		{
			var x = from c in db.EmbargosyOtros
					select new EmbargosyOtrosView
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 Importe = c.Importe,
						 FechaLevanto = c.FechaLevanto,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<EmbargosyOtrosView>)x;
		}

		public void Guardar(EmbargosyOtros Objeto)
		{
			try
			{
				db.EmbargosyOtros.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(EmbargosyOtros Objeto)
		{
			try
			{
				db.EmbargosyOtros.Attach(Objeto);
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
				EmbargosyOtros Objeto = this.ObtenerPorId(IdObjeto);
				db.EmbargosyOtros.Remove(Objeto);
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

		public DbQuery<EmbargosyOtrosViewT> JsonT(string term)
		{
			var x = from c in db.EmbargosyOtros
					select new EmbargosyOtrosViewT
					{
						 Id = c.Id,
						 Agente = c.Agente,
						 Fecha = c.Fecha,
						 Importe = c.Importe,
						 FechaLevanto = c.FechaLevanto,
						 Observaciones = c.Observaciones,
					};
			return (DbQuery<EmbargosyOtrosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
