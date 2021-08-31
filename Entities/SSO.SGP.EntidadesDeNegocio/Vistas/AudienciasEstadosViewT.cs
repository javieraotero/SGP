using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AudienciasEstadosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Audiencia")]
			public int Audiencia { get; set; }

			[Display(Name = "Fecha")]
			public DateTime? Fecha { get; set; }

			[Display(Name = "HoraInicio")]
			public string HoraInicio { get; set; }

			[Display(Name = "HoraFin")]
			public string HoraFin { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Juez")]
			public int? Juez { get; set; }

			[Display(Name = "Juez2")]
			public int? Juez2 { get; set; }

			[Display(Name = "Juez3")]
			public int? Juez3 { get; set; }

			[Display(Name = "Sala")]
			public int? Sala { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "MotivoCancelacion")]
			public int? MotivoCancelacion { get; set; }

			[Display(Name = "MotivoPostergacion")]
			public int? MotivoPostergacion { get; set; }
			#endregion


	}
}
