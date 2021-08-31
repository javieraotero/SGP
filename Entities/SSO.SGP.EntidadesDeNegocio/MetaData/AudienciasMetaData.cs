using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AudienciasMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }

			[Display(Name = "SolicitudAudiencia")]
			public int? SolicitudAudiencia { get; set; }

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

			[Display(Name = "Juez")]
			public int Juez { get; set; }

			[Display(Name = "Juez2")]
			public int? Juez2 { get; set; }

			[Display(Name = "Juez3")]
			public int? Juez3 { get; set; }

			[Display(Name = "EsJuez")]
			public bool EsJuez { get; set; }

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

			[Display(Name = "Recusacion")]
			public bool? Recusacion { get; set; }

			[Display(Name = "ActividadProcesalDefectuosa")]
			public bool? ActividadProcesalDefectuosa { get; set; }

			[Display(Name = "SustitucionMedidaCoercion")]
			public bool? SustitucionMedidaCoercion { get; set; }

			[Display(Name = "SentenciaSobreseimiento")]
			public bool? SentenciaSobreseimiento { get; set; }

			[Display(Name = "ImpugnacionDecisionJuicio")]
			public bool? ImpugnacionDecisionJuicio { get; set; }

			[Display(Name = "Ambito")]
			public int? Ambito { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "GesellPositiva")]
			public bool? GesellPositiva { get; set; }

			[Display(Name = "GesellNegativa")]
			public bool? GesellNegativa { get; set; }

			[Display(Name = "GesellNoCorresponde")]
			public bool? GesellNoCorresponde { get; set; }

			[Display(Name = "Publicar")]
			public bool? Publicar { get; set; }

			[Display(Name = "PublicarSinCaratula")]
			public bool? PublicarSinCaratula { get; set; }

			[Display(Name = "NoPublicar")]
			public bool? NoPublicar { get; set; }
			#endregion


	}
}
