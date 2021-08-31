using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CargosRefViewT
	{
			#region Propiedades

			[Display(Name = "Id")]
			public int Id { get; set; }

			[Display(Name = "Descripcion")]
			public string Descripcion { get; set; }

			[Display(Name = "Orden")]
			public int Orden { get; set; }

			[Display(Name = "Grupo")]
			public int Grupo { get; set; }

			[Display(Name = "CodigoRRHH")]
			public int? CodigoRRHH { get; set; }

			[Display(Name = "Presupuesto")]
			public int? Presupuesto { get; set; }
			#endregion


	}
}
