
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
	public partial class ExpedientesAD
	{
		private BDEntities db = new BDEntities();

		public Expedientes ObtenerPorId(int Id)
		{
			return db.Expedientes.Single(c => c.Id == Id);
		}

		public DbQuery<Expedientes> ObtenerTodo()
		{
			return (DbQuery<Expedientes>)db.Expedientes;
		}

		public DbQuery<SelectOptionsView> ObtenerOptions(string filtro)
		{
			var res = from x in db.Expedientes
				select new SelectOptionsView {text = SqlFunctions.StringConvert((double)x.Id), value = x.Id };
			return (DbQuery<SelectOptionsView>)res;
		}

		public DbQuery<ExpedientesView> ObtenerParaGrilla()
		{
			var x = from c in db.Expedientes
					select new ExpedientesView
					{
						 Id = c.Id,
						 Circunscripcion = c.Circunscripcion,
						 Numero = c.Numero,
						 Caratula = c.Caratula,
						 FechaIngreso = c.FechaIngreso,
						 Estado = c.Estado,
						 Usuario = c.Usuario,
						 TipoOrigen = c.TipoOrigen,
						 Preventivo = c.Preventivo,
						 AutoresIgnorados = c.AutoresIgnorados,
						 Observaciones = c.Observaciones,
						 FechaInicioPlazo = c.FechaInicioPlazo,
						 VictimaDesconocida = c.VictimaDesconocida,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 FechaFinalizaEtapaPreparatoria = c.FechaFinalizaEtapaPreparatoria,
						 Oficina = c.Oficina,
						 FiscalOficio = c.FiscalOficio,
						 DefensaPublica = c.DefensaPublica,
						 AccionPublica = c.AccionPublica,
						 FiscalResponsable = c.FiscalResponsable,
						 JuezResponsable = c.JuezResponsable,
						 ExpedienteAcumulado = c.ExpedienteAcumulado,
						 FechaAcumulacion = c.FechaAcumulacion,
						 UsuarioAcumulacion = c.UsuarioAcumulacion,
						 SecretoSumario = c.SecretoSumario,
						 CircunscripcionRadicacion = c.CircunscripcionRadicacion,
						 Categoria = c.Categoria,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 FiscalGeneral = c.FiscalGeneral,
						 JuezAudienciaResponsable1 = c.JuezAudienciaResponsable1,
						 JuezAudienciaResponsable2 = c.JuezAudienciaResponsable2,
						 JuezAudienciaResponsable3 = c.JuezAudienciaResponsable3,
						 ExpedienteIncidente = c.ExpedienteIncidente,
						 NumeroIncidente = c.NumeroIncidente,
						 ComisariaPreventivo = c.ComisariaPreventivo,
						 FechaHechoPreventivo = c.FechaHechoPreventivo,
						 Reservado = c.Reservado,
						 UsuarioReservado = c.UsuarioReservado,
						 FechaReservado = c.FechaReservado,
						 RequiereFiscal = c.RequiereFiscal,
						 RequiereJuez = c.RequiereJuez,
						 RequiereDefensor = c.RequiereDefensor,
						 FechaFinSecretoSumario = c.FechaFinSecretoSumario,
						 FiscalAdjuntoResponsable = c.FiscalAdjuntoResponsable,
						 JuezAudienciaPresidenteResponsable = c.JuezAudienciaPresidenteResponsable,
						 Delitos = c.Delitos,
						 ControloFormalizacion = c.ControloFormalizacion,
						 FechaControloFormalizacion = c.FechaControloFormalizacion,
						 UsuarioControloFormalizacion = c.UsuarioControloFormalizacion,
						 ControloFormalizacionJuezControl = c.ControloFormalizacionJuezControl,
						 FechaControloFormalizacionJuezControl = c.FechaControloFormalizacionJuezControl,
						 UsuarioControloFormalizacionJuezControl = c.UsuarioControloFormalizacionJuezControl,
						 Archivado = c.Archivado,
						 OficinaArchivado = c.OficinaArchivado,
						 UsuarioArchivado = c.UsuarioArchivado,
						 FechaArchivado = c.FechaArchivado,
						 ConfirmadoArchivado = c.ConfirmadoArchivado,
						 TipoArchivado = c.TipoArchivado,
						 FojasArchivado = c.FojasArchivado,
						 SoloSumariantes = c.SoloSumariantes,
						 FechaSoloSumariantes = c.FechaSoloSumariantes,
					};
			return (DbQuery<ExpedientesView>)x;
		}

		public void Guardar(Expedientes Objeto)
		{
			try
			{
				db.Expedientes.Add(Objeto);
				db.SaveChanges();
			}
			catch (Exception msg)
			{
				Logger.GrabarExcepcion(msg, false);
				throw new Exception(msg.Message);
			}
		}

		public void Actualizar(Expedientes Objeto)
		{
			try
			{
				db.Expedientes.Attach(Objeto);
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
				Expedientes Objeto = this.ObtenerPorId(IdObjeto);
				db.Expedientes.Remove(Objeto);
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

		public DbQuery<ExpedientesViewT> JsonT(string term)
		{
			var x = from c in db.Expedientes
					select new ExpedientesViewT
					{
						 Id = c.Id,
						 Circunscripcion = c.Circunscripcion,
						 Numero = c.Numero,
						 Caratula = c.Caratula,
						 FechaIngreso = c.FechaIngreso,
						 Estado = c.Estado,
						 Usuario = c.Usuario,
						 TipoOrigen = c.TipoOrigen,
						 Preventivo = c.Preventivo,
						 AutoresIgnorados = c.AutoresIgnorados,
						 Observaciones = c.Observaciones,
						 FechaInicioPlazo = c.FechaInicioPlazo,
						 VictimaDesconocida = c.VictimaDesconocida,
						 FechaUltimaModificacion = c.FechaUltimaModificacion,
						 FechaFinalizaEtapaPreparatoria = c.FechaFinalizaEtapaPreparatoria,
						 Oficina = c.Oficina,
						 FiscalOficio = c.FiscalOficio,
						 DefensaPublica = c.DefensaPublica,
						 AccionPublica = c.AccionPublica,
						 FiscalResponsable = c.FiscalResponsable,
						 JuezResponsable = c.JuezResponsable,
						 ExpedienteAcumulado = c.ExpedienteAcumulado,
						 FechaAcumulacion = c.FechaAcumulacion,
						 UsuarioAcumulacion = c.UsuarioAcumulacion,
						 SecretoSumario = c.SecretoSumario,
						 CircunscripcionRadicacion = c.CircunscripcionRadicacion,
						 Categoria = c.Categoria,
						 Bloqueado = c.Bloqueado,
						 UsuarioBloquea = c.UsuarioBloquea,
						 FechaBloqueo = c.FechaBloqueo,
						 FiscalGeneral = c.FiscalGeneral,
						 JuezAudienciaResponsable1 = c.JuezAudienciaResponsable1,
						 JuezAudienciaResponsable2 = c.JuezAudienciaResponsable2,
						 JuezAudienciaResponsable3 = c.JuezAudienciaResponsable3,
						 ExpedienteIncidente = c.ExpedienteIncidente,
						 NumeroIncidente = c.NumeroIncidente,
						 ComisariaPreventivo = c.ComisariaPreventivo,
						 FechaHechoPreventivo = c.FechaHechoPreventivo,
						 Reservado = c.Reservado,
						 UsuarioReservado = c.UsuarioReservado,
						 FechaReservado = c.FechaReservado,
						 RequiereFiscal = c.RequiereFiscal,
						 RequiereJuez = c.RequiereJuez,
						 RequiereDefensor = c.RequiereDefensor,
						 FechaFinSecretoSumario = c.FechaFinSecretoSumario,
						 FiscalAdjuntoResponsable = c.FiscalAdjuntoResponsable,
						 JuezAudienciaPresidenteResponsable = c.JuezAudienciaPresidenteResponsable,
						 Delitos = c.Delitos,
						 ControloFormalizacion = c.ControloFormalizacion,
						 FechaControloFormalizacion = c.FechaControloFormalizacion,
						 UsuarioControloFormalizacion = c.UsuarioControloFormalizacion,
						 ControloFormalizacionJuezControl = c.ControloFormalizacionJuezControl,
						 FechaControloFormalizacionJuezControl = c.FechaControloFormalizacionJuezControl,
						 UsuarioControloFormalizacionJuezControl = c.UsuarioControloFormalizacionJuezControl,
						 Archivado = c.Archivado,
						 OficinaArchivado = c.OficinaArchivado,
						 UsuarioArchivado = c.UsuarioArchivado,
						 FechaArchivado = c.FechaArchivado,
						 ConfirmadoArchivado = c.ConfirmadoArchivado,
						 TipoArchivado = c.TipoArchivado,
						 FojasArchivado = c.FojasArchivado,
						 SoloSumariantes = c.SoloSumariantes,
						 FechaSoloSumariantes = c.FechaSoloSumariantes,
					};
			return (DbQuery<ExpedientesViewT>)x;
		}
		/*********************************************
		* Seccion Particular
		* *******************************************/


	}
}
