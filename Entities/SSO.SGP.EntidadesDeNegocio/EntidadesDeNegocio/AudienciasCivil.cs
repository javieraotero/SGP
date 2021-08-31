
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
	[MetadataTypeAttribute(typeof(AudienciasCivilMetaData))]
	[Table("AudienciasCivil")]
	public partial class AudienciasCivil
	{
		#region Constructor
		public AudienciasCivil()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		public int Tipo { get; set; }

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

		public int? Ambito { get; set; }

		public int? Causa { get; set; }

		public bool? Publicar { get; set; }

		public bool? PublicarSinCaratula { get; set; }

		public bool? NoPublicar { get; set; }

		public bool? SinMediacionPorAusenciaPartes { get; set; }

		public bool? SinMediacionPorDecisionPartes { get; set; }

		public bool? AcuerdoTotalMediacion { get; set; }

		public bool? AcuerdoParcialMediacion { get; set; }

		public bool? SinAcuerdoProvisoriamente { get; set; }

		public bool? SinAcuerdoDefinitivamente { get; set; }

		public bool? CasoNoMediableProvisoriamente { get; set; }

		public bool? CasoNoMediableDefinitivamente { get; set; }

		[StringLength(255, ErrorMessage ="ObservacionesMediacion no puede superar los 255 caracteres")]
		public string ObservacionesMediacion { get; set; }

		public virtual ICollection<AudienciasEstadosCivil> AudienciasEstadosCivilAudiencias { get; set; }

		public virtual ICollection<EventosCivil> EventosCivil { get; set; }

		[ForeignKey("Tipo")]
		public virtual TiposAudienciaCivilRef Tipos { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosAudienciaRef Estados { get; set; }

		[ForeignKey("Sala")]
		public virtual OrganismosRef Salas { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("MotivoCancelacion")]
		public virtual MotivosCancelacionCivilRef MotivoCancelacions { get; set; }

		[ForeignKey("MotivoPostergacion")]
		public virtual MotivosPostergacionCivilRef MotivoPostergacions { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Ambito")]
		public virtual Ambitos Ambitos { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }
		#endregion

	}
}
