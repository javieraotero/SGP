
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
	[MetadataTypeAttribute(typeof(CausasReceptoriaMetaData))]
	[Table("CausasReceptoria")]
	public partial class CausasReceptoria
	{
		#region Constructor
		public CausasReceptoria()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Required(ErrorMessage = "Debe ingresar Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Numero")]
		public int Numero { get; set; }

		[Required(ErrorMessage = "Debe ingresar Caratula")]
		[StringLength(455, ErrorMessage ="Caratula no puede superar los 455 caracteres")]
		public string Caratula { get; set; }

		[Required(ErrorMessage = "Debe ingresar Circunscripcion")]
		public int Circunscripcion { get; set; }
		#endregion

	}
}
