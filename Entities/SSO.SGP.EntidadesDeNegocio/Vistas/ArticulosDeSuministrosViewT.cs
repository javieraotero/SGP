using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ArticulosDeSuministrosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Codigo")]
			public string Codigo { get; set; }

			[Display(Name = "StockMinimo")]
			public int StockMinimo { get; set; }

			[Display(Name = "Stock")]
			public int Stock { get; set; }

			[Display(Name = "UltimoCosto")]
			public decimal? UltimoCosto { get; set; }

			[Display(Name = "FechaUltimoPrecio")]
			public DateTime? FechaUltimoPrecio { get; set; }

			[Display(Name = "FechaDeBaja")]
			public DateTime? FechaDeBaja { get; set; }
			#endregion


	}
}
