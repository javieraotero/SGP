using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class JuecesContadoresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "NivelPonderacion")]
			public int NivelPonderacion { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Contador")]
			public int Contador { get; set; }

			[Display(Name = "Juez")]
			public int Juez { get; set; }
			#endregion


	}
}
