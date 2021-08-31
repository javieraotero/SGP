
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
	[MetadataTypeAttribute(typeof(AudienciasMetaData))]
	[Table("Audiencias")]
	public partial class Audiencias
	{
		#region Constructor
		public Audiencias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

		public int? SolicitudAudiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public DateTime? FechaFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar HoraInicio")]
		[StringLength(5, ErrorMessage ="HoraInicio no puede superar los 5 caracteres")]
		public string HoraInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar HoraFin")]
		[StringLength(5, ErrorMessage ="HoraFin no puede superar los 5 caracteres")]
		public string HoraFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsPublica")]
		public bool EsPublica { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Juez")]
		public int Juez { get; set; }

		public int? Juez2 { get; set; }

		public int? Juez3 { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsJuez")]
		public bool EsJuez { get; set; }

		[StringLength(5, ErrorMessage ="HoraRealInicio no puede superar los 5 caracteres")]
		public string HoraRealInicio { get; set; }

		[StringLength(5, ErrorMessage ="HoraRealFin no puede superar los 5 caracteres")]
		public string HoraRealFin { get; set; }

		[Required(ErrorMessage = "Debe ingresar Sala")]
		public int Sala { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? MotivoCancelacion { get; set; }

		public int? MotivoPostergacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		public bool? Recusacion { get; set; }

		public bool? ActividadProcesalDefectuosa { get; set; }

		public bool? SustitucionMedidaCoercion { get; set; }

		public bool? SentenciaSobreseimiento { get; set; }

		public bool? ImpugnacionDecisionJuicio { get; set; }

		public int? Ambito { get; set; }

		public int? Expediente { get; set; }

		public bool? GesellPositiva { get; set; }

		public bool? GesellNegativa { get; set; }

		public bool? GesellNoCorresponde { get; set; }

		public bool? Publicar { get; set; }

		public bool? PublicarSinCaratula { get; set; }

		public bool? NoPublicar { get; set; }

		public virtual ICollection<AudienciasDemoras> AudienciasDemoras { get; set; }

		public virtual ICollection<AudienciasEstados> AudienciasEstados { get; set; }

		public virtual ICollection<AudienciasImputados> AudienciasImputados { get; set; }

		public virtual ICollection<AudienciasSolicitud> AudienciasSolicitud { get; set; }

		public virtual ICollection<Eventos> Eventos { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposAudienciaRef Tipos { get; set; }

		[ForeignKey("SolicitudAudiencia")]
		public virtual AudienciasSolicitud SolicitudAudiencias { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosAudienciaRef Estados { get; set; }

		[ForeignKey("Juez")]
		public virtual Usuarios Juezs { get; set; }

		[ForeignKey("Juez2")]
		public virtual Usuarios Juez2s { get; set; }

		[ForeignKey("Juez3")]
		public virtual Usuarios Juez3s { get; set; }

		[ForeignKey("Sala")]
		public virtual OrganismosRef Salas { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("MotivoCancelacion")]
		public virtual MotivosCancelacionRef MotivoCancelacions { get; set; }

		[ForeignKey("MotivoPostergacion")]
		public virtual MotivosPostergacionRef MotivoPostergacions { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }
		#endregion

	}
}
