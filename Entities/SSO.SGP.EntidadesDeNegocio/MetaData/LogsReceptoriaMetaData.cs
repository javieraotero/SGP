using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class LogsReceptoriaMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Numero")]
			public int Numero { get; set; }

			[Display(Name = "Juzgado")]
			public string Juzgado { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "Categoria")]
			public string Categoria { get; set; }

			[Display(Name = "Contadores")]
			public string Contadores { get; set; }

			[Display(Name = "IdCategoria")]
			public string IdCategoria { get; set; }
			#endregion


	}
}
