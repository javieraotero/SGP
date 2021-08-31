using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class EstadosDeViaticosRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "EditaOrganismo")]
			public bool EditaOrganismo { get; set; }

			[Display(Name = "EditaEconomia")]
			public bool EditaEconomia { get; set; }
			#endregion


	}
}
