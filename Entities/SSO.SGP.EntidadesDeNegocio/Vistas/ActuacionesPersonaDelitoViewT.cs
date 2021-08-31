using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ActuacionesPersonaDelitoViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Actuacion")]
			public int Actuacion { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Delito")]
			public int Delito { get; set; }

			[Display(Name = "Automatico")]
			public bool Automatico { get; set; }
			#endregion


	}
}
