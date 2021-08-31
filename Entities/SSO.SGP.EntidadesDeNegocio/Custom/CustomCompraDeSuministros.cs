	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
    public class CustomCompraDeSuministros 
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar la Fecha de Compra")]
        [Display(Name="Fecha de Pedido")]
        public DateTime Fecha { get; set; }

        [Display(Name = "N° Comprobante")]
        public string Comprobante { get; set; }

        public DetalleDeCompra[] Detalle { get; set; }

	}

    public class DetalleDeCompra
    {
        [Display(Name = "Id", AutoGenerateField=false)]
        public int id { get; set; }
        [Display(Name = "Artículo")]
        public string articulo { get; set; }
        [Display(Name = "IdArticulo", AutoGenerateField = false)]
        public int idarticulo { get; set; }
        [Display(Name = "Solicitado")]
        public int cantidad { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
        [Display(AutoGenerateField = false, Name = "Nuevo")]
        public bool nuevo { get; set; }
    }

}
	
	