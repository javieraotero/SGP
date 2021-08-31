using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class EjecucionesPresupuestariasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Año")]
			public int Anio { get; set; }

			[Display(Name = "Partida Presupuestaria")]
			public int PartidaPresupuestaria { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "Bloqueada?")]
			public bool EstaBloqueada { get; set; }

			[Display(Name = "Credito Actual")]
			public decimal CreditoActual { get; set; }

			[Display(Name = "Credito Disponible")]
			public decimal CreditoDisponible { get; set; }

			[Display(Name = "Habilitado")]
			public decimal CreditoHabilitado { get; set; }

			[Display(Name = "Preventiva")]
			public decimal MontoPreventiva { get; set; }

			[Display(Name = "Compromiso")]
			public decimal MontoCompromiso { get; set; }

			[Display(Name = "Ordenado a Pagar")]
			public decimal MontoOrdenadoAPagar { get; set; }

			[Display(Name = "Presupuesto Solicitado")]
			public decimal? PresupuestoSolicitado { get; set; }

			[Display(Name = "Presupuestado")]
			public decimal? Presupuestado { get; set; }

			[Display(Name = "Reestructura Mas")]
			public decimal? ReestructuraMas { get; set; }

			[Display(Name = "Reestructura Menos")]
			public decimal? ReestructuraMenos { get; set; }

			[Display(Name = "Factibilidad")]
			public decimal? Factibilidad { get; set; }

			[Display(Name = "Factibilidad Habilitada")]
			public decimal? FactibilidadHabilitada { get; set; }

			[Display(Name = "Reserva Mas")]
			public decimal? ReservaMas { get; set; }

			[Display(Name = "Reserva Menos")]
			public decimal? ReservaMenos { get; set; }
			#endregion


	}
}
