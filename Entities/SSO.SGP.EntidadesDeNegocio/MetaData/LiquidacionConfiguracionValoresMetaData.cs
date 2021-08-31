using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class LiquidacionConfiguracionValoresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Liquidacion")]
			public int Liquidacion { get; set; }

			[Display(Name = "Configuracion")]
			public int Configuracion { get; set; }

			[Display(Name = "Valor")]
			public decimal? Valor { get; set; }
			#endregion


	}
}
