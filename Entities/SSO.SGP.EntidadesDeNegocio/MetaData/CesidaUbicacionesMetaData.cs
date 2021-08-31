using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSO.SGP.MetaData
{
    /// <summary>
    /// MetaData Generada por el Generador de codigo.
    /// </summary>
    public partial class CesidaUbicacionesMetaData
    {
        #region Propiedades

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "NUMERO")]
        public int? NUMERO { get; set; }

        [Display(Name = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
        #endregion

    }
}
