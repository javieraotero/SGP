
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
	[MetadataTypeAttribute(typeof(PersonasDocumentacionMetaData))]
	[Table("PersonasDocumentacion")]
	public partial class PersonasDocumentacion
	{
		#region Constructor
		public PersonasDocumentacion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoDocumentacion")]
		public int TipoDocumentacion { get; set; }

		[StringLength(500, ErrorMessage ="Observaciones no puede superar los 500 caracteres")]
		public string Observaciones { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("TipoDocumentacion")]
		public virtual TiposDocumentacionPersonaRef TipoDocumentacions { get; set; }
		#endregion

	}
}
