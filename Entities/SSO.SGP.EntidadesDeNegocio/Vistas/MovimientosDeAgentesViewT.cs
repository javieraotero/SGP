using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class MovimientosDeAgentesViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombramiento")]
			public int Nombramiento { get; set; }

			[Display(Name = "NuevoCargo")]
			public int? NuevoCargo { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "NuevoOrganismo")]
			public int? NuevoOrganismo { get; set; }
			#endregion


	}
}
