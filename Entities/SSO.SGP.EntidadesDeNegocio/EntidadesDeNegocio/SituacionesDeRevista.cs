
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
	[MetadataTypeAttribute(typeof(SituacionesDeRevistaMetaData))]
	[Table("SituacionesDeRevista")]
	public partial class SituacionesDeRevista
	{
		#region Constructor
		public SituacionesDeRevista()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(20, ErrorMessage ="Descripcion no puede superar los 20 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Abreviatura")]
		[StringLength(2, ErrorMessage ="Abreviatura no puede superar los 2 caracteres")]
		public string Abreviatura { get; set; }
		#endregion

	}
}
