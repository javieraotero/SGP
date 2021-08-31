
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
	[MetadataTypeAttribute(typeof(MovimientosDeStockMetaData))]
	[Table("MovimientosDeStock")]
	public partial class MovimientosDeStock
	{
		#region Constructor
		public MovimientosDeStock()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Pedido { get; set; }

		[Required(ErrorMessage = "Debe ingresar Movimiento")]
		public int Movimiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cantidad")]
		public int Cantidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Articulo")]
		public int Articulo { get; set; }

		[StringLength(100, ErrorMessage ="CausaExpurgue no puede superar los 100 caracteres")]
		public string CausaExpurgue { get; set; }

		public int? Compra { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[ForeignKey("Pedido")]
		public virtual PedidosDeSuministros Pedidos { get; set; }

		[ForeignKey("Articulo")]
		public virtual ArticulosDeSuministros Articulos { get; set; }
		#endregion

	}
}
