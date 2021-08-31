using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CoMediadoresViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "UsuarioCarga")]
			public int UsuarioCarga { get; set; }

			[Display(Name = "FechaCarga")]
			public DateTime FechaCarga { get; set; }

			[Display(Name = "UsuarioCoMediador")]
			public int UsuarioCoMediador { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "Tipo")]
			public int Tipo { get; set; }
			#endregion


	}
}
