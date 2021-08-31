using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ArticulosDePedidoDeSuministrosView
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
