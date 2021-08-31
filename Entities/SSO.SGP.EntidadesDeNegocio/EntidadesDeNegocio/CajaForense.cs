
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
	[MetadataTypeAttribute(typeof(CajaForenseMetaData))]
	[Table("CajaForense")]
	public partial class CajaForense
	{
		#region Constructor
		public CajaForense()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Interes")]
		public decimal Interes { get; set; }

		[Required(ErrorMessage = "Debe ingresar InteresAcu")]
		public decimal InteresAcu { get; set; }
		#endregion

	}
}
