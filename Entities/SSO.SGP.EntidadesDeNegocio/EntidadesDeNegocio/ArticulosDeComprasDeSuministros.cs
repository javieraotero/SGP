
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
	[MetadataTypeAttribute(typeof(ArticulosDeComprasDeSuministrosMetaData))]
	[Table("ArticulosDeComprasDeSuministros")]
	public partial class ArticulosDeComprasDeSuministros
	{
		#region Constructor
		public ArticulosDeComprasDeSuministros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Compra")]
		public int Compra { get; set; }

		[Required(ErrorMessage = "Debe ingresar Articulo")]
		public int Articulo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Cantidad")]
		public int Cantidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Precio")]
		public decimal Precio { get; set; }

		[ForeignKey("Compra")]
		public virtual CompraDeSuministros Compras { get; set; }

		[ForeignKey("Articulo")]
		public virtual ArticulosDeSuministros Articulos { get; set; }
		#endregion

	}
}
