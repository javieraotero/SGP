using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PreventivosElementosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Preventivo")]
			public int Preventivo { get; set; }

			[Display(Name = "Rol")]
			public int Rol { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "GrupoElemento")]
			public int? GrupoElemento { get; set; }
			#endregion


	}
}
