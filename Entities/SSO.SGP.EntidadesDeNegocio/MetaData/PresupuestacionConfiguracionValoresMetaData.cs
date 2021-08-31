using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PresupuestacionConfiguracionValoresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Presupuestacion")]
			public int Presupuestacion { get; set; }

			[Display(Name = "Configuracion")]
			public int Configuracion { get; set; }

			[Display(Name = "Valor")]
			public decimal? Valor { get; set; }
			#endregion


	}
}
