
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
	[MetadataTypeAttribute(typeof(LiquidacionAbogadosMetaData))]
	[Table("LiquidacionAbogados")]
	public partial class LiquidacionAbogados
	{
		#region Constructor
		public LiquidacionAbogados()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Liquidacion")]
		public int Liquidacion { get; set; }

		[StringLength(100, ErrorMessage ="Nombre no puede superar los 100 caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar IVA")]
		public bool IVA { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[ForeignKey("Liquidacion")]
		public virtual Liquidacion Liquidacions { get; set; }
		#endregion

	}
}
