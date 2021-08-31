using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LicenciasRefView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

			[Display(Name = "Descripción", Order=35)]
			public string Descripcion { get; set; }

			[Display(Name = "Por Año", Order=10)]
			public int? PorAnio { get; set; }

			[Display(Name = "Por Licencia", Order =10)]
			public int? PorLicencia { get; set; }

            [Display(Name = "Por Agente?", Order = 10)]
            public string PorAgente { get; set; }

            [Display(Name = "Contexto", Order = 15)]
            public string Contexto { get; set; }

			[Display(Name = "Código", Order=10)]
			public int CodigoRRHH { get; set; }
			#endregion


	}
}
