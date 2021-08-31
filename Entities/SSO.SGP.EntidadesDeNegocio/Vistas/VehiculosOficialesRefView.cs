using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class VehiculosOficialesRefView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "Legajo", Order = 20)]
			public string Legajo { get; set; }

			[Display(Name = "Patente", Order = 15)]
			public string Patente { get; set; }

			[Display(Name = "Descripcion", Order = 70)]
			public string Descripcion { get; set; }
			#endregion


	}
}
