
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
	[MetadataTypeAttribute(typeof(ActuacionesMetaData))]
	[Table("Actuaciones")]
	public partial class Actuaciones
	{
		#region Constructor
		public Actuaciones()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Expediente { get; set; }

		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

		public int? Preventivo { get; set; }

		[Required(ErrorMessage = "Debe ingresar TipoActuacion")]
		public int TipoActuacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Fecha")]
		public DateTime Fecha { get; set; }

		public DateTime? FechaVencimiento { get; set; }

		public DateTime? FechaAlerta { get; set; }

		[Required(ErrorMessage = "Debe ingresar FechaAlta")]
		public DateTime FechaAlta { get; set; }

		public int? UsuarioAlta { get; set; }

		[Required(ErrorMessage = "Debe ingresar Usuario")]
		public int Usuario { get; set; }

		[Required(ErrorMessage = "Debe ingresar Estado")]
		public int Estado { get; set; }

		public DateTime? FechaUltimaModificacion { get; set; }

		[StringLength(2147483647, ErrorMessage ="Fundamento no puede superar los 2147483647 caracteres")]
		public string Fundamento { get; set; }

		public DateTime? FechaRecepcion { get; set; }

		public int? UsuarioRecepcion { get; set; }

		[Required(ErrorMessage = "Debe ingresar Confirmado")]
		public bool Confirmado { get; set; }

		public DateTime? FechaFinPlazo { get; set; }

		public int? OficinaOrigen { get; set; }

		public int? SubAmbitoOrigen { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarDefensor")]
		public bool MostrarDefensor { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarFiscal")]
		public bool MostrarFiscal { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarJuez")]
		public bool MostrarJuez { get; set; }

		public bool? RequiereCargo { get; set; }

		public int? SubAmbitoCargo { get; set; }

		public DateTime? FechaCargo { get; set; }

		public int? UsuarioCargo { get; set; }

		public DateTime? FechaEliminada { get; set; }

		public int? UsuarioElimina { get; set; }

		public DateTime? FechaPublicacion { get; set; }

		public int? UsuarioPublica { get; set; }

		public int? Firmante1 { get; set; }

		public DateTime? FechaFirmante1 { get; set; }

		public int? Firmante2 { get; set; }

		public DateTime? FechaFirmante2 { get; set; }

		public int? Firmante3 { get; set; }

		public DateTime? FechaFirmante3 { get; set; }

		public int? Firmante4 { get; set; }

		public DateTime? FechaFirmante4 { get; set; }

		public int? Firmante5 { get; set; }

		public DateTime? FechaFirmante5 { get; set; }

		public int? CantidadFirmantes { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarTIP")]
		public bool MostrarTIP { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarSTJ")]
		public bool MostrarSTJ { get; set; }

		[StringLength(250, ErrorMessage ="MotivoAnulacion no puede superar los 250 caracteres")]
		public string MotivoAnulacion { get; set; }

		public DateTime? FechaAnulacion { get; set; }

		public int? UsuarioAnulacion { get; set; }

		public bool? Protocolizado { get; set; }

		public DateTime? FechaProtocolizado { get; set; }

		public int? UsuarioProtocolizado { get; set; }

		public int? Protocolo { get; set; }

		public int? OficinaCargo { get; set; }

		public bool? Bloqueado { get; set; }

		public int? UsuarioBloquea { get; set; }

		public DateTime? FechaBloqueo { get; set; }

		public int? ModalidadDiasFechaPlazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarJuezAudiencia")]
		public bool MostrarJuezAudiencia { get; set; }

		public int? SubAmbitoProtocolizado { get; set; }

		public int? CategoriaProtocolizado { get; set; }

		public int? ModeloAplicado { get; set; }

		[Required(ErrorMessage = "Debe ingresar VisadoJefatura")]
		public bool VisadoJefatura { get; set; }

		public int? UsuarioJefatura { get; set; }

		public DateTime? FechaJefatura { get; set; }

		[Required(ErrorMessage = "Debe ingresar VisadoSubJefatura")]
		public bool VisadoSubJefatura { get; set; }

		public int? UsuarioSubJefatura { get; set; }

		public DateTime? FechaSubJefatura { get; set; }

		[Required(ErrorMessage = "Debe ingresar VisadoJefeDeptoJudiciales")]
		public bool VisadoJefeDeptoJudiciales { get; set; }

		public int? UsuarioJefeDeptoJudiciales { get; set; }

		public DateTime? FechaJefeDeptoJudiciales { get; set; }

		[Required(ErrorMessage = "Debe ingresar VisadoJefeUnidRegional")]
		public bool VisadoJefeUnidRegional { get; set; }

		public int? UsuarioJefeUnidRegional { get; set; }

		public DateTime? FechaJefeUnidRegional { get; set; }

		[StringLength(2147483647, ErrorMessage ="FundamentoMax no puede superar los 2147483647 caracteres")]
		public string FundamentoMax { get; set; }

        //public virtual ICollection<ActuacionesNotificacion> ActuacionesNotificacion { get; set; }

        //public virtual ICollection<ActuacionesPersonaDelito> ActuacionesPersonaDelito { get; set; }

        //public virtual ICollection<ActuacionesVoces> ActuacionesVocesActuacion { get; set; }

        //public virtual ICollection<AudienciasSolicitud> AudienciasSolicitud { get; set; }

        //public virtual ICollection<ExpedientesDocumento> ExpedientesDocumento { get; set; }

        //public virtual ICollection<ExpedientesEstado> ExpedientesEstado { get; set; }

        //public virtual ICollection<OrdenesCaptura> OrdenesCaptura { get; set; }

        //public virtual ICollection<Personas> PersonasActuacionCriterioOportunidad { get; set; }

        //public virtual ICollection<Personas> PersonasActuacionSuspencionProcesoAPrueba { get; set; }

		public virtual ICollection<Sucesos> Sucesos { get; set; }

		[ForeignKey("Expediente")]
		public virtual Expedientes Expedientes { get; set; }

		[ForeignKey("Preventivo")]
		public virtual Preventivos Preventivos { get; set; }

		[ForeignKey("TipoActuacion")]
		public virtual TiposActuacionRef TipoActuacions { get; set; }

		[ForeignKey("UsuarioAlta")]
		public virtual Usuarios UsuarioAltas { get; set; }

		[ForeignKey("Usuario")]
		public virtual Usuarios Usuarios { get; set; }

		[ForeignKey("Estado")]
		public virtual EstadosActuacionRef Estados { get; set; }

		[ForeignKey("UsuarioRecepcion")]
		public virtual Usuarios UsuarioRecepcions { get; set; }

		[ForeignKey("OficinaOrigen")]
		public virtual OrganismosRef OficinaOrigens { get; set; }

		[ForeignKey("SubAmbitoOrigen")]
		public virtual Ambitos SubAmbitoOrigens { get; set; }

		[ForeignKey("SubAmbitoCargo")]
		public virtual Ambitos SubAmbitoCargos { get; set; }

        //[ForeignKey("Firmante1")]
        //public virtual Usuarios Firmante1s { get; set; }

        //[ForeignKey("Firmante2")]
        //public virtual Usuarios Firmante2s { get; set; }

        //[ForeignKey("Firmante3")]
        //public virtual Usuarios Firmante3s { get; set; }

        //[ForeignKey("Firmante4")]
        //public virtual Usuarios Firmante4s { get; set; }

        //[ForeignKey("Firmante5")]
        //public virtual Usuarios Firmante5s { get; set; }

		[ForeignKey("UsuarioProtocolizado")]
		public virtual Usuarios UsuarioProtocolizados { get; set; }

		[ForeignKey("Protocolo")]
		public virtual Protocolos Protocolos { get; set; }

		[ForeignKey("UsuarioBloquea")]
		public virtual Usuarios UsuarioBloqueas { get; set; }
		#endregion

	}
}
