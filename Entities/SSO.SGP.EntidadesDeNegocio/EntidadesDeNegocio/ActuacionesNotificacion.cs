
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
	[MetadataTypeAttribute(typeof(ActuacionesNotificacionMetaData))]
	[Table("ActuacionesNotificacion")]
	public partial class ActuacionesNotificacion
	{
		#region Constructor
		public ActuacionesNotificacion()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Actuacion")]
		public int Actuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Parte")]
		public int Parte { get; set; }

		public DateTime? FechaNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar FueNotificado")]
		public bool FueNotificado { get; set; }

		public DateTime? FechaAviso { get; set; }

		[Required(ErrorMessage = "Debe ingresar FueAvisado")]
		public bool FueAvisado { get; set; }

		[Required(ErrorMessage = "Debe ingresar Observaciones")]
		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		public DateTime? FechaImpresion { get; set; }

		public bool? AutomaticamenteNotificado { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		public int? UsuarioNotificado { get; set; }

		public int? UsuarioAvisado { get; set; }

		public bool? NotificaMandamientos { get; set; }

		public int? NotificacionDestino { get; set; }

		public int? OficinaOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar Rechazada")]
		public bool Rechazada { get; set; }

		public int? UsuarioRechazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Urgente")]
		public bool Urgente { get; set; }

		public int? IdActuacionAdjunta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Visado")]
		public bool Visado { get; set; }

		public int? UsuarioVisado { get; set; }

		public bool? NotificaPolicia { get; set; }

		public int? DependenciaPolicialDestinoId { get; set; }

		[StringLength(50, ErrorMessage ="DependenciaPolicialDestino no puede superar los 50 caracteres")]
		public string DependenciaPolicialDestino { get; set; }

		public int? ParteRepresentada { get; set; }

		public int? CircunscripcionRecibe { get; set; }

		[ForeignKey("Actuacion")]
		public virtual Actuaciones Actuacions { get; set; }

		[ForeignKey("Parte")]
		public virtual ExpedientesPersona Partes { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }

		[ForeignKey("NotificacionDestino")]
		public virtual Notificaciones NotificacionDestinos { get; set; }

		[ForeignKey("OficinaOrigen")]
		public virtual OrganismosRef OficinaOrigens { get; set; }
		#endregion

	}
}
