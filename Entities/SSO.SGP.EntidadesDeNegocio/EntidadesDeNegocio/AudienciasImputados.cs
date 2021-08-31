
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SSO.SGP.MetaData;


namespace SSO.SGP.EntidadesDeNegocio
{
	/// <summary>
	/// Entidad Generada por el Generador de codigo.
	/// </summary>
	[MetadataTypeAttribute(typeof(AudienciasImputadosMetaData))]
	[Table("AudienciasImputados")]
	public partial class AudienciasImputados
	{
		#region Constructor
		public AudienciasImputados()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Audiencia")]
		public int Audiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Parte")]
		public int Parte { get; set; }

		public bool? CesacionPrisionPreventiva { get; set; }

		public bool? CesacionPrisionPreventivaRestricciones { get; set; }

		public bool? PedidoCaptura { get; set; }

		public bool? RestriccionAcercamiento { get; set; }

		public int? PrisionPreventivaCantidadDias { get; set; }

		public DateTime? FechaLiberacion { get; set; }

		public int? LugarDetencion { get; set; }

		public bool? GeneraOficioLibertad { get; set; }

		public bool? OficioLibertadEmitido { get; set; }

		public bool? OficioLibertadCancelado { get; set; }

		public bool? Formalizacion { get; set; }

		public bool? SuspensionProcesoPrueba { get; set; }

		public bool? Conciliacion { get; set; }

		public bool? ControlDetencion { get; set; }

		public bool? MedidasCoercion { get; set; }

		public bool? ReexamenMedidaCoercion { get; set; }

		public bool? PrisionPreventiva { get; set; }

		public bool? SobreSeimiento { get; set; }

		public bool? PruebaJurisdiccional { get; set; }

		public bool? JuicioAbreviado { get; set; }

		public bool? SinResolucion { get; set; }

		public bool? SobreseimientoSimple { get; set; }

		public bool? SobreseimientoCriterioOportunidad { get; set; }

		public bool? JuicioAbreviadoAdmite { get; set; }

		public bool? JuicioAbreviadoRechaza { get; set; }

		public bool? JuicioAbreviadoCondena { get; set; }

		public bool? JuicioAbreviadoAbsolucion { get; set; }

		public bool? JuicioAbreviadoResponsPenal { get; set; }

		public bool? JuicioCondena { get; set; }

		public bool? JuicioAbsolucion { get; set; }

		public bool? JuicioResponsPenal { get; set; }

		public bool? JuicioDirectoAdmite { get; set; }

		public bool? JuicioDirectoRechaza { get; set; }

		[ForeignKey("Audiencia")]
		public virtual Audiencias Audiencias { get; set; }

		[ForeignKey("Parte")]
		public virtual ExpedientesPersona Partes { get; set; }

		[ForeignKey("LugarDetencion")]
		public virtual OrganismosRef LugarDetencions { get; set; }
		#endregion

	}
}
