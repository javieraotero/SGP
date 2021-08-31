
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
	[MetadataTypeAttribute(typeof(CesidaFuncionesRefMetaData))]
	[Table("CesidaFuncionesRef")]
	public partial class CesidaFuncionesRef
	{
		#region Constructor
		public CesidaFuncionesRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? NroConvenio { get; set; }

		public int? NroFuncion { get; set; }

		public string Funcion { get; set; }
		#endregion

	}
}
