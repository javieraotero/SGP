using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ActuacionesViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Preventivo")]
			public int? Preventivo { get; set; }

			[Display(Name = "TipoActuacion")]
			public int TipoActuacion { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "FechaVencimiento")]
			public DateTime? FechaVencimiento { get; set; }

			[Display(Name = "FechaAlerta")]
			public DateTime? FechaAlerta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "FechaUltimaModificacion")]
			public DateTime? FechaUltimaModificacion { get; set; }

			[Display(Name = "Fundamento")]
			public string Fundamento { get; set; }

			[Display(Name = "FechaRecepcion")]
			public DateTime? FechaRecepcion { get; set; }

			[Display(Name = "UsuarioRecepcion")]
			public int? UsuarioRecepcion { get; set; }

			[Display(Name = "Confirmado")]
			public bool Confirmado { get; set; }

			[Display(Name = "FechaFinPlazo")]
			public DateTime? FechaFinPlazo { get; set; }

			[Display(Name = "OficinaOrigen")]
			public int? OficinaOrigen { get; set; }

			[Display(Name = "SubAmbitoOrigen")]
			public int? SubAmbitoOrigen { get; set; }

			[Display(Name = "MostrarDefensor")]
			public bool MostrarDefensor { get; set; }

			[Display(Name = "MostrarFiscal")]
			public bool MostrarFiscal { get; set; }

			[Display(Name = "MostrarJuez")]
			public bool MostrarJuez { get; set; }

			[Display(Name = "RequiereCargo")]
			public bool? RequiereCargo { get; set; }

			[Display(Name = "SubAmbitoCargo")]
			public int? SubAmbitoCargo { get; set; }

			[Display(Name = "FechaCargo")]
			public DateTime? FechaCargo { get; set; }

			[Display(Name = "UsuarioCargo")]
			public int? UsuarioCargo { get; set; }

			[Display(Name = "FechaEliminada")]
			public DateTime? FechaEliminada { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "FechaPublicacion")]
			public DateTime? FechaPublicacion { get; set; }

			[Display(Name = "UsuarioPublica")]
			public int? UsuarioPublica { get; set; }

			[Display(Name = "Firmante1")]
			public int? Firmante1 { get; set; }

			[Display(Name = "FechaFirmante1")]
			public DateTime? FechaFirmante1 { get; set; }

			[Display(Name = "Firmante2")]
			public int? Firmante2 { get; set; }

			[Display(Name = "FechaFirmante2")]
			public DateTime? FechaFirmante2 { get; set; }

			[Display(Name = "Firmante3")]
			public int? Firmante3 { get; set; }

			[Display(Name = "FechaFirmante3")]
			public DateTime? FechaFirmante3 { get; set; }

			[Display(Name = "Firmante4")]
			public int? Firmante4 { get; set; }

			[Display(Name = "FechaFirmante4")]
			public DateTime? FechaFirmante4 { get; set; }

			[Display(Name = "Firmante5")]
			public int? Firmante5 { get; set; }

			[Display(Name = "FechaFirmante5")]
			public DateTime? FechaFirmante5 { get; set; }

			[Display(Name = "CantidadFirmantes")]
			public int? CantidadFirmantes { get; set; }

			[Display(Name = "MostrarTIP")]
			public bool MostrarTIP { get; set; }

			[Display(Name = "MostrarSTJ")]
			public bool MostrarSTJ { get; set; }

			[Display(Name = "MotivoAnulacion")]
			public string MotivoAnulacion { get; set; }

			[Display(Name = "FechaAnulacion")]
			public DateTime? FechaAnulacion { get; set; }

			[Display(Name = "UsuarioAnulacion")]
			public int? UsuarioAnulacion { get; set; }

			[Display(Name = "Protocolizado")]
			public bool? Protocolizado { get; set; }

			[Display(Name = "FechaProtocolizado")]
			public DateTime? FechaProtocolizado { get; set; }

			[Display(Name = "UsuarioProtocolizado")]
			public int? UsuarioProtocolizado { get; set; }

			[Display(Name = "Protocolo")]
			public int? Protocolo { get; set; }

			[Display(Name = "OficinaCargo")]
			public int? OficinaCargo { get; set; }

			[Display(Name = "Bloqueado")]
			public bool? Bloqueado { get; set; }

			[Display(Name = "UsuarioBloquea")]
			public int? UsuarioBloquea { get; set; }

			[Display(Name = "FechaBloqueo")]
			public DateTime? FechaBloqueo { get; set; }

			[Display(Name = "ModalidadDiasFechaPlazo")]
			public int? ModalidadDiasFechaPlazo { get; set; }

			[Display(Name = "MostrarJuezAudiencia")]
			public bool MostrarJuezAudiencia { get; set; }

			[Display(Name = "SubAmbitoProtocolizado")]
			public int? SubAmbitoProtocolizado { get; set; }

			[Display(Name = "CategoriaProtocolizado")]
			public int? CategoriaProtocolizado { get; set; }

			[Display(Name = "ModeloAplicado")]
			public int? ModeloAplicado { get; set; }

			[Display(Name = "VisadoJefatura")]
			public bool VisadoJefatura { get; set; }

			[Display(Name = "UsuarioJefatura")]
			public int? UsuarioJefatura { get; set; }

			[Display(Name = "FechaJefatura")]
			public DateTime? FechaJefatura { get; set; }

			[Display(Name = "VisadoSubJefatura")]
			public bool VisadoSubJefatura { get; set; }

			[Display(Name = "UsuarioSubJefatura")]
			public int? UsuarioSubJefatura { get; set; }

			[Display(Name = "FechaSubJefatura")]
			public DateTime? FechaSubJefatura { get; set; }

			[Display(Name = "VisadoJefeDeptoJudiciales")]
			public bool VisadoJefeDeptoJudiciales { get; set; }

			[Display(Name = "UsuarioJefeDeptoJudiciales")]
			public int? UsuarioJefeDeptoJudiciales { get; set; }

			[Display(Name = "FechaJefeDeptoJudiciales")]
			public DateTime? FechaJefeDeptoJudiciales { get; set; }

			[Display(Name = "VisadoJefeUnidRegional")]
			public bool VisadoJefeUnidRegional { get; set; }

			[Display(Name = "UsuarioJefeUnidRegional")]
			public int? UsuarioJefeUnidRegional { get; set; }

			[Display(Name = "FechaJefeUnidRegional")]
			public DateTime? FechaJefeUnidRegional { get; set; }

			[Display(Name = "FundamentoMax")]
			public string FundamentoMax { get; set; }
			#endregion


	}
}
