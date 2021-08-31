
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
	[MetadataTypeAttribute(typeof(TiposDeIngresoDeBienesMetaData))]
	[Table("TiposDeIngresoDeBienes")]
	public partial class TiposDeIngresoDeBienes
	{
		#region Constructor
		public TiposDeIngresoDeBienes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		public string Descripcion { get; set; }
		#endregion

	}
}
