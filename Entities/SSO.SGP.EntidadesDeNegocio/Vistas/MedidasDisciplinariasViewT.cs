using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class MedidasDisciplinariasViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Descripción")]
			public string Causa { get; set; }

			#endregion


	}
}
