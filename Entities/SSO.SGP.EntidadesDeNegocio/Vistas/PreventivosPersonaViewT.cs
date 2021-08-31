using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PreventivosPersonaViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Preventivo")]
			public int Preventivo { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Rol")]
			public int Rol { get; set; }

			[Display(Name = "Demorado")]
			public bool Demorado { get; set; }
			#endregion


	}
}
