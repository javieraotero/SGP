using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AudienciasSolicitudMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Solicitante")]
			public int? Solicitante { get; set; }

			[Display(Name = "TipoAudiencia")]
			public int TipoAudiencia { get; set; }

			[Display(Name = "SolicitaJuez")]
			public bool SolicitaJuez { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Audiencia")]
			public int? Audiencia { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Expediente")]
			public int? Expediente { get; set; }

			[Display(Name = "ActuacionOriginante")]
			public int? ActuacionOriginante { get; set; }
			#endregion


	}
}
