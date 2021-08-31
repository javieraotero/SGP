
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
	[MetadataTypeAttribute(typeof(AgentesMetaData))]
	[Table("Agentes")]
	public partial class Agentes
	{
		#region Constructor
		public Agentes()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Legajo")]
		public int Legajo { get; set; }

		[StringLength(30, ErrorMessage = "Telefono no puede superar los 30 caracteres")]
		public string Telefono { get; set; }

		[Required(ErrorMessage = "Debe ingresar Profesion")]
		[StringLength(40, ErrorMessage = "Profesion no puede superar los 40 caracteres")]
		public string Profesion { get; set; }

		[Required(ErrorMessage = "Debe ingresar EstudiosCursados")]
		[StringLength(50, ErrorMessage = "EstudiosCursados no puede superar los 50 caracteres")]
		public string EstudiosCursados { get; set; }

		[StringLength(15, ErrorMessage = "AfiliadoISS no puede superar los 15 caracteres")]
		public string AfiliadoISS { get; set; }

		public DateTime? FechaDeCasamiento { get; set; }

		[Required(ErrorMessage = "Debe ingresar Persona")]
		public int Persona { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activo")]
		public bool Activo { get; set; }

		public DateTime? FechaBaja { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? NumeroPS { get; set; }

		[StringLength(150, ErrorMessage = "Domicilio no puede superar los 150 caracteres")]
		public string Domicilio { get; set; }

		public DateTime? FechaUltimoAscenso { get; set; }

		public int? UltimoCargo { get; set; }

		public string Email { get; set; }

		public DateTime? FechaDeNacimiento { get; set; }

		public bool RequiereSubrogante { get; set; }

		public string CertificadoValidez { get; set; }
		public string CertificadoHorario { get; set; }
		public DateTime? CertificadoFechaDesde { get; set; }
		public DateTime? CertificadoFechaHasta { get; set; }

        public virtual ICollection<Denegatoriasrrhh> Denegatoriasrrhh { get; set; }

        public virtual ICollection<EmbargosyOtros> EmbargosyOtros { get; set; }

        public virtual ICollection<FeriasAgentes> FeriasAgentes { get; set; }

        public virtual ICollection<GrupoFamiliar> GrupoFamiliar { get; set; }

        public virtual ICollection<Imagenesrrhh> Imagenesrrhh { get; set; }

        //public virtual ICollection<LicenciasAgente> LicenciasAgente { get; set; }

        public virtual ICollection<MedidasDisciplinarias> MedidasDisciplinarias { get; set; }

        public virtual ICollection<Nombramientos> Nombramientos { get; set; }

        public virtual ICollection<SaldosDeLicenciasOrdinarias> SaldosDeLicenciasOrdinarias { get; set; }

        public virtual ICollection<Sustituciones> Sustituciones { get; set; }

        public virtual ICollection<LicenciasOrdinariasIniciales> LicenciasOrdinariasIniciales { get; set; }

        public int? AnioExpediente { get; set; }

        public string Celular { get; set; }

        public string Device_Id { get; set; }

        public bool AppActivo { get; set; }

        public string TokenGCM { get; set; }

        public string LegajoSueldo { get; set; }

        public int? PersonaCESIDA { get; set; }

        public bool TieneBonificacion { get; set; }

        public decimal? Bonificacion { get; set; }

        public DateTime? FechaActualizaContactoApp { get; set; }

        public bool Ordinaria3710 { get; set; }

        public DateTime? FechaPrimeraDosis { get; set; }
        public DateTime? FechaSegundaDosis { get; set; }
        public eVacunasCovid? Vacuna { get; set; }
        public bool AgenteDeRiesgo { get; set; }
        public string ObservacionesReconocimiento { get; set; }

        //public DateTime? FechaUltimoOrganismo { get; set; }

        [ForeignKey("Persona")]
		public virtual Personas Personas { get; set; }

		[ForeignKey("UltimoCargo")]
		public virtual CargosRef UltimoCargos { get; set; }
		public int? AgenteSolicitudLicenciaDefault { get; set; }

		#endregion

	}

    public class AgentesSearchModel {

        public string Nombre { get; set; }
        public int? Organismo { get; set; }
        public DateTime? FechaIngresoDesde { get; set; }
        public DateTime? FechaIngresoHasta { get; set; }
        public long? DNI { get; set; }

    }


}
