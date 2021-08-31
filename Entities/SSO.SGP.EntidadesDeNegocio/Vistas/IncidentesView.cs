using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class IncidentesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "UsuarioSolicitante")]
			public int UsuarioSolicitante { get; set; }

			[Display(Name = "AmbitoSolicitante")]
			public int AmbitoSolicitante { get; set; }

			[Display(Name = "SubambitoSolicitante")]
			public int? SubambitoSolicitante { get; set; }

			[Display(Name = "FechaHoraSolicitud")]
			public DateTime FechaHoraSolicitud { get; set; }

			[Display(Name = "EstadoActual")]
			public int EstadoActual { get; set; }

			[Display(Name = "FechaUltimoCambioEstado")]
			public DateTime? FechaUltimoCambioEstado { get; set; }

			[Display(Name = "Prioridad")]
			public int Prioridad { get; set; }

			[Display(Name = "Titulo")]
			public string Titulo { get; set; }

			[Display(Name = "Problema")]
			public string Problema { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Version")]
			public string Version { get; set; }

			[Display(Name = "Etiquetas")]
			public string Etiquetas { get; set; }

			[Display(Name = "TesteadoUsuario")]
			public int? TesteadoUsuario { get; set; }

			[Display(Name = "TesteadoDesarrollador")]
			public int? TesteadoDesarrollador { get; set; }

			[Display(Name = "TesteadoSupervisor")]
			public int? TesteadoSupervisor { get; set; }

			[Display(Name = "Desarrollador")]
			public int? Desarrollador { get; set; }

			[Display(Name = "PrioridadDesarrollo")]
			public int? PrioridadDesarrollo { get; set; }
			#endregion


	}
}
