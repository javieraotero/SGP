using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class NombramientosView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "FechaDeAlta")]
			public DateTime FechaDeAlta { get; set; }

			[Display(Name = "FechaDeBaja")]
			public DateTime? FechaDeBaja { get; set; }

			[Display(Name = "Motivo")]
			public string Motivo { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }

			[Display(Name = "Cargo")]
			public int Cargo { get; set; }

			[Display(Name = "SituacionRevista")]
			public string SituacionRevista { get; set; }

			[Display(Name = "FechaFinContrato")]
			public DateTime? FechaFinContrato { get; set; }

			[Display(Name = "FechaFinSustitucion")]
			public DateTime? FechaFinSustitucion { get; set; }

			[Display(Name = "FechaRenuncia")]
			public DateTime? FechaRenuncia { get; set; }

			[Display(Name = "FechaPaseAPlanta")]
			public DateTime? FechaPaseAPlanta { get; set; }

			[Display(Name = "FechaUltimoAscenso")]
			public DateTime? FechaUltimoAscenso { get; set; }
			#endregion


	}
}
