using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ActuacionesNotificacionMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Actuacion")]
			public int Actuacion { get; set; }

			[Display(Name = "Parte")]
			public int Parte { get; set; }

			[Display(Name = "FechaNotificacion")]
			public DateTime? FechaNotificacion { get; set; }

			[Display(Name = "FueNotificado")]
			public bool FueNotificado { get; set; }

			[Display(Name = "FechaAviso")]
			public DateTime? FechaAviso { get; set; }

			[Display(Name = "FueAvisado")]
			public bool FueAvisado { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaImpresion")]
			public DateTime? FechaImpresion { get; set; }

			[Display(Name = "AutomaticamenteNotificado")]
			public bool? AutomaticamenteNotificado { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "UsuarioNotificado")]
			public int? UsuarioNotificado { get; set; }

			[Display(Name = "UsuarioAvisado")]
			public int? UsuarioAvisado { get; set; }

			[Display(Name = "NotificaMandamientos")]
			public bool? NotificaMandamientos { get; set; }

			[Display(Name = "NotificacionDestino")]
			public int? NotificacionDestino { get; set; }

			[Display(Name = "OficinaOrigen")]
			public int? OficinaOrigen { get; set; }

			[Display(Name = "Rechazada")]
			public bool Rechazada { get; set; }

			[Display(Name = "UsuarioRechazo")]
			public int? UsuarioRechazo { get; set; }

			[Display(Name = "Urgente")]
			public bool Urgente { get; set; }

			[Display(Name = "IdActuacionAdjunta")]
			public int? IdActuacionAdjunta { get; set; }

			[Display(Name = "Visado")]
			public bool Visado { get; set; }

			[Display(Name = "UsuarioVisado")]
			public int? UsuarioVisado { get; set; }

			[Display(Name = "NotificaPolicia")]
			public bool? NotificaPolicia { get; set; }

			[Display(Name = "DependenciaPolicialDestinoId")]
			public int? DependenciaPolicialDestinoId { get; set; }

			[Display(Name = "DependenciaPolicialDestino")]
			public string DependenciaPolicialDestino { get; set; }

			[Display(Name = "ParteRepresentada")]
			public int? ParteRepresentada { get; set; }

			[Display(Name = "CircunscripcionRecibe")]
			public int? CircunscripcionRecibe { get; set; }
			#endregion


	}
}
