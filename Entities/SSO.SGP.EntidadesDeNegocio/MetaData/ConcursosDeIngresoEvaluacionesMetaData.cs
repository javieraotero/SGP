using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ConcursosDeIngresoEvaluacionesMetaData
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
