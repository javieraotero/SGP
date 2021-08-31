	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomDashboard 
	{
		
		public int TotalPlantaPermanente {get; set;}

        public int TotalContratados { get; set; }

        public int TotalEnLicencia { get; set; }

        public int TotalSustitutos { get; set; }

	}
}
	
	