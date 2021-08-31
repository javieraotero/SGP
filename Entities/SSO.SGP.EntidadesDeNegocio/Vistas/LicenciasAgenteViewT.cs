using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class LicenciasAgenteViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

            [Display(Name = "F.Reg.")]
            public DateTime FechaAlta { get; set; }

			[Display(Name = "Desde")]
			public DateTime FechaDesde { get; set; }

            [Display(Name = "Días")]
            public int Dias { get; set; }

			[Display(Name = "Hasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Licencia")]
			public string Licencia { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }


        #endregion


    }
}
