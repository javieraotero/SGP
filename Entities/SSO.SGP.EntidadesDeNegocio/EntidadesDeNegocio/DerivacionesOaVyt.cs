
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
	[MetadataTypeAttribute(typeof(DerivacionesOaVytMetaData))]
	[Table("DerivacionesOaVyt")]
	public partial class DerivacionesOaVyt
	{
		#region Constructor
		public DerivacionesOaVyt()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Abreviatura")]
		[StringLength(5, ErrorMessage ="Abreviatura no puede superar los 5 caracteres")]
		public string Abreviatura { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }
		#endregion

	}
}
