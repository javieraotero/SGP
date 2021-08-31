
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(ConcursosEvaluacionesRespuestasMetaData))]
	[Table("ConcursosEvaluacionesRespuestas")]
	public partial class ConcursosEvaluacionesRespuestas
	{
		#region Constructor
		public ConcursosEvaluacionesRespuestas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		//[Required(ErrorMessage = "Debe ingresar Inscripcion")]
		//public int Inscripcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Pregunta")]
		public int Pregunta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Respuesta")]
		public int Respuesta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInicio")]
		public DateTime FechaInicio { get; set; }

		public DateTime? FechaFin { get; set; }

		public int? RespuestaCorrecta { get; set; }

		[Required(ErrorMessage = "Debe ingresar InscripcionEvalacion")]
		public int InscripcionEvalacion { get; set; }
		#endregion

	}
}
