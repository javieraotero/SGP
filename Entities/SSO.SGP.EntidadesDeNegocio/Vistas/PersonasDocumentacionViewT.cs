using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class PersonasDocumentacionViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Persona")]
			public int Persona { get; set; }

			[Display(Name = "TipoDocumentacion")]
			public int TipoDocumentacion { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }
			#endregion


	}
}
