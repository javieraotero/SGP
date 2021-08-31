
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(ExpedientesMetaData))]
	[Table("Expedientes")]
	public partial class Expedientes
	{
		#region Constructor
		public Expedientes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numero")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Caratula")]
		[StringLength(500, ErrorMessage ="Caratula no puede superar los 500 caracteres")]
		public string Caratula { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaIngreso")]
		public DateTime FechaIngreso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoOrigen")]
		public int TipoOrigen { get; set; }

		public int? Preventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar AutoresIgnorados")]
		public bool AutoresIgnorados { get; set; }

		[StringLength(8000, ErrorMessage ="Observaciones no puede superar los 8000 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInicioPlazo")]
		public DateTime FechaInicioPlazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar VictimaDesconocida")]
		public bool VictimaDesconocida { get; set; }

		public DateTime? FechaUltimaModificacion { get; set; }

		public DateTime? FechaFinalizaEtapaPreparatoria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Oficina")]
		public int Oficina { get; set; }

		public int? FiscalOficio { get; set; }

		[Required(ErrorMessage = "Debe ingresar DefensaPublica")]
		public bool DefensaPublica { get; set; }

		[Required(ErrorMessage = "Debe ingresar AccionPublica")]
		public bool AccionPublica { get; set; }

		public int? FiscalResponsable { get; set; }

		public int? JuezResponsable { get; set; }

		public int? ExpedienteAcumulado { get; set; }

		public DateTime? FechaAcumulacion { get; set; }

		public int? UsuarioAcumulacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar SecretoSumario")]
		public bool SecretoSumario { get; set; }

		[Required(ErrorMessage = "Debe ingresar CircunscripcionRadicacion")]
		public int CircunscripcionRadicacion { get; set; }

		public int? Categoria { get; set; }

		public bool? Bloqueado { get; set; }

		public int? UsuarioBloquea { get; set; }

		public DateTime? FechaBloqueo { get; set; }

		public int? FiscalGeneral { get; set; }

		public int? JuezAudienciaResponsable1 { get; set; }

		public int? JuezAudienciaResponsable2 { get; set; }

		public int? JuezAudienciaResponsable3 { get; set; }

		public int? ExpedienteIncidente { get; set; }

		public int? NumeroIncidente { get; set; }

		public int? ComisariaPreventivo { get; set; }

		public DateTime? FechaHechoPreventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Reservado")]
		public bool Reservado { get; set; }

		public int? UsuarioReservado { get; set; }

		public DateTime? FechaReservado { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereFiscal")]
		public bool RequiereFiscal { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereJuez")]
		public bool RequiereJuez { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereDefensor")]
		public bool RequiereDefensor { get; set; }

		public DateTime? FechaFinSecretoSumario { get; set; }

		public int? FiscalAdjuntoResponsable { get; set; }

		public int? JuezAudienciaPresidenteResponsable { get; set; }

		[StringLength(500, ErrorMessage ="Delitos no puede superar los 500 caracteres")]
		public string Delitos { get; set; }

		public bool? ControloFormalizacion { get; set; }

		public DateTime? FechaControloFormalizacion { get; set; }

		public int? UsuarioControloFormalizacion { get; set; }

		public bool? ControloFormalizacionJuezControl { get; set; }

		public DateTime? FechaControloFormalizacionJuezControl { get; set; }

		public int? UsuarioControloFormalizacionJuezControl { get; set; }

		[Required(ErrorMessage = "Debe ingresar Archivado")]
		public bool Archivado { get; set; }

		public int? OficinaArchivado { get; set; }

		public int? UsuarioArchivado { get; set; }

		public DateTime? FechaArchivado { get; set; }

		[Required(ErrorMessage = "Debe ingresar ConfirmadoArchivado")]
		public bool ConfirmadoArchivado { get; set; }

		public int? TipoArchivado { get; set; }

		public int? FojasArchivado { get; set; }

		[Required(ErrorMessage = "Debe ingresar SoloSumariantes")]
		public bool SoloSumariantes { get; set; }

		public DateTime? FechaSoloSumariantes { get; set; }

		public virtual ICollection<Actuaciones> Actuaciones { get; set; }

		public virtual ICollection<ArchivoExpediente> ArchivoExpediente { get; set; }

		public virtual ICollection<ArchivoExpedientePases> ArchivoExpedientePases { get; set; }

		public virtual ICollection<Audiencias> Audiencias { get; set; }

		public virtual ICollection<AudienciasSolicitud> AudienciasSolicitud { get; set; }

		public virtual ICollection<ElementosSecuestrados> ElementosSecuestrados { get; set; }

		public virtual ICollection<Eventos> Eventos { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosExpedienteRef Estados { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("TipoOrigen")]
		public virtual TiposOrigenExpedienteRef TipoOrigens { get; set; }

		[ForeignKey("Preventivo")]
		public virtual Preventivos Preventivos { get; set; }

		[ForeignKey("Oficina")]
		public virtual OrganismosRef Oficinas { get; set; }

		[ForeignKey("FiscalOficio")]
		public virtual Usuarios FiscalOficios { get; set; }

		[ForeignKey("FiscalResponsable")]
		public virtual Usuarios FiscalResponsables { get; set; }

		[ForeignKey("JuezResponsable")]
		public virtual Usuarios JuezResponsables { get; set; }

		public virtual ICollection<Expedientes> Expedientes2 { get; set; }

		[ForeignKey("UsuarioAcumulacion")]
		public virtual Usuarios UsuarioAcumulacions { get; set; }

		[ForeignKey("CircunscripcionRadicacion")]
		public virtual CircunscripcionesRef CircunscripcionRadicacions { get; set; }

		[ForeignKey("Categoria")]
		public virtual CategoriasRef Categorias { get; set; }

		[ForeignKey("FiscalGeneral")]
		public virtual Usuarios FiscalGenerals { get; set; }

		[ForeignKey("JuezAudienciaResponsable1")]
		public virtual Usuarios JuezAudienciaResponsable1s { get; set; }

		[ForeignKey("JuezAudienciaResponsable2")]
		public virtual Usuarios JuezAudienciaResponsable2s { get; set; }

		[ForeignKey("JuezAudienciaResponsable3")]
		public virtual Usuarios JuezAudienciaResponsable3s { get; set; }

		[ForeignKey("ComisariaPreventivo")]
		public virtual OrganismosRef ComisariaPreventivos { get; set; }

		[ForeignKey("FiscalAdjuntoResponsable")]
		public virtual Usuarios FiscalAdjuntoResponsables { get; set; }

		[ForeignKey("JuezAudienciaPresidenteResponsable")]
		public virtual Usuarios JuezAudienciaPresidenteResponsables { get; set; }

		[ForeignKey("TipoArchivado")]
		public virtual TiposArchivadoRef TipoArchivados { get; set; }
		#endregion

	}
}
