using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
	/// <summary>
	/// MetaData Generada por el Generador de codigo.
	/// </summary>
	public partial class ParametrosadmMetaData
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "UltimoExpediente")]
			public int UltimoExpediente { get; set; }

			[Display(Name = "UltimaFactura")]
			public int UltimaFactura { get; set; }

			[Display(Name = "UltimoTramite")]
			public int UltimoTramite { get; set; }
			#endregion


	}
}
