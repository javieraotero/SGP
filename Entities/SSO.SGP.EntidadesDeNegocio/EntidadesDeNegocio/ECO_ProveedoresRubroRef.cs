
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
	//[MetadataTypeAttribute(typeof(TurnosWebParametrosMetaData))]
	[Table("ECO_ProveedoresRubroRef")]
	public partial class ECO_ProveedoresRubroRef
	{
		#region Constructor
		public ECO_ProveedoresRubroRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
		[MaxLength(10)]
		public string Codigo { get; set; }
		[MaxLength(100)]
		public string Descripcion {get;set;}

		public eTipoRubro Tipo { get; set; }

		#endregion

	}
}
