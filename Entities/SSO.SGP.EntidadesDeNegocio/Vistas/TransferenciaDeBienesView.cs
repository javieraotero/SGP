using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class TransferenciaDeBienesView
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Bien")]
			public string IdBien { get; set; }

			[Display(Name = "Origen")]
			public string Origen { get; set; }

			[Display(Name = "Destino")]
			public string Destino { get; set; }

			[Display(Name = "Fecha")]
			public DateTime? Fecha { get; set; }

			[Display(Name = "PlanillaDeTransferencia")]
			public int? PlanillaDeTransferencia { get; set; }


			#endregion


	}
}
