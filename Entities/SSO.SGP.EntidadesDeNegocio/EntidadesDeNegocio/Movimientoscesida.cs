
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
	[MetadataTypeAttribute(typeof(MovimientoscesidaMetaData))]
	[Table("Movimientoscesida")]
	public partial class Movimientoscesida
	{
		#region Constructor
		public Movimientoscesida()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombre")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "Debe ingresar CodigoCesida")]
		public string CodigoCesida { get; set; }

		[Required(ErrorMessage = "Debe ingresar ApiURLProduccion")]
		public string ApiURLProduccion { get; set; }

		[Required(ErrorMessage = "Debe ingresar ApiURLPruebas")]
		public string ApiURLPruebas { get; set; }

		public virtual ICollection<ColaDeMovimientoscesida> ColaDeMovimientoscesida { get; set; }
		#endregion

	}
}
