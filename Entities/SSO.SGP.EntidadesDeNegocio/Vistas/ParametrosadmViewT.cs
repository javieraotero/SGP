using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ParametrosadmViewT
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
