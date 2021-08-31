	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
    public class CustomPedidoDeSuministros 
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el Organismo")]
        public int Organismo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Pedido")]
        [Display(Name="Fecha de Pedido")]
        public DateTime FechaDePedido { get; set; }

        [Display(Name = "Entregado")]
        public bool Entregado { get; set; }

        public DetalleDePedido[] Detalle { get; set; }

	}

    public class DetalleDePedido
    {
        [Display(Name = "Id", AutoGenerateField=false)]
        public int id { get; set; }
        [Display(Name = "Artículo")]
        public string articulo { get; set; }
        [Display(Name = "IdArticulo", AutoGenerateField = false)]
        public int idarticulo { get; set; }
        [Display(Name = "Solicitado")]
        public int solicitado { get; set; }
        [Display(Name = "Entregado")]
        public int entregado { get; set; }
        [Display(AutoGenerateField = false, Name = "Nuevo")]
        public bool nuevo { get; set; }
    }

}
	
	