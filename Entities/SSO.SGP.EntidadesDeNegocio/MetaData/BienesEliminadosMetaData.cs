using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class BienesEliminadosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "NumeroDeInventario")]
			public int NumeroDeInventario { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Nombre")]
			public string Nombre { get; set; }

			[Display(Name = "Organizacion")]
			public string Organizacion { get; set; }

			[Display(Name = "Primario")]
			public int? Primario { get; set; }

			[Display(Name = "Secundario")]
			public int? Secundario { get; set; }

			[Display(Name = "Uso")]
			public int? Uso { get; set; }

			[Display(Name = "Causa")]
			public string Causa { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }
			#endregion


	}
}
