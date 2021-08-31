using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SolicitudesDeViaticosPorComisionView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }		

			[Display(Name = "Destino", Order = 18)]
			public string Destino { get; set; }

            [Display(Name = "Motivo", Order = 18)]
            public string Motivo { get; set; }

            [Display(Name = "Inicio", Order = 15)]
			public DateTime FechaDeInicio { get; set; }

			[Display(Name = "Fin", Order = 15)]
			public DateTime FechaDeFin { get; set; }
		
			[Display(Name = "Estado", Order = 10)]
			public string Estado { get; set; }

            [Display(Name = "#Comision", Order = 5)]
            public int Comision { get; set; }

            [Display(Name = "Solicitudes", Order = 5)]
            public int Solicitudes { get; set; }

        #endregion


    }
}
