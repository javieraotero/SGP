using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AudienciasImputadosView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Audiencia")]
			public int Audiencia { get; set; }

			[Display(Name = "Parte")]
			public int Parte { get; set; }

			[Display(Name = "CesacionPrisionPreventiva")]
			public bool? CesacionPrisionPreventiva { get; set; }

			[Display(Name = "CesacionPrisionPreventivaRestricciones")]
			public bool? CesacionPrisionPreventivaRestricciones { get; set; }

			[Display(Name = "PedidoCaptura")]
			public bool? PedidoCaptura { get; set; }

			[Display(Name = "RestriccionAcercamiento")]
			public bool? RestriccionAcercamiento { get; set; }

			[Display(Name = "PrisionPreventivaCantidadDias")]
			public int? PrisionPreventivaCantidadDias { get; set; }

			[Display(Name = "FechaLiberacion")]
			public DateTime? FechaLiberacion { get; set; }

			[Display(Name = "LugarDetencion")]
			public int? LugarDetencion { get; set; }

			[Display(Name = "GeneraOficioLibertad")]
			public bool? GeneraOficioLibertad { get; set; }

			[Display(Name = "OficioLibertadEmitido")]
			public bool? OficioLibertadEmitido { get; set; }

			[Display(Name = "OficioLibertadCancelado")]
			public bool? OficioLibertadCancelado { get; set; }

			[Display(Name = "Formalizacion")]
			public bool? Formalizacion { get; set; }

			[Display(Name = "SuspensionProcesoPrueba")]
			public bool? SuspensionProcesoPrueba { get; set; }

			[Display(Name = "Conciliacion")]
			public bool? Conciliacion { get; set; }

			[Display(Name = "ControlDetencion")]
			public bool? ControlDetencion { get; set; }

			[Display(Name = "MedidasCoercion")]
			public bool? MedidasCoercion { get; set; }

			[Display(Name = "ReexamenMedidaCoercion")]
			public bool? ReexamenMedidaCoercion { get; set; }

			[Display(Name = "PrisionPreventiva")]
			public bool? PrisionPreventiva { get; set; }

			[Display(Name = "SobreSeimiento")]
			public bool? SobreSeimiento { get; set; }

			[Display(Name = "PruebaJurisdiccional")]
			public bool? PruebaJurisdiccional { get; set; }

			[Display(Name = "JuicioAbreviado")]
			public bool? JuicioAbreviado { get; set; }

			[Display(Name = "SinResolucion")]
			public bool? SinResolucion { get; set; }

			[Display(Name = "SobreseimientoSimple")]
			public bool? SobreseimientoSimple { get; set; }

			[Display(Name = "SobreseimientoCriterioOportunidad")]
			public bool? SobreseimientoCriterioOportunidad { get; set; }

			[Display(Name = "JuicioAbreviadoAdmite")]
			public bool? JuicioAbreviadoAdmite { get; set; }

			[Display(Name = "JuicioAbreviadoRechaza")]
			public bool? JuicioAbreviadoRechaza { get; set; }

			[Display(Name = "JuicioAbreviadoCondena")]
			public bool? JuicioAbreviadoCondena { get; set; }

			[Display(Name = "JuicioAbreviadoAbsolucion")]
			public bool? JuicioAbreviadoAbsolucion { get; set; }

			[Display(Name = "JuicioAbreviadoResponsPenal")]
			public bool? JuicioAbreviadoResponsPenal { get; set; }

			[Display(Name = "JuicioCondena")]
			public bool? JuicioCondena { get; set; }

			[Display(Name = "JuicioAbsolucion")]
			public bool? JuicioAbsolucion { get; set; }

			[Display(Name = "JuicioResponsPenal")]
			public bool? JuicioResponsPenal { get; set; }

			[Display(Name = "JuicioDirectoAdmite")]
			public bool? JuicioDirectoAdmite { get; set; }

			[Display(Name = "JuicioDirectoRechaza")]
			public bool? JuicioDirectoRechaza { get; set; }
			#endregion


	}
}
