using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class NombramientosMovimientosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Nombramiento")]
			public int Nombramiento { get; set; }

			[Display(Name = "Desde")]
			public DateTime Desde { get; set; }

			[Display(Name = "Hasta")]
			public DateTime? Hasta { get; set; }

			[Display(Name = "Cargo")]
			public int Cargo { get; set; }

			[Display(Name = "SituacionRevista")]
			public int SituacionRevista { get; set; }

			[Display(Name = "Organismo")]
			public int Organismo { get; set; }
			#endregion


	}
}
