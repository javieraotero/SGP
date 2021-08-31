using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class ImputacionesContablesDetalleView
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "ImputacionContable")]
        public int ImputacionContable { get; set; }

        [Display(Name = "Año Contable")]
        public int AnioContable { get; set; }

        [Display(Name = "Partida")]
        public string Partida { get; set; }

        [Display(Name = "Division")]
        public int Division { get; set; }

        [Display(Name = "Importe")]
        public decimal Importe { get; set; }

        #endregion


    }
}
