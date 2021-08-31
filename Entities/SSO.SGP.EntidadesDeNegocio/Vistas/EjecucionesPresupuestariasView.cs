using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class EjecucionesPresupuestariasView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

            [Display(Name = "Año", Order = 5)]
            public int Anio { get; set; }

			[Display(Name = "Partida", Order=30)]
			public string PartidaPresupuestaria { get; set; }

			[Display(Name = "Cr.Actual", Order=10)]
			public decimal CreditoActual { get; set; }

			[Display(Name = "Cr.Disponible", Order=10)]
			public decimal CreditoDisponible { get; set; }

            [Display(Name = "Cr.Habilitado", Order = 10)]
			public decimal CreditoHabilitado { get; set; }

            [Display(Name = "Preventiva", Order = 10)]
			public decimal MontoPreventiva { get; set; }

            [Display(Name = "Compromiso", Order = 10)]
			public decimal MontoCompromiso { get; set; }

            [Display(Name = "Ord.Pagar", Order = 10)]
			public decimal MontoOrdenadoAPagar { get; set; }

			#endregion


	}
}
