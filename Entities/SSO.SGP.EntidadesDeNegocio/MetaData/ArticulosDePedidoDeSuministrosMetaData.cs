using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ArticulosDePedidoDeSuministrosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Articulo")]
			public int Articulo { get; set; }

			[Display(Name = "Pedido")]
			public int Pedido { get; set; }

			[Display(Name = "CantidadEntregada")]
			public int CantidadEntregada { get; set; }

			[Display(Name = "Precio")]
			public decimal Precio { get; set; }

			[Display(Name = "CantidadPedida")]
			public int CantidadPedida { get; set; }
			#endregion


	}
}
