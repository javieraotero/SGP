using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class GruposTipoActuacionCivilRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Modulo")]
			public int? Modulo { get; set; }

			[Display(Name = "SubAmbito")]
			public int? SubAmbito { get; set; }

			[Display(Name = "Ambito")]
			public int? Ambito { get; set; }
			#endregion


	}
}
