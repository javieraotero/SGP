
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
	[MetadataTypeAttribute(typeof(CesidaUbicacionesMetaData))]
	[Table("CesidaUbicaciones")]
	public partial class CesidaUbicaciones
	{
		#region Constructor
		public CesidaUbicaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? NUMERO { get; set; }

		public string DESCRIPCION { get; set; }
		#endregion

	}
}
