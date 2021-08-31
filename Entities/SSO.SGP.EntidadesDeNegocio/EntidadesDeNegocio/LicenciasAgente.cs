
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
	[MetadataTypeAttribute(typeof(LicenciasAgenteMetaData))]
	[Table("LicenciasAgente")]
	public partial class LicenciasAgente
	{
		#region Constructor
		public LicenciasAgente()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Agente { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaDesde")]
		public DateTime FechaDesde { get; set; }

		public DateTime? FechaHasta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Licencia")]
		public int Licencia { get; set; }

		public int? Subrogante { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		public int? UsuarioElimina { get; set; }

		public int? AgenteRRHH { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

        public string Estado { get; set; }

        public bool SinEfecto { get; set; }

        public int? Nombramiento { get; set; }

        public bool Aprobada { get; set; }

        public DateTime? FechaAprobada { get; set; }

        public int? AgenteAprobada { get; set; }

        public bool SolicitadaPorApp { get; set; }

        public string Token { get; set; }

        public bool VistoRRHH { get; set; }

        public DateTime? FechaVistoRRHH { get; set; } 

        public int? SubroganteRRHH { get; set; }

        public bool SubroganteAprobada { get; set; }

        public DateTime? SubroganteAprobadaFecha { get; set; }

        public int? Certificado { get; set; }
        public int? Certificado2 { get; set; }
        public string CodigoEnfermedad { get; set; }
        public string ObservacionesReconocimiento { get; set; }
        public bool ApruebaReconocimiento { get; set; }
        public DateTime? FechaApruebaReconocimiento { get; set; }

        [ForeignKey("Nombramiento")]
        public virtual Nombramientos Nombramientos { get; set; }

        //[ForeignKey("Agente")]
        //public virtual Usuarios Agentes { get; set; }

		[ForeignKey("Licencia")]
		public virtual LicenciasRef Licencias { get; set; }

        //[ForeignKey("Subrogante")]
        //public virtual Usuarios Subrogantes { get; set; }

		[ForeignKey("AgenteRRHH")]
		public virtual Agentes AgenteRRHHs { get; set; }
		#endregion

	}
}
