
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
	public partial class AudienciasAD
	{
		private BDEntities db = new BDEntities();

		public Audiencias ObtenerPorId(int Id)
		{
			return db.Audiencias.Single(c => c.Id == Id);
		}

		public DbQuery<Audiencias> ObtenerTodo()
		{
			return (DbQuery<Audiencias>)db.Audiencias;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Audiencias
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<AudienciasView> ObtenerParaGrilla()
		{
			var x = from c in db.Audiencias
					select new AudienciasView
					{
						 Id = c.Id,
						 Tipo = c.Tipo,
						 SolicitudAudiencia = c.SolicitudAudiencia,
						 Fecha = c.Fecha,
						 FechaFin = c.FechaFin,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 EsPublica = c.EsPublica,
						 Estado = c.Estado,
						 Juez = c.Juez,
						 Juez2 = c.Juez2,
						 Juez3 = c.Juez3,
						 EsJuez = c.EsJuez,
						 HoraRealInicio = c.HoraRealInicio,
						 HoraRealFin = c.HoraRealFin,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
						 Circunscripcion = c.Circunscripcion,
						 Recusacion = c.Recusacion,
						 ActividadProcesalDefectuosa = c.ActividadProcesalDefectuosa,
						 SustitucionMedidaCoercion = c.SustitucionMedidaCoercion,
						 SentenciaSobreseimiento = c.SentenciaSobreseimiento,
						 ImpugnacionDecisionJuicio = c.ImpugnacionDecisionJuicio,
						 Ambito = c.Ambito,
						 Expediente = c.Expediente,
						 GesellPositiva = c.GesellPositiva,
						 GesellNegativa = c.GesellNegativa,
						 GesellNoCorresponde = c.GesellNoCorresponde,
						 Publicar = c.Publicar,
						 PublicarSinCaratula = c.PublicarSinCaratula,
						 NoPublicar = c.NoPublicar,
					};
			return (DbQuery<AudienciasView>)x;
		}

		public void Guardar(Audiencias Objeto)
		{
			try
			{
				db.Audiencias.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Audiencias Objeto)
		{
			try
			{
				db.Audiencias.Attach(Objeto);
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
				Audiencias Objeto = this.ObtenerPorId(IdObjeto);
				db.Audiencias.Remove(Objeto);
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

		public DbQuery<AudienciasViewT> JsonT(string term)
		{
			var x = from c in db.Audiencias
					select new AudienciasViewT
					{
						 Id = c.Id,
						 Tipo = c.Tipo,
						 SolicitudAudiencia = c.SolicitudAudiencia,
						 Fecha = c.Fecha,
						 FechaFin = c.FechaFin,
						 HoraInicio = c.HoraInicio,
						 HoraFin = c.HoraFin,
						 EsPublica = c.EsPublica,
						 Estado = c.Estado,
						 Juez = c.Juez,
						 Juez2 = c.Juez2,
						 Juez3 = c.Juez3,
						 EsJuez = c.EsJuez,
						 HoraRealInicio = c.HoraRealInicio,
						 HoraRealFin = c.HoraRealFin,
						 Sala = c.Sala,
						 Observaciones = c.Observaciones,
						 Usuario = c.Usuario,
						 FechaAlta = c.FechaAlta,
						 MotivoCancelacion = c.MotivoCancelacion,
						 MotivoPostergacion = c.MotivoPostergacion,
						 Circunscripcion = c.Circunscripcion,
						 Recusacion = c.Recusacion,
						 ActividadProcesalDefectuosa = c.ActividadProcesalDefectuosa,
						 SustitucionMedidaCoercion = c.SustitucionMedidaCoercion,
						 SentenciaSobreseimiento = c.SentenciaSobreseimiento,
						 ImpugnacionDecisionJuicio = c.ImpugnacionDecisionJuicio,
						 Ambito = c.Ambito,
						 Expediente = c.Expediente,
						 GesellPositiva = c.GesellPositiva,
						 GesellNegativa = c.GesellNegativa,
						 GesellNoCorresponde = c.GesellNoCorresponde,
						 Publicar = c.Publicar,
						 PublicarSinCaratula = c.PublicarSinCaratula,
						 NoPublicar = c.NoPublicar,
					};
			return (DbQuery<AudienciasViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
