	
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.SGP.EntidadesDeNegocio
{

// CustomView
public class CustomImputarFactura 
	{
    [Required(ErrorMessage = "De seleccionar una factura")]
    [Display(Name = "Factura")]
    public int Factura { get; set; }

    [Required(ErrorMessage = "Debe ingresar una Fecha")]
    [Display(Name = "Fecha de Imputaci�n")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Debe ingresar el A�o Contable")]
    [Display(Name = "A�o Contable")]
    public int AnioContable { get; set; }

    [Display(Name = "Seleccione Partida")]
    public int? Partida { get; set; }
    [Display(Name = "Divisi�n")]
    public int? Division { get; set; }
    [Display(Name = "Importe")]
    public decimal? Importe { get; set; }

    public DetalleImputacionFactura[] Detalle { get; set; }
}

public class DetalleImputacionFactura {
    
    [Display(Name = "Id", AutoGenerateField = false)]
    public int id { get; set; }
    [Display(Name = "Partida")]
    public int partida { get; set; }
    [Display(Name = "Div. Extrap.")]
    public int division { get; set; }
    [Display(Name = "Importe")]
    public decimal importe { get; set; }
}

}
	
	