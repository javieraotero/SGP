using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SustitucionesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Acuerdo")]
			public string Acuerdo { get; set; }

			[Display(Name = "Desde")]
			public DateTime Desde { get; set; }

			[Display(Name = "Hasta")]
			public DateTime? Hasta { get; set; }

			[Display(Name = "Motivo")]
			public int Motivo { get; set; }

			[Display(Name = "Cargo")]
			public int Cargo { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }
			#endregion


	}
}
