
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
	[MetadataTypeAttribute(typeof(PresupuestacionConfiguracionMetaData))]
	[Table("PresupuestacionConfiguracion")]
	public partial class PresupuestacionConfiguracion
	{
		#region Constructor
		public PresupuestacionConfiguracion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tipo")]
		[StringLength(3, ErrorMessage ="Tipo no puede superar los 3 caracteres")]
		public string Tipo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Valor")]
		public decimal Valor { get; set; }

		public virtual ICollection<LiquidacionConfiguracionValores> LiquidacionConfiguracionValores0307610B { get; set; }
		#endregion

	}
}
