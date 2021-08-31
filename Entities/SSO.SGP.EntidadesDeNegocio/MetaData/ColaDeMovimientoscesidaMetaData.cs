using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ColaDeMovimientoscesidaMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombramiento")]
			public int? Nombramiento { get; set; }

			[Display(Name = "Agente")]
			public int? Agente { get; set; }

			[Display(Name = "Movimiento")]
			public int Movimiento { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "FechaEnvio")]
			public DateTime? FechaEnvio { get; set; }

			[Display(Name = "IdRespuesta")]
			public int? IdRespuesta { get; set; }

			[Display(Name = "MensajeRespuesta")]
			public string MensajeRespuesta { get; set; }

			[Display(Name = "Intentos")]
			public int Intentos { get; set; }

			[Display(Name = "Licencia")]
			public int? Licencia { get; set; }

			[Display(Name = "IdRegistro")]
			public int? IdRegistro { get; set; }

			[Display(Name = "FechaDesde")]
			public DateTime? FechaDesde { get; set; }

			[Display(Name = "FechaHasta")]
			public DateTime? FechaHasta { get; set; }

			[Display(Name = "Cargo")]
			public int? Cargo { get; set; }

			[Display(Name = "Organismo")]
			public int? Organismo { get; set; }
			#endregion


	}
}
