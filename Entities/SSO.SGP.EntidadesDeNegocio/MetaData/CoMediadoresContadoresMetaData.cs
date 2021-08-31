using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class CoMediadoresContadoresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Inscripcion")]
			public int Inscripcion { get; set; }

			[Display(Name = "Contador")]
			public int Contador { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
