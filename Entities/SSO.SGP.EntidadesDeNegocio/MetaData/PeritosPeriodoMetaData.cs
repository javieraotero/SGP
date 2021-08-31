using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PeritosPeriodoMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "TipoPeriodo")]
			public int TipoPeriodo { get; set; }

			[Display(Name = "FecIniInscripcion")]
			public DateTime? FecIniInscripcion { get; set; }

			[Display(Name = "FecFinInscripcion")]
			public DateTime? FecFinInscripcion { get; set; }

			[Display(Name = "FecIniPeriodo")]
			public DateTime? FecIniPeriodo { get; set; }

			[Display(Name = "FecFinPeriodo")]
			public DateTime? FecFinPeriodo { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
