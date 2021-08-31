
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
	[MetadataTypeAttribute(typeof(MonitoreoActividadesMetaData))]
	[Table("MonitoreoActividades")]
	public partial class MonitoreoActividades
	{
		#region Constructor
		public MonitoreoActividades()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaInicio")]
		public DateTime FechaInicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaIntervencion")]
		public DateTime FechaIntervencion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Citacion")]
		public bool Citacion { get; set; }

		public DateTime? FechaCitacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		public int? Expediente { get; set; }

		public int? Circunscripcion { get; set; }

		public int? Derivacion1 { get; set; }

		public int? Derivacion2 { get; set; }

		public int? Derivacion3 { get; set; }

		[Required(ErrorMessage = "Debe ingresar ViolenciaGenero")]
		public bool ViolenciaGenero { get; set; }

		[Required(ErrorMessage = "Debe ingresar AbusoSexualIntraFamiliar")]
		public bool AbusoSexualIntraFamiliar { get; set; }

		[Required(ErrorMessage = "Debe ingresar AbusoSexualExtraFamiliar")]
		public bool AbusoSexualExtraFamiliar { get; set; }

		[Required(ErrorMessage = "Debe ingresar AbusoSexualInfantilIntraFamiliar")]
		public bool AbusoSexualInfantilIntraFamiliar { get; set; }

		[Required(ErrorMessage = "Debe ingresar AbusoSexualInfantilExtraFamiliar")]
		public bool AbusoSexualInfantilExtraFamiliar { get; set; }

		[Required(ErrorMessage = "Debe ingresar MaltratoInfantil")]
		public bool MaltratoInfantil { get; set; }

		[Required(ErrorMessage = "Debe ingresar TrabajoInfantil")]
		public bool TrabajoInfantil { get; set; }

		[Required(ErrorMessage = "Debe ingresar TestigoViolencia")]
		public bool TestigoViolencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar ViolenciaFamiliar")]
		public bool ViolenciaFamiliar { get; set; }

		[Required(ErrorMessage = "Debe ingresar ViolenciaPareja")]
		public bool ViolenciaPareja { get; set; }

		[Required(ErrorMessage = "Debe ingresar SecuelasOtrosTiposDelito")]
		public bool SecuelasOtrosTiposDelito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Otros")]
		public bool Otros { get; set; }

		[Required(ErrorMessage = "Debe ingresar TotalProblematica")]
		public int TotalProblematica { get; set; }

		[Required(ErrorMessage = "Debe ingresar Intervencion")]
		public bool Intervencion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Diagnostico")]
		public bool Diagnostico { get; set; }

		[Required(ErrorMessage = "Debe ingresar RiesgoAlto")]
		public bool RiesgoAlto { get; set; }

		[Required(ErrorMessage = "Debe ingresar RiesgoMedio")]
		public bool RiesgoMedio { get; set; }

		[Required(ErrorMessage = "Debe ingresar RiesgoBajo")]
		public bool RiesgoBajo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Seguimiento")]
		public bool Seguimiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar TotalInformes")]
		public int TotalInformes { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoOrigen")]
		public int TipoOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar Modalidad")]
		public int Modalidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar AcompanamientoGessel")]
		public bool AcompanamientoGessel { get; set; }

		[Required(ErrorMessage = "Debe ingresar AcompanamientoJuicio")]
		public bool AcompanamientoJuicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar AcompanamientoOtros")]
		public bool AcompanamientoOtros { get; set; }

		[Required(ErrorMessage = "Debe ingresar ArticulacionOtrasInstituciones")]
		public bool ArticulacionOtrasInstituciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar IntervencionTecnicaEnJuicio")]
		public bool IntervencionTecnicaEnJuicio { get; set; }

		[Required(ErrorMessage = "Debe ingresar IntervencionTecnicaEnAudiencia")]
		public bool IntervencionTecnicaEnAudiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Consultas")]
		public bool Consultas { get; set; }

		[Required(ErrorMessage = "Debe ingresar Monitoreo")]
		public bool Monitoreo { get; set; }

		[Required(ErrorMessage = "Debe ingresar EntrevistaDomiciliaria")]
		public bool EntrevistaDomiciliaria { get; set; }

		[Required(ErrorMessage = "Debe ingresar TotalIntervenciones")]
		public int TotalIntervenciones { get; set; }

		[StringLength(8000, ErrorMessage ="Observaciones no puede superar los 8000 caracteres")]
		public string Observaciones { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar UsuarioAlta")]
		public int UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		public int? UsuarioEliminacion { get; set; }

		[ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Circunscripcion")]
		public virtual CircunscripcionesRef Circunscripcions { get; set; }

		[ForeignKey("TipoOrigen")]
		public virtual TiposOrigenoaVyt TipoOrigens { get; set; }

		[ForeignKey("Modalidad")]
		public virtual ModalidadesAsistenciaoaVyt Modalidads { get; set; }
		#endregion

	}
}
