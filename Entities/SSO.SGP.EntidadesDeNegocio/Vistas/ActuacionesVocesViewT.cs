using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ActuacionesVocesViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Actuacion")]
			public int Actuacion { get; set; }

			[Display(Name = "Voz")]
			public int Voz { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "Confirmado")]
			public bool Confirmado { get; set; }
			#endregion


	}
}
