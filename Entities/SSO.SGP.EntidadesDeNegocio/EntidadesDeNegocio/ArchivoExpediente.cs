
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
	[MetadataTypeAttribute(typeof(ArchivoExpedienteMetaData))]
	[Table("ArchivoExpediente")]
	public partial class ArchivoExpediente
	{
		#region Constructor
		public ArchivoExpediente()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fuero")]
		public int Fuero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }

		public int? Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar NroLegajo")]
		[StringLength(50, ErrorMessage ="NroLegajo no puede superar los 50 caracteres")]
		public string NroLegajo { get; set; }

		[StringLength(500, ErrorMessage ="Caratula no puede superar los 500 caracteres")]
		public string Caratula { get; set; }

		[StringLength(60, ErrorMessage ="NroPaquete no puede superar los 60 caracteres")]
		public string NroPaquete { get; set; }

		[StringLength(50, ErrorMessage ="NroEstanteria no puede superar los 50 caracteres")]
		public string NroEstanteria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		public DateTime? FechaProbableExpurgacion { get; set; }

		[StringLength(500, ErrorMessage ="Observaciones no puede superar los 500 caracteres")]
		public string Observaciones { get; set; }

		public int? Fojas { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoEnvio")]
		public int OrganismoEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaEnvio")]
		public DateTime FechaEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar ConfirmadoArchivado")]
		public bool ConfirmadoArchivado { get; set; }

		public int? TipoArchivado { get; set; }

		public bool? CargoArchivo { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar CircunscripcionArchiva")]
		public int CircunscripcionArchiva { get; set; }

		public virtual ICollection<ArchivoExpedientePases> ArchivoExpedientePases { get; set; }

		[ForeignKey("Fuero")]
		public virtual FuerosRef Fueros { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosArchivoExpedienteRef Estados { get; set; }

		[ForeignKey("OrganismoEnvio")]
		public virtual OrganismosRef OrganismoEnvios { get; set; }

		[ForeignKey("TipoArchivado")]
		public virtual TiposArchivadoRef TipoArchivados { get; set; }
		#endregion

	}
}
