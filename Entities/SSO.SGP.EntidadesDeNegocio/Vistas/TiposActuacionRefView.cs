using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TiposActuacionRefView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "EstadoExpediente")]
			public int? EstadoExpediente { get; set; }

			[Display(Name = "PersonaDelito")]
			public bool PersonaDelito { get; set; }

			[Display(Name = "Activa")]
			public bool Activa { get; set; }

			[Display(Name = "Grupo")]
			public int Grupo { get; set; }

			[Display(Name = "CambiaEtapa")]
			public bool CambiaEtapa { get; set; }

			[Display(Name = "PaseOJ")]
			public bool PaseOJ { get; set; }

			[Display(Name = "GenerarAudiencia")]
			public bool GenerarAudiencia { get; set; }

			[Display(Name = "TipoAudiencia")]
			public int? TipoAudiencia { get; set; }

			[Display(Name = "Plazo")]
			public int Plazo { get; set; }

			[Display(Name = "RequiereNotificacion")]
			public bool RequiereNotificacion { get; set; }

			[Display(Name = "MostrarDefensor")]
			public bool MostrarDefensor { get; set; }

			[Display(Name = "MostrarFiscal")]
			public bool MostrarFiscal { get; set; }

			[Display(Name = "MostrarJuez")]
			public bool MostrarJuez { get; set; }

			[Display(Name = "RequiereCargo")]
			public bool RequiereCargo { get; set; }

			[Display(Name = "SubAmbitoCargo")]
			public int? SubAmbitoCargo { get; set; }

			[Display(Name = "CantidadFirmantes")]
			public int CantidadFirmantes { get; set; }

			[Display(Name = "MostrarTIP")]
			public bool MostrarTIP { get; set; }

			[Display(Name = "MostrarSTJ")]
			public bool MostrarSTJ { get; set; }

			[Display(Name = "Protocolo")]
			public int? Protocolo { get; set; }

			[Display(Name = "ModalidadDiasFechaPlazo")]
			public int ModalidadDiasFechaPlazo { get; set; }

			[Display(Name = "Protocoliza")]
			public bool Protocoliza { get; set; }

			[Display(Name = "ProtocoloCategoria")]
			public int? ProtocoloCategoria { get; set; }

			[Display(Name = "UsuarioAlta")]
			public int? UsuarioAlta { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime? FechaAlta { get; set; }

			[Display(Name = "UsuarioModifica")]
			public int? UsuarioModifica { get; set; }

			[Display(Name = "FechaModifica")]
			public DateTime? FechaModifica { get; set; }

			[Display(Name = "UsuarioElimina")]
			public int? UsuarioElimina { get; set; }

			[Display(Name = "FechaElimina")]
			public DateTime? FechaElimina { get; set; }

			[Display(Name = "ProtocoloCategoriaSubAmbito")]
			public int? ProtocoloCategoriaSubAmbito { get; set; }

			[Display(Name = "PasaAMPF")]
			public bool PasaAMPF { get; set; }
			#endregion


	}
}
