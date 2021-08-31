using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class DivisionesExtraPresupuestariasView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

			[Display(Name = "Nombre", Order=40)]
			public string Nombre { get; set; }

			[Display(Name = "CodigoCESIDA", Order=25)]
			public string CodigoCESIDA { get; set; }

			[Display(Name = "PartidaPresupuestaria", Order=35)]
			public int PartidaPresupuestaria { get; set; }
			#endregion


	}
}
