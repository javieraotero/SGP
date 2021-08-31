using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class MonitoreoActividadesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "FechaInicio")]
			public DateTime FechaInicio { get; set; }

			[Display(Name = "FechaIntervencion")]
			public DateTime FechaIntervencion { get; set; }

			[Display(Name = "Citacion")]
			public bool Citacion { get; set; }

			[Display(Name = "FechaCitacion")]
			public DateTime? FechaCitacion { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "Circunscripcion")]
			public int? Circunscripcion { get; set; }

			[Display(Name = "Derivacion1")]
			public int? Derivacion1 { get; set; }

			[Display(Name = "Derivacion2")]
			public int? Derivacion2 { get; set; }

			[Display(Name = "Derivacion3")]
			public int? Derivacion3 { get; set; }

			[Display(Name = "ViolenciaGenero")]
			public bool ViolenciaGenero { get; set; }

			[Display(Name = "AbusoSexualIntraFamiliar")]
			public bool AbusoSexualIntraFamiliar { get; set; }

			[Display(Name = "AbusoSexualExtraFamiliar")]
			public bool AbusoSexualExtraFamiliar { get; set; }

			[Display(Name = "AbusoSexualInfantilIntraFamiliar")]
			public bool AbusoSexualInfantilIntraFamiliar { get; set; }

			[Display(Name = "AbusoSexualInfantilExtraFamiliar")]
			public bool AbusoSexualInfantilExtraFamiliar { get; set; }

			[Display(Name = "MaltratoInfantil")]
			public bool MaltratoInfantil { get; set; }

			[Display(Name = "TrabajoInfantil")]
			public bool TrabajoInfantil { get; set; }

			[Display(Name = "TestigoViolencia")]
			public bool TestigoViolencia { get; set; }

			[Display(Name = "ViolenciaFamiliar")]
			public bool ViolenciaFamiliar { get; set; }

			[Display(Name = "ViolenciaPareja")]
			public bool ViolenciaPareja { get; set; }

			[Display(Name = "SecuelasOtrosTiposDelito")]
			public bool SecuelasOtrosTiposDelito { get; set; }

			[Display(Name = "Otros")]
			public bool Otros { get; set; }

			[Display(Name = "TotalProblematica")]
			public int TotalProblematica { get; set; }

			[Display(Name = "Intervencion")]
			public bool Intervencion { get; set; }

			[Display(Name = "Diagnostico")]
			public bool Diagnostico { get; set; }

			[Display(Name = "RiesgoAlto")]
			public bool RiesgoAlto { get; set; }

			[Display(Name = "RiesgoMedio")]
			public bool RiesgoMedio { get; set; }

			[Display(Name = "RiesgoBajo")]
			public bool RiesgoBajo { get; set; }

			[Display(Name = "Seguimiento")]
			public bool Seguimiento { get; set; }

			[Display(Name = "TotalInformes")]
			public int TotalInformes { get; set; }

			[Display(Name = "TipoOrigen")]
			public int TipoOrigen { get; set; }

			[Display(Name = "Modalidad")]
			public int Modalidad { get; set; }

			[Display(Name = "AcompanamientoGessel")]
			public bool AcompanamientoGessel { get; set; }

			[Display(Name = "AcompanamientoJuicio")]
			public bool AcompanamientoJuicio { get; set; }

			[Display(Name = "AcompanamientoOtros")]
			public bool AcompanamientoOtros { get; set; }

			[Display(Name = "ArticulacionOtrasInstituciones")]
			public bool ArticulacionOtrasInstituciones { get; set; }

			[Display(Name = "IntervencionTecnicaEnJuicio")]
			public bool IntervencionTecnicaEnJuicio { get; set; }

			[Display(Name = "IntervencionTecnicaEnAudiencia")]
			public bool IntervencionTecnicaEnAudiencia { get; set; }

			[Display(Name = "Consultas")]
			public bool Consultas { get; set; }

			[Display(Name = "Monitoreo")]
			public bool Monitoreo { get; set; }

			[Display(Name = "EntrevistaDomiciliaria")]
			public bool EntrevistaDomiciliaria { get; set; }

			[Display(Name = "TotalIntervenciones")]
			public int TotalIntervenciones { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int UsuarioAlta { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "FechaEliminacion")]
			public DateTime? FechaEliminacion { get; set; }

			[Display(Name = "UsuarioEliminacion")]
			public int? UsuarioEliminacion { get; set; }
			#endregion


	}
}
