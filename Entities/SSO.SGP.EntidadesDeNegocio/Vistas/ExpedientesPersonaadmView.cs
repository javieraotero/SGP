using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesPersonaadmView
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

			[Display(Name = "DomicilioReal")]
			public string DomicilioReal { get; set; }

			[Display(Name = "LocalidadReal")]
			public int? LocalidadReal { get; set; }

			[Display(Name = "Correo")]
			public string Correo { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "DomicilioRepresentanteLegal")]
			public string DomicilioRepresentanteLegal { get; set; }

			[Display(Name = "NombreRepresentanteLegal")]
			public string NombreRepresentanteLegal { get; set; }

			[Display(Name = "LocalidadRepsentanteLegal")]
			public int? LocalidadRepsentanteLegal { get; set; }

			[Display(Name = "CorreoRepresentanteLegal")]
			public string CorreoRepresentanteLegal { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "FechaModificacion")]
			public DateTime? FechaModificacion { get; set; }
			#endregion


	}
}
