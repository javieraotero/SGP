using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class NotificacionesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public string Expediente { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "JuzgadoOriginante")]
			public int JuzgadoOriginante { get; set; }

			[Display(Name = "Destinatario")]
			public int? Destinatario { get; set; }

			[Display(Name = "Firmante")]
			public string Firmante { get; set; }

			[Display(Name = "Sector")]
			public int Sector { get; set; }

			[Display(Name = "TipoNotificacion")]
			public int TipoNotificacion { get; set; }

			[Display(Name = "OficialNotificador")]
			public int OficialNotificador { get; set; }

			[Display(Name = "Notificado")]
			public bool Notificado { get; set; }

			[Display(Name = "Resultado")]
			public int? Resultado { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaNotificado")]
			public DateTime? FechaNotificado { get; set; }

			[Display(Name = "UsuarioTildoNotificacion")]
			public int? UsuarioTildoNotificacion { get; set; }

			[Display(Name = "IDActuacionNotificacion")]
			public int? IDActuacionNotificacion { get; set; }

			[Display(Name = "Numero")]
			public int Numero { get; set; }

			[Display(Name = "OficialNotifico")]
			public int OficialNotifico { get; set; }

			[Display(Name = "DestinatarioDesdeMyN")]
			public string DestinatarioDesdeMyN { get; set; }

			[Display(Name = "DomicilioDestinatarioDesdeMyN")]
			public string DomicilioDestinatarioDesdeMyN { get; set; }

			[Display(Name = "Motivo")]
			public string Motivo { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "Copias")]
			public bool Copias { get; set; }

			[Display(Name = "FirmaNotificacion")]
			public string FirmaNotificacion { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "IdExpediente")]
			public int? IdExpediente { get; set; }

			[Display(Name = "IdActuacionAdjunta")]
			public int? IdActuacionAdjunta { get; set; }

			[Display(Name = "DomicilioDestinatario")]
			public string DomicilioDestinatario { get; set; }

			[Display(Name = "IDAudienciaNotificacion")]
			public int? IDAudienciaNotificacion { get; set; }
			#endregion


	}
}
