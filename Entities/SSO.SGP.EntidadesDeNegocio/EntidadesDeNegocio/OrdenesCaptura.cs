
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
	[MetadataTypeAttribute(typeof(OrdenesCapturaMetaData))]
	[Table("OrdenesCaptura")]
	public partial class OrdenesCaptura
	{
		#region Constructor
		public OrdenesCaptura()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Expediente { get; set; }

		public int? Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anulada")]
		public bool Anulada { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaAnula { get; set; }

		public int? UsuarioAnula { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuaciones Actuacions { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }
		#endregion

	}
}
