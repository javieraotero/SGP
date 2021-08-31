using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AudienciasDemorasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Audiencia")]
			public int Audiencia { get; set; }

			[Display(Name = "MotivoDemora")]
			public int MotivoDemora { get; set; }

			[Display(Name = "Observacion")]
			public string Observacion { get; set; }
			#endregion


	}
}
