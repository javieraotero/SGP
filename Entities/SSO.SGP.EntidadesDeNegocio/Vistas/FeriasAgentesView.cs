using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class FeriasAgentesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "Feria")]
			public int Feria { get; set; }

			[Display(Name = "Dias")]
			public int Dias { get; set; }

			[Display(Name = "Desde1")]
			public DateTime Desde1 { get; set; }

			[Display(Name = "Desde2")]
			public DateTime? Desde2 { get; set; }

			[Display(Name = "Desde3")]
			public DateTime? Desde3 { get; set; }

			[Display(Name = "Hasta1")]
			public DateTime Hasta1 { get; set; }

			[Display(Name = "Hasta2")]
			public DateTime? Hasta2 { get; set; }

			[Display(Name = "Hasta3")]
			public DateTime? Hasta3 { get; set; }

			[Display(Name = "Instancia")]
			public int Instancia { get; set; }
			#endregion


	}
}
