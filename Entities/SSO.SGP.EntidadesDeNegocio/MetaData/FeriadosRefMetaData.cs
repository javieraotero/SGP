using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class FeriadosRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Dia")]
			public int Dia { get; set; }

			[Display(Name = "Mes")]
			public int Mes { get; set; }

			[Display(Name = "Anio")]
			public int Anio { get; set; }

			[Display(Name = "Movil")]
			public bool Movil { get; set; }

			[Display(Name = "Nacional")]
			public bool Nacional { get; set; }
			#endregion


	}
}
