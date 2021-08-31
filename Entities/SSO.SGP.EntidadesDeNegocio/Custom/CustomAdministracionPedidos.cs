	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
    public class CustomAdministracionPedidos
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Organismo Origen")]
        public int OrganismoOrigen { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Organismo Destino")]
        public int OrganismoDestino { get; set; }           

        public DetalleDeAdministracionPedido[] Detalle { get; set; }

	}

    public class DetalleDeAdministracionPedido
    {
        [Display(Name = "Id", AutoGenerateField=false)]
        public int id { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
                
        [Display(Name = "Pedido_Hide", Order = 5)]
        public int Pedido { get; set; }
        
        [Display(Name = "FechaAlta_Hide", Order = 5)]
        public DateTime FechaAlta { get; set; }

        [Display(Name = "UsuarioAlta_Hide", Order = 0)]
        public int UsuarioAlta { get; set; }

        [Display(Name = "Activo", Order = 0)]
        public bool Activo { get; set; }


    }

}
	
	