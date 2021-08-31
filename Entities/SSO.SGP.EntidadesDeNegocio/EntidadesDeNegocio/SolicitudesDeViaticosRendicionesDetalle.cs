
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
	[MetadataTypeAttribute(typeof(SolicitudesDeViaticosRendicionesDetalleMetaData))]
	[Table("SolicitudesDeViaticosRendicionesDetalle")]
	public partial class SolicitudesDeViaticosRendicionesDetalle
	{
		#region Constructor
		public SolicitudesDeViaticosRendicionesDetalle()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar RendicionAgente")]
		public int RendicionAgente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		public string Descripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Importe")]
		public decimal Importe { get; set; }

		public int? Concepto { get; set; }

        public int Agente { get; set; }

		#endregion

	}
}
