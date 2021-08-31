using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
	/// <summary>
	/// Vista generada por generador de codigo
	/// </summary>
	public class SolicitudesDeViaticosView
	{
			#region Propiedades

			[Display(Name = "Id", Order = 0)]
			public int Id { get; set; }

            [Display(Name = "Agentes_Hide", Order = 0)]
            public string Agentes_Hide { get; set; }

            [Display(Name = "Fecha", Order = 10)]
			public DateTime Fecha { get; set; }

			[Display(Name = "Organismo", Order = 15)]
			public string OrganismoSolicitante { get; set; }

			[Display(Name = "Destino", Order = 13)]
			public string Destino { get; set; }

            [Display(Name = "Motivo", Order = 15)]
            public string Motivo { get; set; }

            [Display(Name = "Inicio", Order = 10)]
			public DateTime FechaDeInicio { get; set; }

			[Display(Name = "Fin", Order = 10)]
			public DateTime FechaDeFin { get; set; }
		
			[Display(Name = "Estado", Order = 10)]
			public string Estado { get; set; }

            [Display(Name = "#Id", Order = 5)]
            public int Identificador { get; set; }

            [Display(Name = "#Comisión", Order = 5)]
            public int Comision { get; set; }

        #endregion
    }
}
