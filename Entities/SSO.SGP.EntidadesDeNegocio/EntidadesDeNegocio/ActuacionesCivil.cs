
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
	[MetadataTypeAttribute(typeof(ActuacionesCivilMetaData))]
	[Table("ActuacionesCivil")]
	public partial class ActuacionesCivil
	{
		#region Constructor
		public ActuacionesCivil()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		public int? Causa { get; set; }

		[StringLength(255, ErrorMessage ="Descripcion no puede superar los 255 caracteres")]
		public string Descripcion { get; set; }

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

		[StringLength(2147483647, ErrorMessage ="FundamentoMax no puede superar los 2147483647 caracteres")]
		public string FundamentoMax { get; set; }

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

		public int? OficinaCargo { get; set; }

		public bool? Bloqueado { get; set; }

		public int? UsuarioBloquea { get; set; }

		public DateTime? FechaBloqueo { get; set; }

		public int? ModalidadDiasFechaPlazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarJuezAudiencia")]
		public bool MostrarJuezAudiencia { get; set; }

		public int? ModeloAplicado { get; set; }

		public virtual ICollection<ActuacionesCivilNotificacion> ActuacionesCivilNotificacion { get; set; }

		public virtual ICollection<CausasDocumento> CausasDocumento { get; set; }

		public virtual ICollection<CausasEstado> CausasEstado { get; set; }

		public virtual ICollection<SucesosCausas> SucesosCausas { get; set; }

		[ForeignKey("Causa")]
		public virtual Causas Causas { get; set; }

		[ForeignKey("TipoActuacion")]
		public virtual TiposActuacionCivilRef TipoActuacions { get; set; }

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

		[ForeignKey("Firmante1")]
		public virtual Usuarios Firmante1s { get; set; }

		[ForeignKey("Firmante2")]
		public virtual Usuarios Firmante2s { get; set; }

		[ForeignKey("Firmante3")]
		public virtual Usuarios Firmante3s { get; set; }

		[ForeignKey("Firmante4")]
		public virtual Usuarios Firmante4s { get; set; }

		[ForeignKey("Firmante5")]
		public virtual Usuarios Firmante5s { get; set; }

		[ForeignKey("UsuarioBloquea")]
		public virtual Usuarios UsuarioBloqueas { get; set; }
		#endregion

	}
}
