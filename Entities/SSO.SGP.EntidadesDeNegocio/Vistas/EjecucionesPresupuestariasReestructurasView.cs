using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class EjecucionesPresupuestariasReestructurasView
	{
			#region Propiedades

			[Display(Name = "Id", Order =0)]
			public int Id { get; set; }

			[Display(Name = "Anio", Order = 15)]
			public int Anio { get; set; }

			[Display(Name = "Partida", Order = 40)]
			public string Partida { get; set; }

			[Display(Name = "Importe", Order = 15)]
			public decimal Importe { get; set; }

            [Display(Name = "Otorgado", Order = 15)]
            public decimal Otorgado { get; set; }

        [Display(Name = "Tipo", Order = 20)]
        public string Tipo { get; set; }

        [Display(Name = "Fecha", Order = 10)]
			public DateTime Fecha { get; set; }

			#endregion
	}
}
