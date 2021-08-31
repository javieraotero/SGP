using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CompraDeSuministrosView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

			[Display(Name = "Fecha", Order=10)]
			public DateTime Fecha { get; set; }

			[Display(Name = "Comprobante", Order = 60)]
			public string Comprobante { get; set; }

			[Display(Name = "FechaDeCarga", Order= 10)]
			public DateTime FechaDeCarga { get; set; }

			#endregion
	}
}
