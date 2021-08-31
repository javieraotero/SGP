using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesContablesView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

            [Display(Name = "Fecha", Order = 10)]
            public DateTime Fecha { get; set; }

            [Display(Name = "Número", Order = 10)]
			public string Numero { get; set; }

			[Display(Name = "Carátula", Order=50)]
			public string Caratula { get; set; }

            [Display(Name = "Facturas", Order = 5)]
            public string Facturas { get; set; }

            [Display(Name = "As", Order = 5)]
            public string Asignado { get; set; }

            [Display(Name = "A", Order = 5)]
            public string Afectado { get; set; }

            [Display(Name = "O", Order = 5)]
            public string OrdenadoAPagr { get; set; }

        #endregion


    }
}
