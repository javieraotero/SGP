using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ArchivoExpedienteMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fuero")]
			public int Fuero { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "NroLegajo")]
			public string NroLegajo { get; set; }

			[Display(Name = "Caratula")]
			public string Caratula { get; set; }

			[Display(Name = "NroPaquete")]
			public string NroPaquete { get; set; }

			[Display(Name = "NroEstanteria")]
			public string NroEstanteria { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "FechaProbableExpurgacion")]
			public DateTime? FechaProbableExpurgacion { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Fojas")]
			public int? Fojas { get; set; }

			[Display(Name = "OrganismoEnvio")]
			public int OrganismoEnvio { get; set; }

			[Display(Name = "FechaEnvio")]
			public DateTime FechaEnvio { get; set; }

			[Display(Name = "ConfirmadoArchivado")]
			public bool ConfirmadoArchivado { get; set; }

			[Display(Name = "TipoArchivado")]
			public int? TipoArchivado { get; set; }

			[Display(Name = "CargoArchivo")]
			public bool? CargoArchivo { get; set; }

			[Display(Name = "FechaRecepcion")]
			public DateTime? FechaRecepcion { get; set; }

			[Display(Name = "CircunscripcionArchiva")]
			public int CircunscripcionArchiva { get; set; }
			#endregion


	}
}
