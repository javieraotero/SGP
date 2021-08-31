using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class ColaDeMovimientoscesidaView
	{
			#region Propiedades

			[Display(Name = "Id", Order =0)]
			public int Id { get; set; }

			[Display(Name = "Agente", Order = 15)]
			public string Agente { get; set; }

			[Display(Name = "Movimiento", Order = 10)]
			public string Movimiento { get; set; }

			[Display(Name = "Fecha", Order = 7)]
			public DateTime Fecha { get; set; }

			[Display(Name = "F. Envío", Order = 7)]
			public string FechaEnvio { get; set; }

			[Display(Name = "Intentos", Order = 5)]
			public int Intentos { get; set; }

			[Display(Name = "Desde", Order = 7)]
			public string FechaDesde { get; set; }

			[Display(Name = "Hasta", Order = 7)]
			public string FechaHasta { get; set; }

			[Display(Name = "Cargo", Order = 0)]
			public string Cargo { get; set; }

			[Display(Name = "Organismo", Order = 10)]
			public string Organismo { get; set; }

            [Display(Name = "Respuesta", Order = 15)]
            public string Respuesta { get; set; }

        #endregion


    }
}
