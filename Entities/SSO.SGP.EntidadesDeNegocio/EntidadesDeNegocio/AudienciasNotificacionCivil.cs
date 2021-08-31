
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
	[MetadataTypeAttribute(typeof(AudienciasNotificacionCivilMetaData))]
	[Table("AudienciasNotificacionCivil")]
	public partial class AudienciasNotificacionCivil
	{
		#region Constructor
		public AudienciasNotificacionCivil()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Audiencia")]
		public int Audiencia { get; set; }

		public int? Parte { get; set; }

		public DateTime? FechaNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar FueNotificado")]
		public bool FueNotificado { get; set; }

		public int? UsuarioNotificado { get; set; }

		public DateTime? FechaAviso { get; set; }

		[Required(ErrorMessage = "Debe ingresar FueAvisado")]
		public bool FueAvisado { get; set; }

		public int? UsuarioAvisado { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar AudienciaEstado")]
		public int AudienciaEstado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Asistio")]
		public bool Asistio { get; set; }

		public DateTime? FechaHoraCitacion { get; set; }

		public DateTime? FechaImpresion { get; set; }

		public int? Numerador { get; set; }

		public bool? AutomaticamenteNotificado { get; set; }

		public bool? Activo { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		public int? UsuarioElimina { get; set; }

		[StringLength(100, ErrorMessage ="MotivoElimina no puede superar los 100 caracteres")]
		public string MotivoElimina { get; set; }

		[ForeignKey("Parte")]
		public virtual Conexiones Partes { get; set; }

		[ForeignKey("UsuarioNotificado")]
		public virtual Usuarios UsuarioNotificados { get; set; }

		[ForeignKey("UsuarioAvisado")]
		public virtual Usuarios UsuarioAvisados { get; set; }

		[ForeignKey("AudienciaEstado")]
		public virtual AudienciasEstadosCivil AudienciaEstados { get; set; }
		#endregion

	}
}
