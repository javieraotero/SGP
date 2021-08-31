
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
	[MetadataTypeAttribute(typeof(LicenciasRefMetaData))]
	[Table("LicenciasRef")]
	public partial class LicenciasRef
	{
		#region Constructor
		public LicenciasRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(80, ErrorMessage ="Descripcion no puede superar los 80 caracteres")]
		public string Descripcion { get; set; }

		public int? PorAnio { get; set; }

		public int? PorLicencia { get; set; }

		[StringLength(200, ErrorMessage ="Observaciones no puede superar los 200 caracteres")]
		public string Observaciones { get; set; }

		public bool DiasAcumulables { get; set; }

		[Required(ErrorMessage = "Debe ingresar CodigoRRHH")]
		public int CodigoRRHH { get; set; }

        public int? ResetearDias{ get; set; }

        [Required(ErrorMessage = "Debe ingresar si la licencia es por agente")]
        public bool PorAgente { get; set; }

        public int? DiasTopeExcepcion { get; set; }

        public int? TopeExcepcionUnidadTemporal { get; set; }

        public int? DiasParaReinicioDeSaldo { get; set; }

        public DateTime? FechaInicioDeControl { get; set; }

        public int? UnidadTemporalPorAnio { get; set; }

        public int? UnidadTemporalPorLicencia { get; set; }

        public int? UnidadDeContextoPorLicencia { get; set; }

        [ForeignKey("UnidadTemporalPorAnio")]
        public virtual UnidadTemporalRef UnidadTemporalPorAnios { get; set; }
        [ForeignKey("UnidadTemporalPorLicencia")]
        public virtual UnidadTemporalRef UnidadTemporalPorLicencias { get; set; }
        [ForeignKey("UnidadDeContextoPorLicencia")]
        public virtual UnidadDeContextoRef UnidadDeContextoPorLicencias { get; set; }
        [ForeignKey("TopeExcepcionUnidadTemporal")]
        public virtual UnidadTemporalRef TopeExcepcionUnidadTemporals { get; set; }

        //public virtual ICollection<LicenciasAgente> LicenciasAgente { get; set; }
		#endregion

	}
}
