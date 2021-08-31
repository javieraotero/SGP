using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class EjecucionesPresupuestariasViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Anio")]
			public int Anio { get; set; }

			[Display(Name = "PartidaPresupuestaria")]
			public int PartidaPresupuestaria { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "EstaBloqueada")]
			public bool EstaBloqueada { get; set; }

			[Display(Name = "CreditoActual")]
			public decimal CreditoActual { get; set; }

			[Display(Name = "CreditoDisponible")]
			public decimal CreditoDisponible { get; set; }

			[Display(Name = "CreditoHabilitado")]
			public decimal CreditoHabilitado { get; set; }

			[Display(Name = "MontoPreventiva")]
			public decimal MontoPreventiva { get; set; }

			[Display(Name = "MontoCompromiso")]
			public decimal MontoCompromiso { get; set; }

			[Display(Name = "MontoOrdenadoAPagar")]
			public decimal MontoOrdenadoAPagar { get; set; }

			[Display(Name = "PresupuestoSolicitado")]
			public decimal? PresupuestoSolicitado { get; set; }

			[Display(Name = "Presupuestado")]
			public decimal? Presupuestado { get; set; }

			[Display(Name = "ReestructuraMas")]
			public decimal? ReestructuraMas { get; set; }

			[Display(Name = "ReestructuraMenos")]
			public decimal? ReestructuraMenos { get; set; }

			[Display(Name = "Factibilidad")]
			public decimal? Factibilidad { get; set; }

			[Display(Name = "FactibilidadHabilitada")]
			public decimal? FactibilidadHabilitada { get; set; }

			[Display(Name = "ReservaMas")]
			public decimal? ReservaMas { get; set; }

			[Display(Name = "ReservaMenos")]
			public decimal? ReservaMenos { get; set; }
			#endregion


	}
}
