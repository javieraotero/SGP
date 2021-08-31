	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
    public class CustomExepcionLicencia 
	{		
        [Display(Name="Resoluci�n")]
		public string Resolucion {get; set;}

        [Display(Name = "D�as otorgados (0 = sin l�mite)")]
        public int DiasOtorgados { get; set; }

        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }

        public int Agente { get; set; }

        public int Licencia { get; set; }

        [Display(Name = "Fecha fin de Exepci�n")]
        public DateTime FechaFin { get; set; }
    }
}
	
	