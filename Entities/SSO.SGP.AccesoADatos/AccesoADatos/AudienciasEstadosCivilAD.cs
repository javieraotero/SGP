
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
	public partial class AudienciasEstadosCivilAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasEstadosCivil ObtenerPorId(int Id)
		{
			return db.AudienciasEstadosCivil.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasEstadosCivil> ObtenerTodo()
		{
			return (DbQuery<AudienciasEstadosCivil>)db.AudienciasEstadosCivil;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasEstadosCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasEstadosCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasEstadosCivil
					select new AudienciasEstadosCivilView
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Fecha = c.Fecha,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 Estado = c.Estado,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
					};
			return (DbQuery<AudienciasEstadosCivilView>)x;
		}

		public void Guardar(AudienciasEstadosCivil Objeto)
		{
			try
			{
				db.AudienciasEstadosCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasEstadosCivil Objeto)
		{
			try
			{
				db.AudienciasEstadosCivil.Attach(Objeto);
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
				AudienciasEstadosCivil Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasEstadosCivil.Remove(Objeto);
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

		public DbQuery<AudienciasEstadosCivilViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasEstadosCivil
					select new AudienciasEstadosCivilViewT
					{
						 Id = c.Id,
						 Audiencia = c.Audiencia,
						 Fecha = c.Fecha,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 Estado = c.Estado,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
					};
			return (DbQuery<AudienciasEstadosCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
