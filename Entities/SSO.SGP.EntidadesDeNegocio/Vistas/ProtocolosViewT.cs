using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ProtocolosViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "RequiereVoces")]
			public bool RequiereVoces { get; set; }

			[Display(Name = "Ambito")]
			public int Ambito { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
