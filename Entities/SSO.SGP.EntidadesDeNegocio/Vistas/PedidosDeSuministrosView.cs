using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PedidosDeSuministrosView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

			[Display(Name = "Organismo", Order=60)]
			public string Organismo { get; set; }

			[Display(Name = "F. Pedido", Order=10)]
			public DateTime FechaDePedido { get; set; }

			[Display(Name = "Entregado?", Order=10)]
			public string Entregado { get; set; }

			[Display(Name = "F. Carga", Order=10)]
			public DateTime FechaDeCarga{ get; set; }

			#endregion


	}
}
