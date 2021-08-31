using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class PreventivosDelitosMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Preventivo")]
			public int Preventivo { get; set; }

			[Display(Name = "Delito")]
			public int Delito { get; set; }

			[Display(Name = "Tentativa")]
			public bool Tentativa { get; set; }

			[Display(Name = "Flagrancia")]
			public bool Flagrancia { get; set; }
			#endregion


	}
}
