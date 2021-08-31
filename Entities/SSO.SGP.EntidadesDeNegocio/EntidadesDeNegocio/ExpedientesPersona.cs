
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
	[MetadataTypeAttribute(typeof(ExpedientesPersonaMetaData))]
	[Table("ExpedientesPersona")]
	public partial class ExpedientesPersona
	{
		#region Constructor
		public ExpedientesPersona()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		public int Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rol")]
		public int Rol { get; set; }

		public int? BarrioReal { get; set; }

		public int? CalleReal { get; set; }

		public int? Calle2Real { get; set; }

		public int? NroReal { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioReal no puede superar los 100 caracteres")]
		public string DomicilioReal { get; set; }

		public int? LocalidadReal { get; set; }

		[StringLength(100, ErrorMessage ="Correo no puede superar los 100 caracteres")]
		public string Correo { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[StringLength(100, ErrorMessage ="Telefono no puede superar los 100 caracteres")]
		public string Telefono { get; set; }

		public int? BarrioProcesal { get; set; }

		public int? CalleProcesal { get; set; }

		public int? NroProcesal { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioProcesal no puede superar los 100 caracteres")]
		public string DomicilioProcesal { get; set; }

		public int? LocalidadProcesal { get; set; }

		public int? RepresentanteLegal { get; set; }

		public int? BarrioRepresentanteLegal { get; set; }

		public int? CalleRepresentanteLegal { get; set; }

		public int? NroRepresentanteLegal { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioRepresentanteLegal no puede superar los 100 caracteres")]
		public string DomicilioRepresentanteLegal { get; set; }

		public int? LocalidadRepresentanteLegal { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public int? DefensorResponsable { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModificacion { get; set; }

		public DateTime? FechaBaja { get; set; }

		public int? UsuarioBaja { get; set; }

		public int? Subrogante { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsColaborador")]
		public bool EsColaborador { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsSustituto")]
		public bool EsSustituto { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsAdHoc")]
		public bool EsAdHoc { get; set; }

		public virtual ICollection<ActuacionesNotificacion> ActuacionesNotificacion { get; set; }

		public virtual ICollection<ActuacionesPersonaDelito> ActuacionesPersonaDelito { get; set; }

		public virtual ICollection<AudienciasImputados> AudienciasImputados { get; set; }

		public virtual ICollection<AudienciasNotificacion> AudienciasNotificacion { get; set; }

		public virtual ICollection<AudienciasSolicitud> AudienciasSolicitud { get; set; }

		//public virtual ICollection<AudienciasSolicitudPersonasRel> AudienciasSolicitudPersonasRel { get; set; }

		public virtual ICollection<ControlPresentaciones> ControlPresentaciones { get; set; }

		public virtual ICollection<ExpedientesDocumento> ExpedientesDocumento { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("Rol")]
		public virtual RolesPersonaRef Rols { get; set; }

		[ForeignKey("BarrioReal")]
		public virtual BarriosRef BarrioReals { get; set; }

		[ForeignKey("CalleReal")]
		public virtual CallesRef CalleReals { get; set; }

		[ForeignKey("Calle2Real")]
		public virtual CallesRef Calle2Reals { get; set; }

		[ForeignKey("LocalidadReal")]
		public virtual LocalidadesRef LocalidadReals { get; set; }

		[ForeignKey("BarrioProcesal")]
		public virtual BarriosRef BarrioProcesals { get; set; }

		[ForeignKey("CalleProcesal")]
		public virtual CallesRef CalleProcesals { get; set; }

		[ForeignKey("LocalidadProcesal")]
		public virtual LocalidadesRef LocalidadProcesals { get; set; }

		[ForeignKey("RepresentanteLegal")]
		public virtual Personas RepresentanteLegals { get; set; }

		[ForeignKey("BarrioRepresentanteLegal")]
		public virtual BarriosRef BarrioRepresentanteLegals { get; set; }

		[ForeignKey("CalleRepresentanteLegal")]
		public virtual CallesRef CalleRepresentanteLegals { get; set; }

		[ForeignKey("LocalidadRepresentanteLegal")]
		public virtual LocalidadesRef LocalidadRepresentanteLegals { get; set; }

		[ForeignKey("DefensorResponsable")]
		public virtual Usuarios DefensorResponsables { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }

		[ForeignKey("UsuarioModificacion")]
		public virtual Usuarios UsuarioModificacions { get; set; }

		[ForeignKey("UsuarioBaja")]
		public virtual Usuarios UsuarioBajas { get; set; }

		[ForeignKey("Subrogante")]
		public virtual Usuarios Subrogantes { get; set; }
		#endregion

	}
}
