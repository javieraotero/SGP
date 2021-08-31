using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Numero")]
			public int Numero { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "FechaIngreso")]
			public DateTime FechaIngreso { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "TipoOrigen")]
			public int TipoOrigen { get; set; }

			[Display(Name = "Preventivo")]
			public int? Preventivo { get; set; }

			[Display(Name = "AutoresIgnorados")]
			public bool AutoresIgnorados { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaInicioPlazo")]
			public DateTime FechaInicioPlazo { get; set; }

			[Display(Name = "VictimaDesconocida")]
			public bool VictimaDesconocida { get; set; }

			[Display(Name = "FechaUltimaModificacion")]
			public DateTime? FechaUltimaModificacion { get; set; }

			[Display(Name = "FechaFinalizaEtapaPreparatoria")]
			public DateTime? FechaFinalizaEtapaPreparatoria { get; set; }

			[Display(Name = "Oficina")]
			public int Oficina { get; set; }

			[Display(Name = "FiscalOficio")]
			public int? FiscalOficio { get; set; }

			[Display(Name = "DefensaPublica")]
			public bool DefensaPublica { get; set; }

			[Display(Name = "AccionPublica")]
			public bool AccionPublica { get; set; }

			[Display(Name = "FiscalResponsable")]
			public int? FiscalResponsable { get; set; }

			[Display(Name = "JuezResponsable")]
			public int? JuezResponsable { get; set; }

			[Display(Name = "ExpedienteAcumulado")]
			public int? ExpedienteAcumulado { get; set; }

			[Display(Name = "FechaAcumulacion")]
			public DateTime? FechaAcumulacion { get; set; }

			[Display(Name = "UsuarioAcumulacion")]
			public int? UsuarioAcumulacion { get; set; }

			[Display(Name = "SecretoSumario")]
			public bool SecretoSumario { get; set; }

			[Display(Name = "CircunscripcionRadicacion")]
			public int CircunscripcionRadicacion { get; set; }

			[Display(Name = "Categoria")]
			public int? Categoria { get; set; }

			[Display(Name = "Bloqueado")]
			public bool? Bloqueado { get; set; }

			[Display(Name = "UsuarioBloquea")]
			public int? UsuarioBloquea { get; set; }

			[Display(Name = "FechaBloqueo")]
			public DateTime? FechaBloqueo { get; set; }

			[Display(Name = "FiscalGeneral")]
			public int? FiscalGeneral { get; set; }

			[Display(Name = "JuezAudienciaResponsable1")]
			public int? JuezAudienciaResponsable1 { get; set; }

			[Display(Name = "JuezAudienciaResponsable2")]
			public int? JuezAudienciaResponsable2 { get; set; }

			[Display(Name = "JuezAudienciaResponsable3")]
			public int? JuezAudienciaResponsable3 { get; set; }

			[Display(Name = "ExpedienteIncidente")]
			public int? ExpedienteIncidente { get; set; }

			[Display(Name = "NumeroIncidente")]
			public int? NumeroIncidente { get; set; }

			[Display(Name = "ComisariaPreventivo")]
			public int? ComisariaPreventivo { get; set; }

			[Display(Name = "FechaHechoPreventivo")]
			public DateTime? FechaHechoPreventivo { get; set; }

			[Display(Name = "Reservado")]
			public bool Reservado { get; set; }

			[Display(Name = "UsuarioReservado")]
			public int? UsuarioReservado { get; set; }

			[Display(Name = "FechaReservado")]
			public DateTime? FechaReservado { get; set; }

			[Display(Name = "RequiereFiscal")]
			public bool RequiereFiscal { get; set; }

			[Display(Name = "RequiereJuez")]
			public bool RequiereJuez { get; set; }

			[Display(Name = "RequiereDefensor")]
			public bool RequiereDefensor { get; set; }

			[Display(Name = "FechaFinSecretoSumario")]
			public DateTime? FechaFinSecretoSumario { get; set; }

			[Display(Name = "FiscalAdjuntoResponsable")]
			public int? FiscalAdjuntoResponsable { get; set; }

			[Display(Name = "JuezAudienciaPresidenteResponsable")]
			public int? JuezAudienciaPresidenteResponsable { get; set; }

			[Display(Name = "Delitos")]
			public string Delitos { get; set; }

			[Display(Name = "ControloFormalizacion")]
			public bool? ControloFormalizacion { get; set; }

			[Display(Name = "FechaControloFormalizacion")]
			public DateTime? FechaControloFormalizacion { get; set; }

			[Display(Name = "UsuarioControloFormalizacion")]
			public int? UsuarioControloFormalizacion { get; set; }

			[Display(Name = "ControloFormalizacionJuezControl")]
			public bool? ControloFormalizacionJuezControl { get; set; }

			[Display(Name = "FechaControloFormalizacionJuezControl")]
			public DateTime? FechaControloFormalizacionJuezControl { get; set; }

			[Display(Name = "UsuarioControloFormalizacionJuezControl")]
			public int? UsuarioControloFormalizacionJuezControl { get; set; }

			[Display(Name = "Archivado")]
			public bool Archivado { get; set; }

			[Display(Name = "OficinaArchivado")]
			public int? OficinaArchivado { get; set; }

			[Display(Name = "UsuarioArchivado")]
			public int? UsuarioArchivado { get; set; }

			[Display(Name = "FechaArchivado")]
			public DateTime? FechaArchivado { get; set; }

			[Display(Name = "ConfirmadoArchivado")]
			public bool ConfirmadoArchivado { get; set; }

			[Display(Name = "TipoArchivado")]
			public int? TipoArchivado { get; set; }

			[Display(Name = "FojasArchivado")]
			public int? FojasArchivado { get; set; }

			[Display(Name = "SoloSumariantes")]
			public bool SoloSumariantes { get; set; }

			[Display(Name = "FechaSoloSumariantes")]
			public DateTime? FechaSoloSumariantes { get; set; }
			#endregion


	}
}
