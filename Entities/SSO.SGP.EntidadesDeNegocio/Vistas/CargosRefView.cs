using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class CargosRefView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

            [Display(Name = "Descripcion", Order = 45)]
			public string Descripcion { get; set; }

            [Display(Name = "Orden", Order = 10)]
			public int Orden { get; set; }

            [Display(Name = "Grupo", Order = 10)]
			public int Grupo { get; set; }

            [Display(Name = "CodigoRRHH", Order = 10)]
			public int? CodigoRRHH { get; set; }

            [Display(Name = "Presupuesto", Order = 10)]
			public int? Presupuesto { get; set; }
			#endregion


	}
}
