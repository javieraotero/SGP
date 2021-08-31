
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
	public partial class AudienciasCivilAD
	{
		private BDEntities db = new BDEntities();

		public AudienciasCivil ObtenerPorId(int Id)
		{
			return db.AudienciasCivil.Single(c => c.Id == Id);
		}

		public DbQuery<AudienciasCivil> ObtenerTodo()
		{
			return (DbQuery<AudienciasCivil>)db.AudienciasCivil;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.AudienciasCivil
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasCivilView> ObtenerParaGrilla()
		{
			var x = from c in db.AudienciasCivil
					select new AudienciasCivilView
					{
						 Id = c.Id,
						 Tipo = c.Tipo,
						 Fecha = c.Fecha,
						 FechaFin = c.FechaFin,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 EsPublica = c.EsPublica,
						 Estado = c.Estado,
						 HoraRealInicio = c.HoraRealInicio,
						 HoraRealFin = c.HoraRealFin,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
						 Circunscripcion = c.Circunscripcion,
						 Ambito = c.Ambito,
						 Causa = c.Causa,
						 Publicar = c.Publicar,
						 PublicarSinCaratula = c.PublicarSinCaratula,
						 NoPublicar = c.NoPublicar,
						 SinMediacionPorAusenciaPartes = c.SinMediacionPorAusenciaPartes,
						 SinMediacionPorDecisionPartes = c.SinMediacionPorDecisionPartes,
						 AcuerdoTotalMediacion = c.AcuerdoTotalMediacion,
						 AcuerdoParcialMediacion = c.AcuerdoParcialMediacion,
						 SinAcuerdoProvisoriamente = c.SinAcuerdoProvisoriamente,
						 SinAcuerdoDefinitivamente = c.SinAcuerdoDefinitivamente,
						 CasoNoMediableProvisoriamente = c.CasoNoMediableProvisoriamente,
						 CasoNoMediableDefinitivamente = c.CasoNoMediableDefinitivamente,
						 ObservacionesMediacion = c.ObservacionesMediacion,
					};
			return (DbQuery<AudienciasCivilView>)x;
		}

		public void Guardar(AudienciasCivil Objeto)
		{
			try
			{
				db.AudienciasCivil.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(AudienciasCivil Objeto)
		{
			try
			{
				db.AudienciasCivil.Attach(Objeto);
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
				AudienciasCivil Objeto = this.ObtenerPorId(IdObjeto);
				db.AudienciasCivil.Remove(Objeto);
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

		public DbQuery<AudienciasCivilViewT> JsonT(string term)
		{
			var x = from c in db.AudienciasCivil
					select new AudienciasCivilViewT
					{
						 Id = c.Id,
						 Tipo = c.Tipo,
						 Fecha = c.Fecha,
						 FechaFin = c.FechaFin,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 EsPublica = c.EsPublica,
						 Estado = c.Estado,
						 HoraRealInicio = c.HoraRealInicio,
						 HoraRealFin = c.HoraRealFin,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
						 Circunscripcion = c.Circunscripcion,
						 Ambito = c.Ambito,
						 Causa = c.Causa,
						 Publicar = c.Publicar,
						 PublicarSinCaratula = c.PublicarSinCaratula,
						 NoPublicar = c.NoPublicar,
						 SinMediacionPorAusenciaPartes = c.SinMediacionPorAusenciaPartes,
						 SinMediacionPorDecisionPartes = c.SinMediacionPorDecisionPartes,
						 AcuerdoTotalMediacion = c.AcuerdoTotalMediacion,
						 AcuerdoParcialMediacion = c.AcuerdoParcialMediacion,
						 SinAcuerdoProvisoriamente = c.SinAcuerdoProvisoriamente,
						 SinAcuerdoDefinitivamente = c.SinAcuerdoDefinitivamente,
						 CasoNoMediableProvisoriamente = c.CasoNoMediableProvisoriamente,
						 CasoNoMediableDefinitivamente = c.CasoNoMediableDefinitivamente,
						 ObservacionesMediacion = c.ObservacionesMediacion,
					};
			return (DbQuery<AudienciasCivilViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
