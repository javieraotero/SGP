
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
	[MetadataTypeAttribute(typeof(NotificacionesMetaData))]
	[Table("Notificaciones")]
	public partial class Notificaciones
	{
		#region Constructor
		public Notificaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expediente")]
		[StringLength(50, ErrorMessage ="Expediente no puede superar los 50 caracteres")]
		public string Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Caratula")]
		[StringLength(500, ErrorMessage ="Caratula no puede superar los 500 caracteres")]
		public string Caratula { get; set; }

		[Required(ErrorMessage = "Debe ingresar JuzgadoOriginante")]
		public int JuzgadoOriginante { get; set; }

		public int? Destinatario { get; set; }

		[StringLength(500, ErrorMessage ="Firmante no puede superar los 500 caracteres")]
		public string Firmante { get; set; }

		[Required(ErrorMessage = "Debe ingresar Sector")]
		public int Sector { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoNotificacion")]
		public int TipoNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar OficialNotificador")]
		public int OficialNotificador { get; set; }

		[Required(ErrorMessage = "Debe ingresar Notificado")]
		public bool Notificado { get; set; }

		public int? Resultado { get; set; }

		[StringLength(500, ErrorMessage ="Observaciones no puede superar los 500 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public DateTime? FechaNotificado { get; set; }

		public int? UsuarioTildoNotificacion { get; set; }

		public int? IDActuacionNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numero")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "Debe ingresar OficialNotifico")]
		public int OficialNotifico { get; set; }

		[StringLength(100, ErrorMessage ="DestinatarioDesdeMyN no puede superar los 100 caracteres")]
		public string DestinatarioDesdeMyN { get; set; }

		[StringLength(200, ErrorMessage ="DomicilioDestinatarioDesdeMyN no puede superar los 200 caracteres")]
		public string DomicilioDestinatarioDesdeMyN { get; set; }

		[StringLength(200, ErrorMessage ="Motivo no puede superar los 200 caracteres")]
		public string Motivo { get; set; }

		public DateTime? FechaBaja { get; set; }

		[Required(ErrorMessage = "Debe ingresar Copias")]
		public bool Copias { get; set; }

		[StringLength(150, ErrorMessage ="FirmaNotificacion no puede superar los 150 caracteres")]
		public string FirmaNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		public int? IdExpediente { get; set; }

		public int? IdActuacionAdjunta { get; set; }

		[StringLength(200, ErrorMessage ="DomicilioDestinatario no puede superar los 200 caracteres")]
		public string DomicilioDestinatario { get; set; }

		public int? IDAudienciaNotificacion { get; set; }

		public virtual ICollection<ActuacionesCivilNotificacion> ActuacionesCivilNotificacion { get; set; }

		public virtual ICollection<ActuacionesNotificacion> ActuacionesNotificacion { get; set; }

		public virtual ICollection<AudienciasNotificacion> AudienciasNotificacion { get; set; }

		[ForeignKey("JuzgadoOriginante")]
		public virtual OrganismosRef JuzgadoOriginantes { get; set; }

		[ForeignKey("Destinatario")]
		public virtual Personas Destinatarios { get; set; }

		[ForeignKey("Sector")]
		public virtual SectoresNotificacion Sectors { get; set; }

		[ForeignKey("TipoNotificacion")]
		public virtual TiposNotificacion TipoNotificacions { get; set; }

		[ForeignKey("OficialNotificador")]
		public virtual Usuarios OficialNotificadors { get; set; }

		[ForeignKey("Resultado")]
		public virtual ResultadosNotificacion Resultados { get; set; }

		[ForeignKey("OficialNotifico")]
		public virtual Usuarios OficialNotificos { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }
		#endregion

	}
}
