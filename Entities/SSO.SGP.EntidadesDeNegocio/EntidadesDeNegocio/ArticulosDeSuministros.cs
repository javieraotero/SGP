
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
	[MetadataTypeAttribute(typeof(ArticulosDeSuministrosMetaData))]
	[Table("ArticulosDeSuministros")]
	public partial class ArticulosDeSuministros
	{
		#region Constructor
		public ArticulosDeSuministros()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		[StringLength(150, ErrorMessage ="Nombre no puede superar los 150 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar Codigo")]
		[StringLength(20, ErrorMessage ="Codigo no puede superar los 20 caracteres")]
		public string Codigo { get; set; }

		[Required(ErrorMessage = "Debe ingresar StockMinimo")]
		public int StockMinimo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Stock")]
		public int Stock { get; set; }

		public decimal? UltimoCosto { get; set; }

		public DateTime? FechaUltimoPrecio { get; set; }

		public DateTime? FechaDeBaja { get; set; }

		public virtual ICollection<ArticulosDeComprasDeSuministros> ArticulosDeComprasDeSuministros { get; set; }

		public virtual ICollection<ArticulosDePedidoDeSuministros> ArticulosDePedidoDeSuministros { get; set; }
		#endregion

	}
}
