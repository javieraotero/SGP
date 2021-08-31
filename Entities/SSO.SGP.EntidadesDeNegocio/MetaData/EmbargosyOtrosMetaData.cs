using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class EmbargosyOtrosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Importe")]
			public decimal? Importe { get; set; }

			[Display(Name = "FechaLevanto")]
			public DateTime? FechaLevanto { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }
			#endregion


	}
}
