using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PedidosDeSuministrosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }

			[Display(Name = "Fecha De Pedido")]
			public DateTime FechaDePedido { get; set; }

			[Display(Name = "Usuario")]
			public int? Usuario { get; set; }

			[Display(Name = "FechaDeCarga")]
			public DateTime FechaDeCarga { get; set; }

			[Display(Name = "Entregado")]
			public bool Entregado { get; set; }

			[Display(Name = "FechaDeBaja")]
			public DateTime? FechaDeBaja { get; set; }

			[Display(Name = "UsuarioBaja")]
			public int? UsuarioBaja { get; set; }
			#endregion


	}
}
