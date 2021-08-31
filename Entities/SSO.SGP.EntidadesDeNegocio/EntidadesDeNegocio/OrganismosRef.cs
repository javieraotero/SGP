
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
	[MetadataTypeAttribute(typeof(OrganismosRefMetaData))]
	[Table("OrganismosRef")]
	public partial class OrganismosRef
	{
		#region Constructor
		public OrganismosRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoOrganismo")]
		public int TipoOrganismo { get; set; }

		public int? Localidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Abreviatura")]
		[StringLength(7, ErrorMessage ="Abreviatura no puede superar los 7 caracteres")]
		public string Abreviatura { get; set; }

		public int? DependeDe { get; set; }

		public int? Circunscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar UltimoPreventivo")]
		public int UltimoPreventivo { get; set; }

		[StringLength(100, ErrorMessage ="Domicilio no puede superar los 100 caracteres")]
		public string Domicilio { get; set; }

		[StringLength(100, ErrorMessage ="Telefono no puede superar los 100 caracteres")]
		public string Telefono { get; set; }

		[StringLength(100, ErrorMessage ="HorarioAtencion no puede superar los 100 caracteres")]
		public string HorarioAtencion { get; set; }

		public int? SubAmbito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fuero")]
		public int Fuero { get; set; }

		[StringLength(20, ErrorMessage ="EncabezadoPDF no puede superar los 20 caracteres")]
		public string EncabezadoPDF { get; set; }

		[Required(ErrorMessage = "Debe ingresar ParaNotificaciones")]
		public bool ParaNotificaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar RecibeNotificaciones")]
		public bool RecibeNotificaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar ReceptoriaDeCausas")]
		public bool ReceptoriaDeCausas { get; set; }

        public int? UnidadOrganizacionRRHH { get; set; }

        public int? UbicacionCESIDA { get; set; }

        //public int? ResponsableRRHH { get; set; }

        //public virtual ICollection<Actuaciones> Actuaciones { get; set; }

		//public virtual ICollection<Actuacionesadm> Actuacionesadm { get; sset; }

        //public virtual ICollection<ActuacionesCivil> ActuacionesCivil { get; set; }

        //public virtual ICollection<ActuacionesCivilNotificacion> ActuacionesCivilNotificacion { get; set; }

        //public virtual ICollection<ActuacionesNotificacion> ActuacionesNotificacion { get; set; }

        //public virtual ICollection<Acumulados> Acumulados { get; set; }

        //public virtual ICollection<ArchivoExpediente> ArchivoExpedienteOrganismoEnvio { get; set; }

        //public virtual ICollection<ArchivoExpedientePases> ArchivoExpedientePases { get; set; }

        //public virtual ICollection<ArchivoExpedientePases> ArchivoExpedientePases1 { get; set; }

        //public virtual ICollection<Audiencias> Audiencias { get; set; }

        //public virtual ICollection<AudienciasCivil> AudienciasCivil { get; set; }

        //public virtual ICollection<AudienciasEstados> AudienciasEstados { get; set; }

        //public virtual ICollection<AudienciasEstadosCivil> AudienciasEstadosCivil { get; set; }

        //public virtual ICollection<AudienciasImputados> AudienciasImputados { get; set; }

        //public virtual ICollection<CambiosRadicacion> CambiosRadicacion { get; set; }

        //public virtual ICollection<Causas> Causas { get; set; }

        //public virtual ICollection<Causas> Causas1 { get; set; }

        //public virtual ICollection<Denuncias> Denuncias { get; set; }

        //public virtual ICollection<ElementosSecuestrados> ElementosSecuestrados { get; set; }

        //public virtual ICollection<Eventos> Eventos { get; set; }

        //public virtual ICollection<EventosCivil> EventosCivil { get; set; }

        //public virtual ICollection<Excusaciones> Excusaciones { get; set; }

        //public virtual ICollection<Expedientes> Expedientes { get; set; }

        //public virtual ICollection<Expedientes> Expedientes1 { get; set; }

        //public virtual ICollection<Expedientesadm> Expedientesadm { get; set; }

        //public virtual ICollection<ExpedientesAnotaciones> ExpedientesAnotaciones { get; set; }

		//public virtual ICollection<ExpedientesOficinasRel> ExpedientesOficinasRel { get; set; }

        //public virtual ICollection<ExpedientesPase> ExpedientesPase { get; set; }

        //public virtual ICollection<ExpedientesPase> ExpedientesPase1 { get; set; }

        //public virtual ICollection<ExpedientesPaseadm> ExpedientesPaseadm { get; set; }

        //public virtual ICollection<ExpedientesPersonaDetenida> ExpedientesPersonaDetenida { get; set; }

        //public virtual ICollection<ModelosEscrito> ModelosEscrito { get; set; }

        //public virtual ICollection<MovimientosDeAgentes> MovimientosDeAgentes { get; set; }

        public virtual ICollection<Nombramientos> Nombramientos { get; set; }

        //[InverseProperty("Organismos")]
        //public virtual ICollection<Sustituciones> Sustituciones { get; set; }

        //public virtual ICollection<Notificaciones> Notificaciones { get; set; }

        //public virtual ICollection<NotificacionesCivil> NotificacionesCivil { get; set; }

		[ForeignKey("TipoOrganismo")]
		public virtual TiposOrganismoRef TipoOrganismos { get; set; }

		[ForeignKey("Localidad")]
		public virtual LocalidadesRef Localidads { get; set; }

        //public virtual ICollection<OrganismosRef> OrganismosRef1 { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("SubAmbito")]
		public virtual Ambitos SubAmbitos { get; set; }

		[ForeignKey("Fuero")]
		public virtual FuerosRef Fueros { get; set; }
		#endregion

	}
}
