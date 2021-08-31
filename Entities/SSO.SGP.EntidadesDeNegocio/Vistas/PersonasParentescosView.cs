using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PersonasParentescosView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Persona1")]
			public int Persona1 { get; set; }

			[Display(Name = "Persona2")]
			public int Persona2 { get; set; }

			[Display(Name = "TipoParentesco")]
			public int TipoParentesco { get; set; }
			#endregion


	}
}
