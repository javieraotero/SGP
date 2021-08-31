
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(ArticulosDePedidoDeSuministrosMetaData))]
	[Table("ArticulosDePedidoDeSuministros")]
	public partial class ArticulosDePedidoDeSuministros
	{
		#region Constructor
		public ArticulosDePedidoDeSuministros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Articulo")]
		public int Articulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Pedido")]
		public int Pedido { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadEntregada")]
		public int CantidadEntregada { get; set; }

		[Required(ErrorMessage = "Debe ingresar Precio")]
		public decimal Precio { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadPedida")]
		public int CantidadPedida { get; set; }

		[ForeignKey("Articulo")]
		public virtual ArticulosDeSuministros Articulos { get; set; }

		[ForeignKey("Pedido")]
		public virtual PedidosDeSuministros Pedidos { get; set; }
		#endregion

	}
}
