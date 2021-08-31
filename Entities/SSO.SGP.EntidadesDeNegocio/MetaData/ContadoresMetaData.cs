using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ContadoresMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Fiscal")]
			public int Fiscal { get; set; }

			[Display(Name = "Categoria")]
			public int Categoria { get; set; }

			[Display(Name = "Habilitado")]
			public bool Habilitado { get; set; }

			[Display(Name = "Cantidad")]
			public int Cantidad { get; set; }

			[Display(Name = "Circunscripcion")]
			public int Circunscripcion { get; set; }
			#endregion


	}
}
