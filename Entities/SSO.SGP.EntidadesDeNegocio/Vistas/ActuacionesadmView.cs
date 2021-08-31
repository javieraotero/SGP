using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ActuacionesadmView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "FechaRecepcion")]
			public DateTime? FechaRecepcion { get; set; }

			[Display(Name = "UsuarioRecepcion")]
			public int? UsuarioRecepcion { get; set; }

			[Display(Name = "OficinaOrigen")]
			public int? OficinaOrigen { get; set; }

			[Display(Name = "SubAmbitoOrigen")]
			public int? SubAmbitoOrigen { get; set; }

			[Display(Name = "Anulado")]
			public bool Anulado { get; set; }

			[Display(Name = "FechaAnulado")]
			public DateTime? FechaAnulado { get; set; }

			[Display(Name = "UsuarioAnulacion")]
			public int? UsuarioAnulacion { get; set; }

			[Display(Name = "MotivoAnulacion")]
			public string MotivoAnulacion { get; set; }

			[Display(Name = "Texto")]
			public string Texto { get; set; }

			[Display(Name = "FechaPublicacion")]
			public DateTime? FechaPublicacion { get; set; }

			[Display(Name = "UsuarioPublica")]
			public int? UsuarioPublica { get; set; }

			[Display(Name = "FechaUltimaModificacion")]
			public DateTime? FechaUltimaModificacion { get; set; }

			[Display(Name = "TipoActuacion")]
			public int TipoActuacion { get; set; }

			[Display(Name = "ModeloAplicado")]
			public int? ModeloAplicado { get; set; }

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

			[Display(Name = "RequiereCargo")]
			public bool? RequiereCargo { get; set; }

			[Display(Name = "SubAmbitoCargo")]
			public int? SubAmbitoCargo { get; set; }

			[Display(Name = "FechaCargo")]
			public DateTime? FechaCargo { get; set; }

			[Display(Name = "UsuarioCargo")]
			public int? UsuarioCargo { get; set; }

			[Display(Name = "Fojas")]
			public int? Fojas { get; set; }
			#endregion


	}
}
