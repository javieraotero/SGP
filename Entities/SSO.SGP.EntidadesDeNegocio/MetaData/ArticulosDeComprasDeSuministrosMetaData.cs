using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ArticulosDeComprasDeSuministrosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Compra")]
			public int Compra { get; set; }

			[Display(Name = "Articulo")]
			public int Articulo { get; set; }

			[Display(Name = "Cantidad")]
			public int Cantidad { get; set; }

			[Display(Name = "Precio")]
			public decimal Precio { get; set; }
			#endregion


	}
}
