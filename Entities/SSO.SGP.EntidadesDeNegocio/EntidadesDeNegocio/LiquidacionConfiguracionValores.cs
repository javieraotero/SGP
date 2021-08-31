
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
	[MetadataTypeAttribute(typeof(LiquidacionConfiguracionValoresMetaData))]
	[Table("LiquidacionConfiguracionValores")]
	public partial class LiquidacionConfiguracionValores
	{
		#region Constructor
		public LiquidacionConfiguracionValores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Liquidacion")]
		public int Liquidacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Configuracion")]
		public int Configuracion { get; set; }

		public decimal? Valor { get; set; }

		[ForeignKey("Liquidacion")]
		public virtual Liquidacion Liquidacions { get; set; }

		[ForeignKey("Configuracion")]
		public virtual PresupuestacionConfiguracion Configuracions { get; set; }
		#endregion

	}
}
