using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class AudienciasCivilViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "FechaFin")]
			public DateTime? FechaFin { get; set; }

			[Display(Name = "HoraInicio")]
			public string HoraInicio { get; set; }

			[Display(Name = "HoraFin")]
			public string HoraFin { get; set; }

			[Display(Name = "EsPublica")]
			public bool EsPublica { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "HoraRealInicio")]
			public string HoraRealInicio { get; set; }

			[Display(Name = "HoraRealFin")]
			public string HoraRealFin { get; set; }

			[Display(Name = "Sala")]
			public int Sala { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "MotivoCancelacion")]
			public int? MotivoCancelacion { get; set; }

			[Display(Name = "MotivoPostergacion")]
			public int? MotivoPostergacion { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Ambito")]
			public int? Ambito { get; set; }

			[Display(Name = "Causa")]
			public int? Causa { get; set; }

			[Display(Name = "Publicar")]
			public bool? Publicar { get; set; }

			[Display(Name = "PublicarSinCaratula")]
			public bool? PublicarSinCaratula { get; set; }

			[Display(Name = "NoPublicar")]
			public bool? NoPublicar { get; set; }

			[Display(Name = "SinMediacionPorAusenciaPartes")]
			public bool? SinMediacionPorAusenciaPartes { get; set; }

			[Display(Name = "SinMediacionPorDecisionPartes")]
			public bool? SinMediacionPorDecisionPartes { get; set; }

			[Display(Name = "AcuerdoTotalMediacion")]
			public bool? AcuerdoTotalMediacion { get; set; }

			[Display(Name = "AcuerdoParcialMediacion")]
			public bool? AcuerdoParcialMediacion { get; set; }

			[Display(Name = "SinAcuerdoProvisoriamente")]
			public bool? SinAcuerdoProvisoriamente { get; set; }

			[Display(Name = "SinAcuerdoDefinitivamente")]
			public bool? SinAcuerdoDefinitivamente { get; set; }

			[Display(Name = "CasoNoMediableProvisoriamente")]
			public bool? CasoNoMediableProvisoriamente { get; set; }

			[Display(Name = "CasoNoMediableDefinitivamente")]
			public bool? CasoNoMediableDefinitivamente { get; set; }

			[Display(Name = "ObservacionesMediacion")]
			public string ObservacionesMediacion { get; set; }
			#endregion


	}
}
