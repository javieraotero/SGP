using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ColumnasView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Tabla")]
			public int Tabla { get; set; }

			[Display(Name = "TipoDato")]
			public int TipoDato { get; set; }

			[Display(Name = "Longitud")]
			public int Longitud { get; set; }

			[Display(Name = "AdmiteNulo")]
			public bool AdmiteNulo { get; set; }

			[Display(Name = "Referencia")]
			public string Referencia { get; set; }

			[Display(Name = "Mostrar")]
			public bool Mostrar { get; set; }
			#endregion


	}
}
