using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LicenciasRefViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "PorAnio")]
			public int? PorAnio { get; set; }

			[Display(Name = "PorLicencia")]
			public int? PorLicencia { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "DiasAcumulables")]
			public bool? DiasAcumulables { get; set; }

			[Display(Name = "CodigoRRHH")]
			public int CodigoRRHH { get; set; }
			#endregion


	}
}
