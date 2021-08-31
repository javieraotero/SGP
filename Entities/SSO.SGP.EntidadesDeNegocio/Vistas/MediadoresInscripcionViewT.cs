using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class MediadoresInscripcionViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Circunscripcion1")]
			public bool? Circunscripcion1 { get; set; }

			[Display(Name = "Circunscripcion2")]
			public bool? Circunscripcion2 { get; set; }

			[Display(Name = "Circunscripcion3")]
			public bool? Circunscripcion3 { get; set; }

			[Display(Name = "Circunscripcion4")]
			public bool? Circunscripcion4 { get; set; }

			[Display(Name = "FechaInscripcion")]
			public DateTime FechaInscripcion { get; set; }

			[Display(Name = "UsuarioCarga")]
			public int UsuarioCarga { get; set; }

			[Display(Name = "Periodo")]
			public int Periodo { get; set; }

			[Display(Name = "Mediador")]
			public int Mediador { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
