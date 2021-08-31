
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
	[Table("ECO_ProveedoresSubRubroRef")]
	public partial class ECO_ProveedoresSubRubroRef
	{
		#region Constructor
		public ECO_ProveedoresSubRubroRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }
		public int Codigo { get; set; }
		[MaxLength(100)]
		public string Descripcion {get;set;}
		public int Rubro { get; set; }

		[ForeignKey("Rubro")]
		public virtual ECO_ProveedoresRubroRef Rubro_ { get; set; }

		#endregion

	}
}
