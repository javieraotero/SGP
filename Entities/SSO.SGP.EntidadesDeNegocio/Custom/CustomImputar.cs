	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomImputar 
	{
		
		public int ExpedienteAImputar {get; set;}
		
		public DateTime Fecha {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Afectacion")]
		public bool Afectacion {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Compromiso")]
		public bool Compromiso {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el OrdenadoAPagar")]
		public bool OrdenadoAPagar {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Partida")]
		public int Partida {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Division")]
		public int Division {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Importe")]
		public decimal Importe {get; set;}
		
	}
}
	
	