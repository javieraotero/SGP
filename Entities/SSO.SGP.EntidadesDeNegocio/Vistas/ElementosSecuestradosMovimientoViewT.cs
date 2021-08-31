using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ElementosSecuestradosMovimientoViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Elemento")]
			public int Elemento { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Motivo")]
			public int Motivo { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Estado")]
			public string Estado { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }
			#endregion


	}
}
