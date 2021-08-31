	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomConsultaLicencias 
	{
		
		[Required(ErrorMessage = "Debe ingresar el Agente")]
		[Display(Name="Agente")]
        public int Agente {get; set;}

        [Display(Name = "Desde")]
        public DateTime? FechaDesde { get; set; }

        [Display(Name = "Hasta")]
        public DateTime? FechaHasta{ get; set; }

        [Display(Name = "Licencia")]
        public int Licencia { get; set; }


	}
}
	
	