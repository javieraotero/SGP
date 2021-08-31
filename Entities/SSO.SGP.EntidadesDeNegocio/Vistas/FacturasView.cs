using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class FacturasView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Número", Order = 15)]
        public string NumeroDeFactura { get; set; }

        [Display(Name = "Identificador", Order = 5)]
        public int IdentificacionDeFactura { get; set; }

        [Display(Name = "Tipo", Order = 5)]
        public string Tipo { get; set; }

        [Display(Name = "Expediente", Order = 5)]
        public string Expediente { get; set; }

        [Display(Name = "Proveedor", Order = 25)]
        public string Proveedor { get; set; }

        [Display(Name = "Fecha", Order = 10)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Importe", Order = 10)]
        public decimal Importe { get; set; }

        #endregion


    }

    public class FacturasDetalleView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Número", Order = 15)]
        public string NumeroDeFactura { get; set; }

        [Display(Name = "Identificador", Order = 5)]
        public int IdentificacionDeFactura { get; set; }

        [Display(Name = "Concepto", Order = 15)]
        public string Concepto { get; set; }

        [Display(Name = "Organismo", Order = 15)]
        public string Organismo { get; set; }

        //         [Display(Name = "Tipo", Order = 5)]
        //public string Tipo { get; set; }

        [Display(Name = "Expediente", Order = 5)]
        public string Expediente { get; set; }

        [Display(Name = "Proveedor", Order = 15)]
        public string Proveedor { get; set; }

        [Display(Name = "Fecha", Order = 10)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Importe", Order = 10)]
        public decimal Importe { get; set; }

        #endregion


    }

}
