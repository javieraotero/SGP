
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
	public partial class AudienciasAnterioresAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasAnteriores ObtenerPorId(int Id)
		{
			return db.AudienciasAnteriores.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasAnteriores> ObtenerTodo()
		{
			return (DbQuery<AudienciasAnteriores>)db.AudienciasAnteriores;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasAnteriores
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasAnterioresView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasAnteriores
					select new AudienciasAnterioresView
					{
						 Id = c.Id,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 DiaDesde = c.DiaDesde,
						 MesDesde = c.MesDesde,
						 AnioDesde = c.AnioDesde,
						 DiaHasta = c.DiaHasta,
						 MesHasta = c.MesHasta,
						 AnioHasta = c.AnioHasta,
						 Agente = c.Agente,
						 Descripcion = c.Descripcion,
						 Activa = c.Activa,
						 FechaAlta = c.FechaAlta,
						 FechaModificacion = c.FechaModificacion,
						 FechaEliminacion = c.FechaEliminacion,
					};
			return (DbQuery<AudienciasAnterioresView>)x;
		}

		public void Guardar(AudienciasAnteriores Objeto)
		{
			try
			{
				db.AudienciasAnteriores.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasAnteriores Objeto)
		{
			try
			{
				db.AudienciasAnteriores.Attach(Objeto);
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
				AudienciasAnteriores Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasAnteriores.Remove(Objeto);
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

		public DbQuery<AudienciasAnterioresViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasAnteriores
					select new AudienciasAnterioresViewT
					{
						 Id = c.Id,
						 FechaDesde = c.FechaDesde,
						 FechaHasta = c.FechaHasta,
						 DiaDesde = c.DiaDesde,
						 MesDesde = c.MesDesde,
						 AnioDesde = c.AnioDesde,
						 DiaHasta = c.DiaHasta,
						 MesHasta = c.MesHasta,
						 AnioHasta = c.AnioHasta,
						 Agente = c.Agente,
						 Descripcion = c.Descripcion,
						 Activa = c.Activa,
						 FechaAlta = c.FechaAlta,
						 FechaModificacion = c.FechaModificacion,
						 FechaEliminacion = c.FechaEliminacion,
					};
			return (DbQuery<AudienciasAnterioresViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
