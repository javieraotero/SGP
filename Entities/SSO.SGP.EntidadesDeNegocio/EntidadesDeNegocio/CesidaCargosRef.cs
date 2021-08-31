
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
	[MetadataTypeAttribute(typeof(CesidaCargosRefMetaData))]
	[Table("CesidaCargosRef")]
	public partial class CesidaCargosRef
	{
		#region Constructor
		public CesidaCargosRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? NroConvenio { get; set; }

		public string Convenio { get; set; }

		public int? NroRama { get; set; }

		public string Rama { get; set; }

		public int? NroCategoria { get; set; }

		public string Categoria { get; set; }
		#endregion

	}
}
