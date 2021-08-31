using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ReportesParametrosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Valor")]
			public string ValorPorDefecto { get; set; }

            [Display(Name="Obligatorio?")]
            public bool Obligatorio { get; set; }

			[Display(Name = "Reporte")]
			public int Reporte { get; set; }
			#endregion


	}
}
