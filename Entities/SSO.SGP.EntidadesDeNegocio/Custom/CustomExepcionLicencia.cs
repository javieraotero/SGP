	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
    public class CustomExepcionLicencia 
	{		
        [Display(Name="Resolución")]
		public string Resolucion {get; set;}

        [Display(Name = "Días otorgados (0 = sin límite)")]
        public int DiasOtorgados { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        public int Agente { get; set; }

        public int Licencia { get; set; }

        [Display(Name = "Fecha fin de Exepción")]
        public DateTime FechaFin { get; set; }
    }
}
	
	