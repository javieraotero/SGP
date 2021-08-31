using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomCambirClave 
	{
		
		[StringLength(20, ErrorMessage ="La clave no puede superar los 20 caracteres")]
        [Required(ErrorMessage="Debe ingresar la clave actual")]
        [Display(Name="Escriba su clave actual")]
		public string ClaveActual {get; set;}

        [StringLength(20, ErrorMessage = "La clave no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "Debe ingresar la clave nueva")]
        [DataType(DataType.Password)]
        [Display(Name = "Escriba la nueva clave")]
        public string ClaveNueva { get; set; }

        [StringLength(20, ErrorMessage = "La clave no puede superar los 20 caracteres")]
        [Required(ErrorMessage = "Debe reingresar la nueva clave")]
        [DataType(DataType.Password)]
        [Display(Name = "Re escriba la nueva clave")]
        public string ReClaveNueva { get; set; }
			
	}
}
	
	