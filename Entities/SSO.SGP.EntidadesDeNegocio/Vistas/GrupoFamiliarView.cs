using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class GrupoFamiliarView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Agente")]
			public int Agente { get; set; }

			[Display(Name = "ApellidosYNombre")]
			public string ApellidosYNombre { get; set; }

			[Display(Name = "FechaDeNacimiento")]
			public DateTime FechaDeNacimiento { get; set; }

			[Display(Name = "Documento")]
			public int Documento { get; set; }

			[Display(Name = "TipoMiembro")]
			public int TipoMiembro { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }

			[Display(Name = "FechaBaja")]
			public DateTime? FechaBaja { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }
			#endregion


	}
}
