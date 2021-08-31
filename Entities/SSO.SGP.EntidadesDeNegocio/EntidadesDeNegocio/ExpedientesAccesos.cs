
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
	[MetadataTypeAttribute(typeof(ExpedientesAccesosMetaData))]
	[Table("ExpedientesAccesos")]
	public partial class ExpedientesAccesos
	{
		#region Constructor
		public ExpedientesAccesos()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Expedientes")]
		public int Expedientes { get; set; }

		public int? Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaHora")]
		public DateTime FechaHora { get; set; }
		#endregion

	}
}
