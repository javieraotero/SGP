using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class GrupoFamiliarViewT
	{
			#region Propiedades

			[Display(Name = "Id", AutoGenerateField=false)]
			public int Id { get; set; }

			[Display(Name = "Nombre")]
			public string ApellidosYNombre { get; set; }

			[Display(Name = "Fecha Nac.")]
			public DateTime FechaDeNacimiento { get; set; }

			[Display(Name = "Documento")]
			public int Documento { get; set; }

			[Display(Name = "Parentezco")]
			public string TipoMiembro { get; set; }

			#endregion


	}
}
