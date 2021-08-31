using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ModelosEscritoadmView
	{
			#region Propiedades

			[Display(Name = "Id", Order=0)]
			public int Id { get; set; }

            [Display(Name = "Oficina", Order = 25)]
			public string Oficina { get; set; }

            [Display(Name = "Titulo", Order = 30)]
			public string Titulo { get; set; }

            [Display(Name = "F. Creación", Order = 10)]
			public DateTime FechaAlta { get; set; }

            [Display(Name = "Tipo", Order = 20)]
			public string Tipo { get; set; }

            #endregion


	}
}
