using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ConcursosInscripcionesEvaluacionesMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Evaluacion")]
			public int Evaluacion { get; set; }

			[Display(Name = "DNI")]
			public int DNI { get; set; }

			[Display(Name = "Email")]
			public string Email { get; set; }

			[Display(Name = "CodigoDNI")]
			public int CodigoDNI { get; set; }

			[Display(Name = "FechaInicio")]
			public DateTime FechaInicio { get; set; }

			[Display(Name = "FechaEnvio")]
			public DateTime? FechaEnvio { get; set; }

			[Display(Name = "ConfirmacionEmail")]
			public bool ConfirmacionEmail { get; set; }

			[Display(Name = "FechaConfirmacion")]
			public DateTime? FechaConfirmacion { get; set; }

			[Display(Name = "Token")]
			public string Token { get; set; }
			#endregion


	}
}
