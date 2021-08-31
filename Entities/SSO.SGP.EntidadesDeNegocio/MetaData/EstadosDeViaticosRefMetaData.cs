using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class EstadosDeViaticosRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "EditaOrganismo")]
			public bool EditaOrganismo { get; set; }

			[Display(Name = "EditaEconomia")]
			public bool EditaEconomia { get; set; }
			#endregion


	}
}
