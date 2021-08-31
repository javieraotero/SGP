using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class VehiculosOficialesRefMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Legajo")]
			public string Legajo { get; set; }

			[Display(Name = "Patente")]
			public string Patente { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }
			#endregion


	}
}
