using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class MovimientosDeStockMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Pedido")]
			public int? Pedido { get; set; }

			[Display(Name = "Movimiento")]
			public int Movimiento { get; set; }

			[Display(Name = "Cantidad")]
			public int Cantidad { get; set; }

			[Display(Name = "Articulo")]
			public int Articulo { get; set; }

			[Display(Name = "CausaExpurgue")]
			public string CausaExpurgue { get; set; }

			[Display(Name = "Compra")]
			public int? Compra { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }
			#endregion


	}
}
