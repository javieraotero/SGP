using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConcursosDeIngresoRespuestasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Pregunta")]
			public int Pregunta { get; set; }

			[Display(Name = "Respuesta")]
			public string Respuesta { get; set; }

			[Display(Name = "EsCorrecta")]
			public bool EsCorrecta { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }
			#endregion


	}
}
