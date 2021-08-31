using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class EjecucionesPresupuestariasReestructurasViewT
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Anio")]
        public int Anio { get; set; }

        [Display(Name = "Partida")]
        public string Partida { get; set; }

        [Display(Name = "Importe")]
        public decimal Importe { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        #endregion


    }
}
