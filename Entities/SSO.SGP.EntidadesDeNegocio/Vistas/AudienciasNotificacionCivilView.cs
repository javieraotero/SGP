using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AudienciasNotificacionCivilView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Audiencia")]
			public int Audiencia { get; set; }

			[Display(Name = "Parte")]
			public int? Parte { get; set; }

			[Display(Name = "FechaNotificacion")]
			public DateTime? FechaNotificacion { get; set; }

			[Display(Name = "FueNotificado")]
			public bool FueNotificado { get; set; }

			[Display(Name = "UsuarioNotificado")]
			public int? UsuarioNotificado { get; set; }

			[Display(Name = "FechaAviso")]
			public DateTime? FechaAviso { get; set; }

			[Display(Name = "FueAvisado")]
			public bool FueAvisado { get; set; }

			[Display(Name = "UsuarioAvisado")]
			public int? UsuarioAvisado { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "AudienciaEstado")]
			public int AudienciaEstado { get; set; }

			[Display(Name = "Asistio")]
			public bool Asistio { get; set; }

			[Display(Name = "FechaHoraCitacion")]
			public DateTime? FechaHoraCitacion { get; set; }

			[Display(Name = "FechaImpresion")]
			public DateTime? FechaImpresion { get; set; }

			[Display(Name = "Numerador")]
			public int? Numerador { get; set; }

			[Display(Name = "AutomaticamenteNotificado")]
			public bool? AutomaticamenteNotificado { get; set; }

			[Display(Name = "Activo")]
			public bool? Activo { get; set; }

			[Display(Name = "FechaEliminacion")]
			public DateTime? FechaEliminacion { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "MotivoElimina")]
			public string MotivoElimina { get; set; }
			#endregion


	}
}
