
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
	[MetadataTypeAttribute(typeof(AudienciasNotificacionMetaData))]
	[Table("AudienciasNotificacion")]
	public partial class AudienciasNotificacion
	{
		#region Constructor
		public AudienciasNotificacion()
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

		public int? Juez_TIP_STJ_FyM { get; set; }

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

		public bool? NotificaMandamientos { get; set; }

		public int? NotificacionDestino { get; set; }

		public int? OficinaOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rechazada")]
		public bool Rechazada { get; set; }

		public int? UsuarioRechazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Urgente")]
		public bool Urgente { get; set; }

		[Required(ErrorMessage = "Debe ingresar Visado")]
		public bool Visado { get; set; }

		public int? UsuarioVisado { get; set; }

		public bool? NotificaPolicia { get; set; }

		public int? DependenciaPolicialDestinoId { get; set; }

		public int? ModeloImpresion { get; set; }

		[StringLength(50, ErrorMessage ="DependenciaPolicialDestino no puede superar los 50 caracteres")]
		public string DependenciaPolicialDestino { get; set; }

		public DateTime? FechaAlta { get; set; }

		[ForeignKey("Parte")]
		public virtual ExpedientesPersona Partes { get; set; }

		[ForeignKey("Juez_TIP_STJ_FyM")]
		public virtual Usuarios Juez_TIP_STJ_FyMs { get; set; }

		[ForeignKey("UsuarioNotificado")]
		public virtual Usuarios UsuarioNotificados { get; set; }

		[ForeignKey("UsuarioAvisado")]
		public virtual Usuarios UsuarioAvisados { get; set; }

		[ForeignKey("AudienciaEstado")]
		public virtual AudienciasEstados AudienciaEstados { get; set; }

		[ForeignKey("NotificacionDestino")]
		public virtual Notificaciones NotificacionDestinos { get; set; }
		#endregion

	}
}
