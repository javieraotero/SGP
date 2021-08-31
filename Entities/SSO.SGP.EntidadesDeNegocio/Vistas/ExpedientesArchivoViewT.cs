using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ExpedientesArchivoViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Expediente")]
			public int Expediente { get; set; }

			[Display(Name = "UsuarioEnvio")]
			public int UsuarioEnvio { get; set; }

			[Display(Name = "Firmante")]
			public int Firmante { get; set; }

			[Display(Name = "FechaEnvio")]
			public DateTime FechaEnvio { get; set; }

			[Display(Name = "Observaciones")]
			public string Observaciones { get; set; }

			[Display(Name = "Anulado")]
			public bool Anulado { get; set; }

			[Display(Name = "FechaFinArchivo")]
			public DateTime? FechaFinArchivo { get; set; }

			[Display(Name = "FechaAlta")]
			public DateTime FechaAlta { get; set; }
			#endregion


	}
}
