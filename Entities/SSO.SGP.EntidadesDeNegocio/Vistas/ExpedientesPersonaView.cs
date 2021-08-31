using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesPersonaView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Rol")]
			public int Rol { get; set; }

			[Display(Name = "BarrioReal")]
			public int? BarrioReal { get; set; }

			[Display(Name = "CalleReal")]
			public int? CalleReal { get; set; }

			[Display(Name = "Calle2Real")]
			public int? Calle2Real { get; set; }

			[Display(Name = "NroReal")]
			public int? NroReal { get; set; }

			[Display(Name = "DomicilioReal")]
			public string DomicilioReal { get; set; }

			[Display(Name = "LocalidadReal")]
			public int? LocalidadReal { get; set; }

			[Display(Name = "Correo")]
			public string Correo { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Telefono")]
			public string Telefono { get; set; }

			[Display(Name = "BarrioProcesal")]
			public int? BarrioProcesal { get; set; }

			[Display(Name = "CalleProcesal")]
			public int? CalleProcesal { get; set; }

			[Display(Name = "NroProcesal")]
			public int? NroProcesal { get; set; }

			[Display(Name = "DomicilioProcesal")]
			public string DomicilioProcesal { get; set; }

			[Display(Name = "LocalidadProcesal")]
			public int? LocalidadProcesal { get; set; }

			[Display(Name = "RepresentanteLegal")]
			public int? RepresentanteLegal { get; set; }

			[Display(Name = "BarrioRepresentanteLegal")]
			public int? BarrioRepresentanteLegal { get; set; }

			[Display(Name = "CalleRepresentanteLegal")]
			public int? CalleRepresentanteLegal { get; set; }

			[Display(Name = "NroRepresentanteLegal")]
			public int? NroRepresentanteLegal { get; set; }

			[Display(Name = "DomicilioRepresentanteLegal")]
			public string DomicilioRepresentanteLegal { get; set; }

			[Display(Name = "LocalidadRepresentanteLegal")]
			public int? LocalidadRepresentanteLegal { get; set; }

			[Display(Name = "Confirmado")]
			public bool Confirmado { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "DefensorResponsable")]
			public int? DefensorResponsable { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }

			[Display(Name = "UsuarioModificacion")]
			public int? UsuarioModificacion { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "UsuarioBaja")]
			public int? UsuarioBaja { get; set; }

			[Display(Name = "Subrogante")]
			public int? Subrogante { get; set; }

			[Display(Name = "EsColaborador")]
			public bool EsColaborador { get; set; }

			[Display(Name = "EsSustituto")]
			public bool EsSustituto { get; set; }

			[Display(Name = "EsAdHoc")]
			public bool EsAdHoc { get; set; }
			#endregion


	}
}
