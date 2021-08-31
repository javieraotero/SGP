using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AgentesViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Legajo")]
			public int Legajo { get; set; }

			[Display(Name = "Telefono")]
			public string Telefono { get; set; }

			[Display(Name = "Profesion")]
			public string Profesion { get; set; }

			[Display(Name = "EstudiosCursados")]
			public string EstudiosCursados { get; set; }

			[Display(Name = "AfiliadoISS")]
			public string AfiliadoISS { get; set; }

			[Display(Name = "FechaDeCasamiento")]
			public DateTime? FechaDeCasamiento { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "NumeroPS")]
			public int? NumeroPS { get; set; }

			[Display(Name = "Domicilio")]
			public string Domicilio { get; set; }

			[Display(Name = "FechaUltimoAscenso")]
			public DateTime? FechaUltimoAscenso { get; set; }

			[Display(Name = "UltimoCargo")]
			public int? UltimoCargo { get; set; }
			#endregion


	}
}
