using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SolicitudesDeViaticosRendicionesDetalleViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "RendicionAgente")]
			public int RendicionAgente { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Importe")]
			public decimal Importe { get; set; }

			[Display(Name = "Concepto")]
			public int? Concepto { get; set; }
			#endregion


	}
}
