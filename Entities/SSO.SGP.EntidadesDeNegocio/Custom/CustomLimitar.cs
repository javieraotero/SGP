	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomLimitar 
	{
		
        [Display(Name="Fecha Inicio")]
		public DateTime? FechaInicio {get; set;}

        [Display(Name = "Fecha Hasta")]
        public DateTime? FechaBaja { get; set; }

        public int Licencia { get; set; }
	}
}
	
	