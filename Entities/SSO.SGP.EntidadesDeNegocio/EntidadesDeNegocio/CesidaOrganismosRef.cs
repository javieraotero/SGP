
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
	[MetadataTypeAttribute(typeof(CesidaOrganismosRefMetaData))]
	[Table("CesidaOrganismosRef")]
	public partial class CesidaOrganismosRef
	{
		#region Constructor
		public CesidaOrganismosRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? CodCaracter { get; set; }

		public string Caracter { get; set; }

		public string CodJurisdiccion { get; set; }

		public string Jurisdiccion { get; set; }

		public int? CodUnidad { get; set; }

		public string Unidad { get; set; }
		#endregion

	}
}
