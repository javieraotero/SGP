using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class IncidentesEstadoMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Incidente")]
			public int Incidente { get; set; }

			[Display(Name = "Estado")]
			public int Estado { get; set; }

			[Display(Name = "FechaHora")]
			public DateTime FechaHora { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "DiasTranscurridos")]
			public int? DiasTranscurridos { get; set; }
			#endregion


	}
}
