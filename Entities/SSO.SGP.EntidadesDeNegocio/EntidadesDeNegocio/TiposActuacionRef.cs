
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
	[MetadataTypeAttribute(typeof(TiposActuacionRefMetaData))]
	[Table("TiposActuacionRef")]
	public partial class TiposActuacionRef
	{
		#region Constructor
		public TiposActuacionRef()
		{
			// Prueba de codigo
		}
		#endregion

		#region Propiedades

		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Debe ingresar Descripcion")]
		[StringLength(100, ErrorMessage ="Descripcion no puede superar los 100 caracteres")]
		public string Descripcion { get; set; }

		public int? EstadoExpediente { get; set; }

		[Required(ErrorMessage = "Debe ingresar PersonaDelito")]
		public bool PersonaDelito { get; set; }

		[Required(ErrorMessage = "Debe ingresar Activa")]
		public bool Activa { get; set; }

		[Required(ErrorMessage = "Debe ingresar Grupo")]
		public int Grupo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CambiaEtapa")]
		public bool CambiaEtapa { get; set; }

		[Required(ErrorMessage = "Debe ingresar PaseOJ")]
		public bool PaseOJ { get; set; }

		[Required(ErrorMessage = "Debe ingresar GenerarAudiencia")]
		public bool GenerarAudiencia { get; set; }

		public int? TipoAudiencia { get; set; }

		[Required(ErrorMessage = "Debe ingresar Plazo")]
		public int Plazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereNotificacion")]
		public bool RequiereNotificacion { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarDefensor")]
		public bool MostrarDefensor { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarFiscal")]
		public bool MostrarFiscal { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarJuez")]
		public bool MostrarJuez { get; set; }

		[Required(ErrorMessage = "Debe ingresar RequiereCargo")]
		public bool RequiereCargo { get; set; }

		public int? SubAmbitoCargo { get; set; }

		[Required(ErrorMessage = "Debe ingresar CantidadFirmantes")]
		public int CantidadFirmantes { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarTIP")]
		public bool MostrarTIP { get; set; }

		[Required(ErrorMessage = "Debe ingresar MostrarSTJ")]
		public bool MostrarSTJ { get; set; }

		public int? Protocolo { get; set; }

		[Required(ErrorMessage = "Debe ingresar ModalidadDiasFechaPlazo")]
		public int ModalidadDiasFechaPlazo { get; set; }

		[Required(ErrorMessage = "Debe ingresar Protocoliza")]
		public bool Protocoliza { get; set; }

		public int? ProtocoloCategoria { get; set; }

		public int? UsuarioAlta { get; set; }

		public DateTime? FechaAlta { get; set; }

		public int? UsuarioModifica { get; set; }

		public DateTime? FechaModifica { get; set; }

		public int? UsuarioElimina { get; set; }

		public DateTime? FechaElimina { get; set; }

		public int? ProtocoloCategoriaSubAmbito { get; set; }

		[Required(ErrorMessage = "Debe ingresar PasaAMPF")]
		public bool PasaAMPF { get; set; }

		//public virtual ICollection<Actuaciones> Actuaciones { get; set; }

		//public virtual ICollection<ModelosEscrito> ModelosEscrito { get; set; }

		//public virtual ICollection<ParametrosTrabajoRef> ParametrosTrabajoRef { get; set; }

		[ForeignKey("EstadoExpediente")]
		public virtual EstadosExpedienteRef EstadoExpedientes { get; set; }

		[ForeignKey("Grupo")]
		public virtual GruposTipoActuacionRef Grupos { get; set; }

		[ForeignKey("TipoAudiencia")]
		public virtual TiposAudienciaRef TipoAudiencias { get; set; }

		[ForeignKey("SubAmbitoCargo")]
		public virtual Ambitos SubAmbitoCargos { get; set; }

		[ForeignKey("Protocolo")]
		public virtual Protocolos Protocolos { get; set; }

		[ForeignKey("ProtocoloCategoria")]
		public virtual ProtocolosCategorias ProtocoloCategorias { get; set; }

		[ForeignKey("ProtocoloCategoriaSubAmbito")]
		public virtual Ambitos ProtocoloCategoriaSubAmbitos { get; set; }
		#endregion

	}
}
