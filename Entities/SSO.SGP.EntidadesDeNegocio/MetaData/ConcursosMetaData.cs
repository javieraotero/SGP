using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ConcursosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Actividad")]
			public string Actividad { get; set; }

			[Display(Name = "RazonSocial")]
			public string RazonSocial { get; set; }

			[Display(Name = "DomicilioComercial")]
			public string DomicilioComercial { get; set; }

			[Display(Name = "MatriculaRazonSocial")]
			public int? MatriculaRazonSocial { get; set; }

			[Display(Name = "FolioRazonSocial")]
			public int? FolioRazonSocial { get; set; }

			[Display(Name = "TomoRazonSocial")]
			public int? TomoRazonSocial { get; set; }

			[Display(Name = "AnioRazonSocial")]
			public int? AnioRazonSocial { get; set; }

			[Display(Name = "MatriculaComerciante")]
			public int? MatriculaComerciante { get; set; }

			[Display(Name = "FolioComerciante")]
			public int? FolioComerciante { get; set; }

			[Display(Name = "TomoComerciante")]
			public int? TomoComerciante { get; set; }

			[Display(Name = "AnioComerciante")]
			public int? AnioComerciante { get; set; }
			#endregion


	}
}
