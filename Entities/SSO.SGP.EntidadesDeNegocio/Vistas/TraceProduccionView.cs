using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TraceProduccionView
	{
			#region Propiedades

			[Display(Name = "RowNumber")]
			public int RowNumber { get; set; }

			[Display(Name = "EventClass")]
			public int? EventClass { get; set; }

			[Display(Name = "TextData")]
			public string TextData { get; set; }

			[Display(Name = "ApplicationName")]
			public string ApplicationName { get; set; }

			[Display(Name = "NTUserName")]
			public string NTUserName { get; set; }

			[Display(Name = "LoginName")]
			public string LoginName { get; set; }

			[Display(Name = "CPU")]
			public int? CPU { get; set; }

			[Display(Name = "Reads")]
			public long? Reads { get; set; }

			[Display(Name = "Writes")]
			public long? Writes { get; set; }

			[Display(Name = "Duration")]
			public long? Duration { get; set; }

			[Display(Name = "ClientProcessID")]
			public int? ClientProcessID { get; set; }

			[Display(Name = "SPID")]
			public int? SPID { get; set; }

			[Display(Name = "StartTime")]
			public DateTime? StartTime { get; set; }

			[Display(Name = "EndTime")]
			public DateTime? EndTime { get; set; }

			#endregion


	}
}
