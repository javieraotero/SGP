
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
	[MetadataTypeAttribute(typeof(LiquidacionCapitalesMetaData))]
	[Table("LiquidacionCapitales")]
	public partial class LiquidacionCapitales
	{
		#region Constructor
		public LiquidacionCapitales()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Liquidacion")]
		public int Liquidacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Monto")]
		public decimal Monto { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(30, ErrorMessage ="Descripcion no puede superar los 30 caracteres")]
		public string Descripcion { get; set; }

		[ForeignKey("Liquidacion")]
		public virtual Liquidacion Liquidacions { get; set; }
		#endregion

	}
}
