
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
	public partial class AudienciasEstadosAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasEstados ObtenerPorId(int Id)
		{
			return db.AudienciasEstados.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasEstados> ObtenerTodo()
		{
			return (DbQuery<AudienciasEstados>)db.AudienciasEstados;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasEstados
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasEstadosView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasEstados
					select new AudienciasEstadosView
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Fecha = c.Fecha,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 Estado = c.Estado,
						 Juez = c.Juez,
						 Juez2 = c.Juez2,
						 Juez3 = c.Juez3,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
					};
			return (DbQuery<AudienciasEstadosView>)x;
		}

		public void Guardar(AudienciasEstados Objeto)
		{
			try
			{
				db.AudienciasEstados.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasEstados Objeto)
		{
			try
			{
				db.AudienciasEstados.Attach(Objeto);
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
				AudienciasEstados Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasEstados.Remove(Objeto);
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

		public DbQuery<AudienciasEstadosViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasEstados
					select new AudienciasEstadosViewT
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Fecha = c.Fecha,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 Estado = c.Estado,
						 Juez = c.Juez,
						 Juez2 = c.Juez2,
						 Juez3 = c.Juez3,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
					};
			return (DbQuery<AudienciasEstadosViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
