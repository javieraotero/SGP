using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LiquidacionAbogadosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Liquidacion")]
			public int Liquidacion { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "IVA")]
			public bool IVA { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }
			#endregion


	}
}
