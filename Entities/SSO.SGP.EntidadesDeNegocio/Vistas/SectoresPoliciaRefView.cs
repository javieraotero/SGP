using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SectoresPoliciaRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "IdSector")]
			public int? IdSector { get; set; }

			[Display(Name = "Sector")]
			public string Sector { get; set; }

			[Display(Name = "Barrio")]
			public string Barrio { get; set; }

			[Display(Name = "Unidad")]
			public int Unidad { get; set; }

			[Display(Name = "Comisaria")]
			public int? Comisaria { get; set; }
			#endregion


	}
}
