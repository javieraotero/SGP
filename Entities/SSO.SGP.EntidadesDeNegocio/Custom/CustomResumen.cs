	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomResumen 
	{
		
		[Required(ErrorMessage = "Debe ingresar el Nombre")]
		[StringLength(0, ErrorMessage ="Codigo no puede superar los 0 caracteres")]
		public string Nombre {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Documento")]
		[StringLength(0, ErrorMessage ="Codigo no puede superar los 0 caracteres")]
		public string Documento {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Legajo")]
		[StringLength(0, ErrorMessage ="Codigo no puede superar los 0 caracteres")]
		public string Legajo {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Domicilio")]
		[StringLength(0, ErrorMessage ="Codigo no puede superar los 0 caracteres")]
		public string Domicilio {get; set;}
		
		[Required(ErrorMessage = "Debe ingresar el Telefono")]
		[StringLength(0, ErrorMessage ="Codigo no puede superar los 0 caracteres")]
		public string Telefono {get; set;}
		
	}
}
	
	