using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class AuditoriaMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Tabla")]
			public string Tabla { get; set; }

			[Display(Name = "Columna")]
			public string Columna { get; set; }

			[Display(Name = "Referencia")]
			public string Referencia { get; set; }

			[Display(Name = "IdReferencia")]
			public int? IdReferencia { get; set; }

			[Display(Name = "Usuario")]
			public int Usuario { get; set; }

			[Display(Name = "Fecha")]
			public DateTime Fecha { get; set; }

			[Display(Name = "ValorAnterior")]
			public string ValorAnterior { get; set; }

			[Display(Name = "ValorNuevo")]
			public string ValorNuevo { get; set; }
			#endregion


	}
}
