
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
	[MetadataTypeAttribute(typeof(CesidaCategoriasMetaData))]
	[Table("CESIDACategorias")]
	public partial class CesidaCategorias
	{
		#region Constructor
		public CesidaCategorias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? NRO_CONVENIO { get; set; }

		public int? NRO_RAMA { get; set; }

		public int? NRO_CATEGORIA { get; set; }

		public string DESCRIPCION { get; set; }
		#endregion

	}
}
