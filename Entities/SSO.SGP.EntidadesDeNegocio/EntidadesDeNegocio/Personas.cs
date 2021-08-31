
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
	[MetadataTypeAttribute(typeof(PersonasMetaData))]
	[Table("Personas")]
	public partial class Personas
	{
		#region Constructor
		public Personas()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Apellidos")]
		[StringLength(100, ErrorMessage ="Apellidos no puede superar los 100 caracteres")]
		public string Apellidos { get; set; }

		[Required(ErrorMessage = "Debe ingresar Nombres")]
		[StringLength(100, ErrorMessage ="Nombres no puede superar los 100 caracteres")]
		public string Nombres { get; set; }

		public int? TipoDocumento { get; set; }

        [Required(ErrorMessage="Debe ingresar Documento")]
		public long? NroDocumento { get; set; }

		public DateTime? FechaNacimiento { get; set; }

		[StringLength(100, ErrorMessage ="LugarNacimiento no puede superar los 100 caracteres")]
		public string LugarNacimiento { get; set; }

		public int? Sexo { get; set; }

		[Required(ErrorMessage = "Debe ingresar EsMenor")]
		public bool EsMenor { get; set; }

		[StringLength(100, ErrorMessage ="Alias no puede superar los 100 caracteres")]
		public string Alias { get; set; }

		[Required(ErrorMessage = "Debe ingresar PersonaFisica")]
		public bool PersonaFisica { get; set; }

		public int? Barrio { get; set; }

		public int? Calle { get; set; }

		[StringLength(100, ErrorMessage ="Domicilio no puede superar los 100 caracteres")]
		public string Domicilio { get; set; }

		public int? Localidad { get; set; }

		[StringLength(100, ErrorMessage ="Ocupacion no puede superar los 100 caracteres")]
		public string Ocupacion { get; set; }

		[StringLength(100, ErrorMessage ="Nacionalidad no puede superar los 100 caracteres")]
		public string Nacionalidad { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		[StringLength(100, ErrorMessage ="Telefono no puede superar los 100 caracteres")]
		public string Telefono { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fallecido")]
		public bool Fallecido { get; set; }

		public DateTime? FechaDefuncion { get; set; }

		public int? TipoEscolaridad { get; set; }

		public int? EstadoEscolaridad { get; set; }

		public int? TipoOcupacion { get; set; }

		public int? EstadoCivil { get; set; }

		[Required(ErrorMessage = "Debe ingresar Ocupado")]
		public bool Ocupado { get; set; }

		[Required(ErrorMessage = "Debe ingresar ObraSocial")]
		public bool ObraSocial { get; set; }

		[Required(ErrorMessage = "Debe ingresar Detenido")]
		public bool Detenido { get; set; }

		[Required(ErrorMessage = "Debe ingresar IncluirIdentikit")]
		public bool IncluirIdentikit { get; set; }

		[StringLength(255, ErrorMessage ="FotoIdentikit no puede superar los 255 caracteres")]
		public string FotoIdentikit { get; set; }

		[StringLength(255, ErrorMessage ="RegistroVoz no puede superar los 255 caracteres")]
		public string RegistroVoz { get; set; }

		[Required(ErrorMessage = "Debe ingresar ColorOjos")]
		public int ColorOjos { get; set; }

		[Required(ErrorMessage = "Debe ingresar ColorPelo")]
		public int ColorPelo { get; set; }

		[Required(ErrorMessage = "Debe ingresar LongitudPelo")]
		public int LongitudPelo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Altura")]
		public int Altura { get; set; }

		[Required(ErrorMessage = "Debe ingresar Peso")]
		public int Peso { get; set; }

		[Required(ErrorMessage = "Debe ingresar Piel")]
		public int Piel { get; set; }

		[Required(ErrorMessage = "Debe ingresar BarbaBigote")]
		public int BarbaBigote { get; set; }

		[Required(ErrorMessage = "Debe ingresar LongitudBarbaBigote")]
		public int LongitudBarbaBigote { get; set; }

		[Required(ErrorMessage = "Debe ingresar ColorBarbaBigote")]
		public int ColorBarbaBigote { get; set; }

		[Required(ErrorMessage = "Debe ingresar PielVarios")]
		public int PielVarios { get; set; }

		[Required(ErrorMessage = "Debe ingresar Varios")]
		public int Varios { get; set; }

		[Required(ErrorMessage = "Debe ingresar Tonada")]
		public int Tonada { get; set; }

		[Required(ErrorMessage = "Debe ingresar CriterioOportunidadArt15")]
		public bool CriterioOportunidadArt15 { get; set; }

		[StringLength(100, ErrorMessage ="Celular no puede superar los 100 caracteres")]
		public string Celular { get; set; }

		[StringLength(100, ErrorMessage ="TelefonoTrabajo no puede superar los 100 caracteres")]
		public string TelefonoTrabajo { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioTrabajo no puede superar los 100 caracteres")]
		public string DomicilioTrabajo { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		public int? ActuacionCriterioOportunidad { get; set; }

		public DateTime? FechaCriterioOportunidad { get; set; }

		public int? UsuarioCriterioOportunidad { get; set; }

		[StringLength(255, ErrorMessage ="ObservacionCriterioOportunidad no puede superar los 255 caracteres")]
		public string ObservacionCriterioOportunidad { get; set; }

		[StringLength(255, ErrorMessage ="Observaciones no puede superar los 255 caracteres")]
		public string Observaciones { get; set; }

		public DateTime? FechaEliminacion { get; set; }

		public int? UsuarioEliminacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public int? UsuarioModificacion { get; set; }

		[StringLength(255, ErrorMessage ="NombrePadre no puede superar los 255 caracteres")]
        [Column("DatosPadre")]
		public string NombrePadre { get; set; }

		[StringLength(255, ErrorMessage ="NombreMadre no puede superar los 255 caracteres")]
        [Column("DatosMadre")]
        public string NombreMadre { get; set; }

		public int? ActuacionSuspencionProcesoAPrueba { get; set; }

		public DateTime? FechaSuspencionProcesoAPrueba { get; set; }

		public int? UsuarioSuspencionProcesoAPrueba { get; set; }

		[StringLength(255, ErrorMessage ="ObservacionSuspencionProcesoAPrueba no puede superar los 255 caracteres")]
		public string ObservacionSuspencionProcesoAPrueba { get; set; }

		[Required(ErrorMessage = "Debe ingresar SuspencionProcesoAPrueba")]
		public bool SuspencionProcesoAPrueba { get; set; }

		public int? Concurso { get; set; }

		[StringLength(100, ErrorMessage ="DomicilioProcesal no puede superar los 100 caracteres")]
		public string DomicilioProcesal { get; set; }

		public int? LocalidadProcesal { get; set; }

        //public virtual ICollection<Agentes> Agentes { get; set; }

        //public virtual ICollection<CausasDocumento> CausasDocumento { get; set; }

        //public virtual ICollection<Conexiones> Conexiones { get; set; }

        //public virtual ICollection<ElementosSecuestradosMovimiento> ElementosSecuestradosMovimiento { get; set; }

        //public virtual ICollection<ExpedientesDocumento> ExpedientesDocumentoDocumentacion { get; set; }

        //public virtual ICollection<ExpedientesDocumentoadm> ExpedientesDocumentoadm { get; set; }

        //public virtual ICollection<ExpedientesPersona> ExpedientesPersona { get; set; }

        //public virtual ICollection<ExpedientesPersona> ExpedientesPersona1 { get; set; }

        //public virtual ICollection<ExpedientesPersonaadm> ExpedientesPersonaadm { get; set; }

        //public virtual ICollection<ExpedientesPersonaDetenida> ExpedientesPersonaDetenida { get; set; }

        //public virtual ICollection<MonitoreoActividades> MonitoreoActividades { get; set; }

        //public virtual ICollection<Notificaciones> Notificaciones { get; set; }

        //public virtual ICollection<NotificacionesCivil> NotificacionesCivil { get; set; }

        //public virtual ICollection<OrdenesCaptura> OrdenesCaptura { get; set; }

        //public virtual ICollection<Peritos> Peritos { get; set; }

		[ForeignKey("TipoDocumento")]
		public virtual TiposDocumentoRef TipoDocumentos { get; set; }

		[ForeignKey("Sexo")]
		public virtual SexosRef Sexos { get; set; }

		[ForeignKey("Barrio")]
		public virtual BarriosRef Barrios { get; set; }

		[ForeignKey("Calle")]
		public virtual CallesRef Calles { get; set; }

		[ForeignKey("Localidad")]
		public virtual LocalidadesRef Localidads { get; set; }

		[ForeignKey("TipoEscolaridad")]
		public virtual TiposEscolaridadRef TipoEscolaridads { get; set; }

		[ForeignKey("EstadoEscolaridad")]
		public virtual EstadosEscolaridadRef EstadoEscolaridads { get; set; }

		[ForeignKey("TipoOcupacion")]
		public virtual TiposOcupacionRef TipoOcupacions { get; set; }

		[ForeignKey("EstadoCivil")]
		public virtual EstadosCivilRef EstadoCivils { get; set; }

        //[ForeignKey("ColorOjos")]
        //public virtual PersonasCaracteristicasRef ColorOjoss { get; set; }

        //[ForeignKey("ColorPelo")]
        //public virtual PersonasCaracteristicasRef ColorPelos { get; set; }

        //[ForeignKey("LongitudPelo")]
        //public virtual PersonasCaracteristicasRef LongitudPelos { get; set; }

        //[ForeignKey("Altura")]
        //public virtual PersonasCaracteristicasRef Alturas { get; set; }

        //[ForeignKey("Peso")]
        //public virtual PersonasCaracteristicasRef Pesos { get; set; }

        //[ForeignKey("Piel")]
        //public virtual PersonasCaracteristicasRef Piels { get; set; }

        //[ForeignKey("BarbaBigote")]
        //public virtual PersonasCaracteristicasRef BarbaBigotes { get; set; }

        //[ForeignKey("LongitudBarbaBigote")]
        //public virtual PersonasCaracteristicasRef LongitudBarbaBigotes { get; set; }

        //[ForeignKey("ColorBarbaBigote")]
        //public virtual PersonasCaracteristicasRef ColorBarbaBigotes { get; set; }

        //[ForeignKey("PielVarios")]
        //public virtual PersonasCaracteristicasRef PielVarioss { get; set; }

        //[ForeignKey("Varios")]
        //public virtual PersonasCaracteristicasRef Varioss { get; set; }

        //[ForeignKey("Tonada")]
        //public virtual PersonasCaracteristicasRef Tonadas { get; set; }

        //[ForeignKey("ActuacionCriterioOportunidad")]
        //public virtual Actuaciones ActuacionCriterioOportunidads { get; set; }

        //[ForeignKey("UsuarioCriterioOportunidad")]
        //public virtual Usuarios UsuarioCriterioOportunidads { get; set; }

        //[ForeignKey("ActuacionSuspencionProcesoAPrueba")]
        //public virtual Actuaciones ActuacionSuspencionProcesoAPruebas { get; set; }

        //[ForeignKey("Concurso")]
        //public virtual Concursos Concursos { get; set; }
		#endregion

	}
}
