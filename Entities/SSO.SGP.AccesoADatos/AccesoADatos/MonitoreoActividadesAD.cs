
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
	public partial class MonitoreoActividadesAD
	{
		private BDEntities db = new BDEntities();

		public MonitoreoActividades ObtenerPorId(int Id)
		{
			return db.MonitoreoActividades.Single(c => c.Id == Id);
		}

		public DbQuery<MonitoreoActividades> ObtenerTodo()
		{
			return (DbQuery<MonitoreoActividades>)db.MonitoreoActividades;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.MonitoreoActividades
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<MonitoreoActividadesView> ObtenerParaGrilla()
		{
			var x = from c in db.MonitoreoActividades
					select new MonitoreoActividadesView
					{
						 Id = c.Id,
						 FechaInicio = c.FechaInicio,
						 FechaIntervencion = c.FechaIntervencion,
						 Citacion = c.Citacion,
						 FechaCitacion = c.FechaCitacion,
						 Persona = c.Persona,
						 Expediente = c.Expediente,
						 Circunscripcion = c.Circunscripcion,
						 Derivacion1 = c.Derivacion1,
						 Derivacion2 = c.Derivacion2,
						 Derivacion3 = c.Derivacion3,
						 ViolenciaGenero = c.ViolenciaGenero,
						 AbusoSexualIntraFamiliar = c.AbusoSexualIntraFamiliar,
						 AbusoSexualExtraFamiliar = c.AbusoSexualExtraFamiliar,
						 AbusoSexualInfantilIntraFamiliar = c.AbusoSexualInfantilIntraFamiliar,
						 AbusoSexualInfantilExtraFamiliar = c.AbusoSexualInfantilExtraFamiliar,
						 MaltratoInfantil = c.MaltratoInfantil,
						 TrabajoInfantil = c.TrabajoInfantil,
						 TestigoViolencia = c.TestigoViolencia,
						 ViolenciaFamiliar = c.ViolenciaFamiliar,
						 ViolenciaPareja = c.ViolenciaPareja,
						 SecuelasOtrosTiposDelito = c.SecuelasOtrosTiposDelito,
						 Otros = c.Otros,
						 TotalProblematica = c.TotalProblematica,
						 Intervencion = c.Intervencion,
						 Diagnostico = c.Diagnostico,
						 RiesgoAlto = c.RiesgoAlto,
						 RiesgoMedio = c.RiesgoMedio,
						 RiesgoBajo = c.RiesgoBajo,
						 Seguimiento = c.Seguimiento,
						 TotalInformes = c.TotalInformes,
						 TipoOrigen = c.TipoOrigen,
						 Modalidad = c.Modalidad,
						 AcompanamientoGessel = c.AcompanamientoGessel,
						 AcompanamientoJuicio = c.AcompanamientoJuicio,
						 AcompanamientoOtros = c.AcompanamientoOtros,
						 ArticulacionOtrasInstituciones = c.ArticulacionOtrasInstituciones,
						 IntervencionTecnicaEnJuicio = c.IntervencionTecnicaEnJuicio,
						 IntervencionTecnicaEnAudiencia = c.IntervencionTecnicaEnAudiencia,
						 Consultas = c.Consultas,
						 Monitoreo = c.Monitoreo,
						 EntrevistaDomiciliaria = c.EntrevistaDomiciliaria,
						 TotalIntervenciones = c.TotalIntervenciones,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Activa = c.Activa,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
					};
			return (DbQuery<MonitoreoActividadesView>)x;
		}

		public void Guardar(MonitoreoActividades Objeto)
		{
			try
			{
				db.MonitoreoActividades.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(MonitoreoActividades Objeto)
		{
			try
			{
				db.MonitoreoActividades.Attach(Objeto);
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
				MonitoreoActividades Objeto = this.ObtenerPorId(IdObjeto);
				db.MonitoreoActividades.Remove(Objeto);
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

		public DbQuery<MonitoreoActividadesViewT> JsonT(string term)
		{
			var x = from c in db.MonitoreoActividades
					select new MonitoreoActividadesViewT
					{
						 Id = c.Id,
						 FechaInicio = c.FechaInicio,
						 FechaIntervencion = c.FechaIntervencion,
						 Citacion = c.Citacion,
						 FechaCitacion = c.FechaCitacion,
						 Persona = c.Persona,
						 Expediente = c.Expediente,
						 Circunscripcion = c.Circunscripcion,
						 Derivacion1 = c.Derivacion1,
						 Derivacion2 = c.Derivacion2,
						 Derivacion3 = c.Derivacion3,
						 ViolenciaGenero = c.ViolenciaGenero,
						 AbusoSexualIntraFamiliar = c.AbusoSexualIntraFamiliar,
						 AbusoSexualExtraFamiliar = c.AbusoSexualExtraFamiliar,
						 AbusoSexualInfantilIntraFamiliar = c.AbusoSexualInfantilIntraFamiliar,
						 AbusoSexualInfantilExtraFamiliar = c.AbusoSexualInfantilExtraFamiliar,
						 MaltratoInfantil = c.MaltratoInfantil,
						 TrabajoInfantil = c.TrabajoInfantil,
						 TestigoViolencia = c.TestigoViolencia,
						 ViolenciaFamiliar = c.ViolenciaFamiliar,
						 ViolenciaPareja = c.ViolenciaPareja,
						 SecuelasOtrosTiposDelito = c.SecuelasOtrosTiposDelito,
						 Otros = c.Otros,
						 TotalProblematica = c.TotalProblematica,
						 Intervencion = c.Intervencion,
						 Diagnostico = c.Diagnostico,
						 RiesgoAlto = c.RiesgoAlto,
						 RiesgoMedio = c.RiesgoMedio,
						 RiesgoBajo = c.RiesgoBajo,
						 Seguimiento = c.Seguimiento,
						 TotalInformes = c.TotalInformes,
						 TipoOrigen = c.TipoOrigen,
						 Modalidad = c.Modalidad,
						 AcompanamientoGessel = c.AcompanamientoGessel,
						 AcompanamientoJuicio = c.AcompanamientoJuicio,
						 AcompanamientoOtros = c.AcompanamientoOtros,
						 ArticulacionOtrasInstituciones = c.ArticulacionOtrasInstituciones,
						 IntervencionTecnicaEnJuicio = c.IntervencionTecnicaEnJuicio,
						 IntervencionTecnicaEnAudiencia = c.IntervencionTecnicaEnAudiencia,
						 Consultas = c.Consultas,
						 Monitoreo = c.Monitoreo,
						 EntrevistaDomiciliaria = c.EntrevistaDomiciliaria,
						 TotalIntervenciones = c.TotalIntervenciones,
						 Observaciones = c.Observaciones,
						 FechaAlta = c.FechaAlta,
						 UsuarioAlta = c.UsuarioAlta,
						 Activa = c.Activa,
						 FechaEliminacion = c.FechaEliminacion,
						 UsuarioEliminacion = c.UsuarioEliminacion,
					};
			return (DbQuery<MonitoreoActividadesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
