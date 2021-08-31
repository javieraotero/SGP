
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
	[MetadataTypeAttribute(typeof(CesidaValoresDeParametrosMetaData))]
	[Table("CesidaValoresDeParametros")]
	public partial class CesidaValoresDeParametros
	{
		#region Constructor
		public CesidaValoresDeParametros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Parametro { get; set; }

		public string Valor { get; set; }

        public int? Movimiento { get; set; }

		#endregion

	}
}
