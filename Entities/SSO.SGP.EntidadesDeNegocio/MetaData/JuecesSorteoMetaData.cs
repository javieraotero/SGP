using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class JuecesSorteoMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "JuezSorteado")]
			public int JuezSorteado { get; set; }

			[Display(Name = "Delito")]
			public int Delito { get; set; }

			[Display(Name = "UsuarioSorteo")]
			public int UsuarioSorteo { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Activo")]
			public bool Activo { get; set; }
			#endregion


	}
}
