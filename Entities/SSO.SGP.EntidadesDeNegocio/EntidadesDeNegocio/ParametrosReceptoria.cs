
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
	[MetadataTypeAttribute(typeof(ParametrosReceptoriaMetaData))]
	[Table("ParametrosReceptoria")]
	public partial class ParametrosReceptoria
	{
		#region Constructor
		public ParametrosReceptoria()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(50, ErrorMessage ="Descripcion no puede superar los 50 caracteres")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Valor")]
		[StringLength(255, ErrorMessage ="Valor no puede superar los 255 caracteres")]
		public string Valor { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		[StringLength(50, ErrorMessage ="Tipo no puede superar los 50 caracteres")]
		public string Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar ExpresionRegular")]
		[StringLength(50, ErrorMessage ="ExpresionRegular no puede superar los 50 caracteres")]
		public string ExpresionRegular { get; set; }
		#endregion

	}
}
