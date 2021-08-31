	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomImputacion
	{
			
		public int Partida {get; set;}
		
		public int Division {get; set;}
		
		public decimal Importe {get; set;}
		
	}

    public class CustomImputacionJ
    {

        public int Partida { get; set; }

        public string Descripcion { get; set; }

        public int Division { get; set; }

        public decimal Importe { get; set; }

    }
}
	
	