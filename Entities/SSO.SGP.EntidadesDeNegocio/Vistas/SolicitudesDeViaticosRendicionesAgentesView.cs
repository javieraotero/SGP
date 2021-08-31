using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SolicitudesDeViaticosRendicionesAgentesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Rendicion")]
			public int Rendicion { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Dias")]
			public decimal Dias { get; set; }

			[Display(Name = "ImportePorDia")]
			public decimal ImportePorDia { get; set; }

			[Display(Name = "Subtotal")]
			public decimal Subtotal { get; set; }

			[Display(Name = "Gastos")]
			public decimal Gastos { get; set; }

			[Display(Name = "Anticipo")]
			public decimal Anticipo { get; set; }

			[Display(Name = "Cobrar")]
			public decimal Cobrar { get; set; }

			[Display(Name = "Devolver")]
			public decimal Devolver { get; set; }
			#endregion


	}
}
