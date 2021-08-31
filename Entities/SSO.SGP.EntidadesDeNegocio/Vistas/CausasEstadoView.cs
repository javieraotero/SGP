using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CausasEstadoView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Causa")]
			public int Causa { get; set; }

			[Display(Name = "Actuacion")]
			public int? Actuacion { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "CambioManual")]
			public bool CambioManual { get; set; }
			#endregion


	}
}
