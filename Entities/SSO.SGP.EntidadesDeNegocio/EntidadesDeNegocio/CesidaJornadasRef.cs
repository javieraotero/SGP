
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
	[MetadataTypeAttribute(typeof(CesidaJornadasRefMetaData))]
	[Table("CesidaJornadasRef")]
	public partial class CesidaJornadasRef
	{
		#region Constructor
		public CesidaJornadasRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Codigo { get; set; }

		public string Descripcion { get; set; }
		#endregion

	}
}
