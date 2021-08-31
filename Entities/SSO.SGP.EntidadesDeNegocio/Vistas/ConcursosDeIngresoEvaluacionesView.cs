using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ConcursosDeIngresoEvaluacionesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Concurso")]
			public int Concurso { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "FechaInicio")]
			public DateTime? FechaInicio { get; set; }

			[Display(Name = "FechaFin")]
			public DateTime? FechaFin { get; set; }
			#endregion


	}
}
