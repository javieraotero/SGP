
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
	[MetadataTypeAttribute(typeof(AudienciasSolicitudMetaData))]
	[Table("AudienciasSolicitud")]
	public partial class AudienciasSolicitud
	{
		#region Constructor
		public AudienciasSolicitud()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public int? Solicitante { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoAudiencia")]
		public int TipoAudiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar SolicitaJuez")]
		public bool SolicitaJuez { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		public int? Audiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		public int? Expediente { get; set; }

		public int? ActuacionOriginante { get; set; }

		public virtual ICollection<Audiencias> Audiencias { get; set; }

		[ForeignKey("Solicitante")]
		public virtual ExpedientesPersona Solicitantes { get; set; }

		[ForeignKey("TipoAudiencia")]
		public virtual TiposAudienciaRef TipoAudiencias { get; set; }

		[ForeignKey("Audiencia")]
		public virtual Audiencias Audienciass { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("ActuacionOriginante")]
		public virtual Actuaciones ActuacionOriginantes { get; set; }
		#endregion

	}
}
