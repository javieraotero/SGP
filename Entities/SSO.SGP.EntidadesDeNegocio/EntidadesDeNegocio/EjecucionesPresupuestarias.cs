
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
	[MetadataTypeAttribute(typeof(EjecucionesPresupuestariasMetaData))]
	[Table("EjecucionesPresupuestarias")]
	public partial class EjecucionesPresupuestarias
	{
		#region Constructor
		public EjecucionesPresupuestarias()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Anio")]
		public int Anio { get; set; }

		[Required(ErrorMessage = "Debe ingresar PartidaPresupuestaria")]
		public int PartidaPresupuestaria { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		[Required(ErrorMessage = "Debe ingresar EstaBloqueada")]
		public bool EstaBloqueada { get; set; }

		[Required(ErrorMessage = "Debe ingresar CreditoActual")]
		public decimal CreditoActual { get; set; }

		[Required(ErrorMessage = "Debe ingresar CreditoDisponible")]
		public decimal CreditoDisponible { get; set; }

		[Required(ErrorMessage = "Debe ingresar CreditoHabilitado")]
		public decimal CreditoHabilitado { get; set; }

		[Required(ErrorMessage = "Debe ingresar MontoPreventiva")]
		public decimal MontoPreventiva { get; set; }

		[Required(ErrorMessage = "Debe ingresar MontoCompromiso")]
		public decimal MontoCompromiso { get; set; }

		[Required(ErrorMessage = "Debe ingresar MontoOrdenadoAPagar")]
		public decimal MontoOrdenadoAPagar { get; set; }

		public decimal? PresupuestoSolicitado { get; set; }

		public decimal? Presupuestado { get; set; }

		public decimal? ReestructuraMas { get; set; }

		public decimal? ReestructuraMenos { get; set; }

		public decimal? Factibilidad { get; set; }

		public decimal? FactibilidadHabilitada { get; set; }

		public decimal? ReservaMas { get; set; }

		public decimal? ReservaMenos { get; set; }

        public decimal? CreditoPresupuestadoModificado { get; set; }

        public decimal? MontoOrdenadoAPagarDF{ get; set; }

        public decimal? SaldoPreventiva { get; set; }

        public decimal? ReservaNeta { get; set; }

        public int? UsuarioElimina { get; set; }

        public DateTime? FechaElimina { get; set; }

        [ForeignKey("PartidaPresupuestaria")]
		public virtual PartidasPresupuestarias PartidaPresupuestarias { get; set; }
		#endregion

	}
}
