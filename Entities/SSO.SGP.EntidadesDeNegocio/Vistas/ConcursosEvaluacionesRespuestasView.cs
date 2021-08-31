using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConcursosEvaluacionesRespuestasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Inscripcion")]
			public int Inscripcion { get; set; }

			[Display(Name = "Pregunta")]
			public int Pregunta { get; set; }

			[Display(Name = "Respuesta")]
			public int Respuesta { get; set; }

			[Display(Name = "FechaInicio")]
			public DateTime FechaInicio { get; set; }

			[Display(Name = "FechaFin")]
			public DateTime? FechaFin { get; set; }

			[Display(Name = "RespuestaCorrecta")]
			public int? RespuestaCorrecta { get; set; }

			[Display(Name = "InscripcionEvalacion")]
			public int InscripcionEvalacion { get; set; }
			#endregion


	}
}
