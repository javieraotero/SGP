	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomResultadoEvaluacion
	{
		
		public int id { get; set; }
        public string nombre { get; set; }
        public long? dni { get; set; }
        public decimal? resultado { get; set; }


	}
}
	
	