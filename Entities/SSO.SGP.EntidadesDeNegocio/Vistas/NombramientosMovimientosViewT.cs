using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class NombramientosMovimientosViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Nombramiento", AutoGenerateField=false)]
			public int Nombramiento { get; set; }

			[Display(Name = "Fecha Desde")]
			public DateTime Desde { get; set; }

			[Display(Name = "Fecha Hasta")]
			public DateTime? Hasta { get; set; }

			[Display(Name = "Cargo")]
			public string Cargo { get; set; }

			[Display(Name = "St.Rev.")]
			public string SituacionRevista { get; set; }

			[Display(Name = "Organismo")]
			public string Organismo { get; set; }
			#endregion


	}
}
