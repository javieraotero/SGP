
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
	[MetadataTypeAttribute(typeof(PresupuestacionCapitalesMetaData))]
	[Table("PresupuestacionCapitales")]
	public partial class PresupuestacionCapitales
	{
		#region Constructor
		public PresupuestacionCapitales()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Presupuestacion")]
		public int Presupuestacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		[Required(ErrorMessage = "Debe ingresar Monto")]
		public decimal Monto { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(30, ErrorMessage ="Descripcion no puede superar los 30 caracteres")]
		public string Descripcion { get; set; }

		[ForeignKey("Presupuestacion")]
		public virtual Presupuestacion Presupuestacions { get; set; }
		#endregion

	}
}
