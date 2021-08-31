using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.EntidadesDeNegocio.Vistas
{
    /// <summary>
    /// Vista generada por generador de codigo
    /// </summary>
    public class ExpedientesadmView
    {
        #region Propiedades

        [Display(Name = "Id", Order = 0)]
        public int Id { get; set; }

        [Display(Name = "Fecha", Order = 10)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Numero", Order = 15)]
        public string Numero { get; set; }

        [Display(Name = "Caratula", Order = 60)]
        public string Caratula { get; set; }

        [Display(Name = "Fojas", Order = 5)]
        public int Fojas { get; set; }

        #endregion
    }
}
