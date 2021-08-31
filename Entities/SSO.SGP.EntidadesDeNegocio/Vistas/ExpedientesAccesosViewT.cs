using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesAccesosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expedientes")]
			public int Expedientes { get; set; }

			[Display(Name = "Actuacion")]
			public int? Actuacion { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "FechaHora")]
			public DateTime FechaHora { get; set; }
			#endregion


	}
}
