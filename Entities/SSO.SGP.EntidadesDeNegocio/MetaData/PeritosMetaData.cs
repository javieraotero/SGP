using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PeritosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Universidad")]
			public string Universidad { get; set; }

			[Display(Name = "FechaTitulo")]
			public DateTime? FechaTitulo { get; set; }

			[Display(Name = "EstaSuspendido")]
			public bool? EstaSuspendido { get; set; }

			[Display(Name = "SuspendidoDesde")]
			public DateTime? SuspendidoDesde { get; set; }

			[Display(Name = "SuspendidoHasta")]
			public DateTime? SuspendidoHasta { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Sanciones")]
			public string Sanciones { get; set; }

			[Display(Name = "Persona")]
			public int? Persona { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
