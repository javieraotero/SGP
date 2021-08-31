using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class CesidaParametrosDeMovimientosMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name = "TipoDeDato")]
        public int? TipoDeDato { get; set; }

        [Display(Name = "Obligatorio")]
        public bool Obligatorio { get; set; }

        [Display(Name = "Referencia")]
        public string Referencia { get; set; }

        [Display(Name = "Predeterminado")]
        public string Predeterminado { get; set; }
        #endregion

    }
}
