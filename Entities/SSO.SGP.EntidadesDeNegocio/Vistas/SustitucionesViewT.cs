using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SustitucionesViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Acuerdo")]
			public string Acuerdo { get; set; }

			[Display(Name = "Desde")]
			public DateTime FechaDesde { get; set; }

			[Display(Name = "Hasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Cargo")]
			public string Cargo { get; set; }

			[Display(Name = "Organismo")]
			public string Organismo { get; set; }
			#endregion


	}
}
