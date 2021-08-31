using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AmbitosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "AmbitoPrincipal")]
			public int? AmbitoPrincipal { get; set; }

			[Display(Name = "EditaDetenidos")]
			public bool EditaDetenidos { get; set; }

			[Display(Name = "RecibeCargo")]
			public bool RecibeCargo { get; set; }

			[Display(Name = "CircunscripcionUnica")]
			public bool CircunscripcionUnica { get; set; }

			[Display(Name = "CambioCircunscripcion")]
			public int CambioCircunscripcion { get; set; }

			[Display(Name = "Protocoliza")]
			public bool Protocoliza { get; set; }

			[Display(Name = "CategorizaProtocolo")]
			public bool? CategorizaProtocolo { get; set; }

			[Display(Name = "Fuero")]
			public int Fuero { get; set; }
			#endregion


	}
}
