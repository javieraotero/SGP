
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
	[MetadataTypeAttribute(typeof(PresupuestacionConfiguracionValoresMetaData))]
	[Table("PresupuestacionConfiguracionValores")]
	public partial class PresupuestacionConfiguracionValores
	{
		#region Constructor
		public PresupuestacionConfiguracionValores()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Presupuestacion")]
		public int Presupuestacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Configuracion")]
		public int Configuracion { get; set; }

		public decimal? Valor { get; set; }

		[ForeignKey("Presupuestacion")]
		public virtual Presupuestacion Presupuestacions { get; set; }

		[ForeignKey("Configuracion")]
		public virtual PresupuestacionConfiguracion Configuracions { get; set; }
		#endregion

	}
}
