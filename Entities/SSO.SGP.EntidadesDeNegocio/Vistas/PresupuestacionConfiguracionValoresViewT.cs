using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PresupuestacionConfiguracionValoresViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Presupuestacion")]
			public int Presupuestacion { get; set; }

			[Display(Name = "Configuracion")]
			public int Configuracion { get; set; }

			[Display(Name = "Valor")]
			public decimal? Valor { get; set; }
			#endregion


	}
}
