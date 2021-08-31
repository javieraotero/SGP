using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConcursosDeIngresoPreguntasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Pregunta")]
			public string Pregunta { get; set; }

			[Display(Name = "Evaluacion")]
			public int Evaluacion { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "Orden")]
			public int Orden { get; set; }
			#endregion


	}
}
