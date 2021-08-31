
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
	[MetadataTypeAttribute(typeof(CesidaMovimientosAgentesDetallesMetaData))]
	[Table("CesidaMovimientosAgentesDetalles")]
	public partial class CesidaMovimientosAgentesDetalles
	{
		#region Constructor
		public CesidaMovimientosAgentesDetalles()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar MovimientoAgente")]
		public int MovimientoAgente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Parametro")]
		public int Parametro { get; set; }

		public string Valor { get; set; }
		#endregion

	}
}
