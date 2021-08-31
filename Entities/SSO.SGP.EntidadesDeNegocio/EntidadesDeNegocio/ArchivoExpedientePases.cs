
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
	[MetadataTypeAttribute(typeof(ArchivoExpedientePasesMetaData))]
	[Table("ArchivoExpedientePases")]
	public partial class ArchivoExpedientePases
	{
		#region Constructor
		public ArchivoExpedientePases()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Expediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoEnvio")]
		public int OrganismoEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioEnvio")]
		public int UsuarioEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaEnvio")]
		public DateTime FechaEnvio { get; set; }

		[Required(ErrorMessage = "Debe ingresar OrganismoRecepcion")]
		public int OrganismoRecepcion { get; set; }

		public int? UsuarioRecepcion { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Recibido")]
		public bool Recibido { get; set; }

		public int? PaseAnterior { get; set; }

		public int? PaseSiguiente { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar ArchivoExpediente")]
		public int ArchivoExpediente { get; set; }

		public virtual ICollection<ArchivoExpedientePases> ArchivoExpedientePasess { get; set; }

		public virtual ICollection<ArchivoExpedientePases> ArchivoExpedientePases1 { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("OrganismoEnvio")]
		public virtual OrganismosRef OrganismoEnvios { get; set; }

		[ForeignKey("UsuarioEnvio")]
		public virtual Usuarios UsuarioEnvios { get; set; }

		[ForeignKey("OrganismoRecepcion")]
		public virtual OrganismosRef OrganismoRecepcions { get; set; }

		[ForeignKey("UsuarioRecepcion")]
		public virtual Usuarios UsuarioRecepcions { get; set; }

		[ForeignKey("ArchivoExpediente")]
		public virtual ArchivoExpediente ArchivoExpedientes { get; set; }
		#endregion

	}
}
