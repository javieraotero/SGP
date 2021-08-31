	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomBuscarPersona 
	{
		
		[Required(ErrorMessage = "Debe ingresar el Documento")]
		public int Documento {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Apellidos")]
		[StringLength(15, ErrorMessage ="Codigo no puede superar los 15 caracteres")]
		public string Apellidos {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Nombre")]
		[StringLength(25, ErrorMessage ="Codigo no puede superar los 25 caracteres")]
		public string Nombre {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Sexo")]
		public int Sexo {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Localidad")]
		public int Localidad {get; set;}
		
	}
}
	
	