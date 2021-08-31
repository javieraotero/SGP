using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ArticulosDeSuministrosView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

            [Display(Name = "Nombre", Order = 45)]
			public string Nombre { get; set; }

			[Display(Name = "Codigo", Order=10)]
			public string Codigo { get; set; }

			[Display(Name = "StockMinimo", Order=10)]
			public int StockMinimo { get; set; }

			[Display(Name = "Stock", Order=10)]
			public int Stock { get; set; }

			[Display(Name = "UltimoCosto", Order=10)]
			public decimal? UltimoCosto { get; set; }

            //[Display(Name = "FechaUltimoPrecio", Order=10)]
            //public DateTime? FechaUltimoPrecio { get; set; }

			#endregion


	}
}
