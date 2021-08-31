using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class CesidaMovimientosAgentesDetallesMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "MovimientoAgente")]
        public int MovimientoAgente { get; set; }

        [Display(Name = "Parametro")]
        public int Parametro { get; set; }

        [Display(Name = "Valor")]
        public string Valor { get; set; }
        #endregion        

    }
}
